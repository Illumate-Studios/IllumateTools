using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Illumate.Tools
{
    public static class Switches
    {
        private static Dictionary<string, Switch> dict = new();

        public static bool GetStatus(string key) => dict.ContainsKey(key) && dict[key].status;

        /// <summary>
        /// Add specific start by name called "key"
        /// </summary>
        /// <param name="key"></param>
        /// <param name="switchAction"></param>
        public static void Add(string key, Action<bool> switchAction)
        {
            if (dict.TryGetValue(key, out Switch @switch))
                @switch.AddCallback(switchAction);
            else
                dict.Add(key, new Switch(key, switchAction));
        }

        public static void Trigger(string key, bool stat)
        {
            if (dict.ContainsKey(key))
                dict[key].Trigger(stat);
            else
                dict.Add(key, new Switch(key, stat, true));
        }

        public static void Reset()
        {
            dict = new();
        }

        private class Switch
        {
            public bool status = false;
            private string name;
            private bool hasInitted = false;

            private Action<bool> actions;

            public Switch(string name, Action<bool> action, bool isInit = false)
            {
                this.name = name;
                this.actions = action;
                this.hasInitted = isInit;
            }
            public Switch(string name, bool status, bool isInit = false)
            {
                this.name = name;
                this.status = status;
                this.hasInitted = isInit;
            }

            public void AddCallback(Action<bool> receiver)
            {
                if(actions != null)
                    Debug.Assert(!actions.GetInvocationList().Contains(receiver));

                actions += receiver;
                if (hasInitted) receiver.Invoke(status);
            }

            public void Trigger(bool status)
            {
                if (!hasInitted && this.status == status) return;

                hasInitted = true;
                this.status = status;
                actions?.Invoke(status);
            }

            public void Reset()
            {
                hasInitted = false;
                actions = null;
            }
        }
    }

    
}
