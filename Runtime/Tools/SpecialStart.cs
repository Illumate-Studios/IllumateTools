using System;
using System.Collections.Generic;
using UnityEngine;

namespace Illumate.Tools
{
    /// <summary>
    /// For creating special start codes like OnConnect, OnGameStart
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SpecialStart
    {
        private static SpecialStart _instance;
        protected static SpecialStart Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SpecialStart();
                return _instance;
            }
        }

        private Dictionary<string, Starts> dict = new();

        /// <summary>
        /// Add specific start by name called "key"
        /// </summary>
        /// <param name="key"></param>
        /// <param name="specificStart"></param>
        public static void Add(string key, Action specificStart)
        {
            if (Instance.dict.TryGetValue(key, out Starts starts))
            {
                if (starts.hasInit)
                    specificStart.Invoke();
                else
                    starts.Add(specificStart);
            }
            else
            {
                Instance.dict.Add(key, new Starts(key, specificStart));
            }
        }

        /// <summary>
        /// Execute the actions added by the "key"
        /// </summary>
        /// <param name="key"></param>
        public static void Execute(string key)
        {
            Debug.Assert(Instance.dict.ContainsKey(key), $"There is no {nameof(SpecialStart)} called {key}");
            Instance.dict[key].Execute();
            Instance.dict.Remove(key);
        }

        private class Starts
        {
            public string name;
            public Action action;
            public bool hasInit = false;

            public Starts(string name, Action action)
            {
                this.name = name;
                this.action = action;
            }

            public void Add(Action action)
            {
                this.action += action;
            }

            public void Execute()
            {
                //Debug.Assert(!hasInit, $"SpecialStart \"{name}\" must be executed once");
                Debug.Log("Special start again " + name);
                hasInit = true;
                action?.Invoke();
            }
        }
    }

    /// <summary>
    /// Most used special starts
    /// </summary>
    public static class SpecialStartKeys
    {
        public const string CONNECT = "OnConnect";
        public const string GAMESTART = "OnGameStart";
    }
}