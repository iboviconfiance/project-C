using System;
using System.IO;

namespace Mindfulness
{
    // Small utility class for simple logging
    public static class Logger
    {
        private static readonly string LogFile = "mindfulness_log.txt";

        public static void AppendLog(string activityName, int durationSeconds, string extra = "")
        {
            try
            {
                string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activityName} | {durationSeconds}s";
                if (!string.IsNullOrEmpty(extra)) line += $" | {extra}";
                File.AppendAllText(LogFile, line + Environment.NewLine);
            }
            catch
            {
                // Don't crash the application if the write fails
            }
        }

        public static string ReadLog()
        {
            try
            {
                if (!File.Exists(LogFile)) return "(Aucun log)";
                return File.ReadAllText(LogFile);
            }
            catch (Exception ex)
            {
                return $"Erreur lecture log: {ex.Message}";
            }
        }
    }
}
