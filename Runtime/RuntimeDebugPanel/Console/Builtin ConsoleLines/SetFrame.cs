using UnityEngine;

namespace Illumate.RuntimeDebugPanel
{
    public class SetFrame : RuntimeConsoleCommand
    {
        public override string Description => "Set Application.targetFrameRate";

        public override string Execute(string[] parameters)
        {
            if (parameters.Length > 0)
                return "Paramter 0 needed as an integer since its representing frame.";
            if (parameters.Length == 0)
                return "Paramter 0 must be an integer since its representing frame.";
            if (!int.TryParse(parameters[0], out int targetFrameRate))
                return "Please enter a number for frame number.";

            Application.targetFrameRate = targetFrameRate;
            return $"Target frame rate set to {Application.targetFrameRate}.";
        }
    }
}