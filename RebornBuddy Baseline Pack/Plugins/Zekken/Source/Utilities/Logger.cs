using System.Windows.Media;
using ff14bot.Helpers;

namespace Zekken
{
    internal static class Logger
    {
        private static readonly Color errorColor = Color.FromRgb(255, 66, 66);
        private static readonly Color messageColor = Color.FromRgb(201, 115, 255);

        public static void WriteError(string text, params object[] args)
        {
            Log(errorColor, text, args);
        }

        public static void WriteMessage(string text, params object[] args)
        {
            Log(messageColor, text, args);
        }

        public static void Log(Color color, string text, params object[] args)
        {
            text = "[Zekken] " + string.Format(text, args);
            Logging.Write(color, text);
        }
    }
}
