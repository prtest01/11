﻿namespace ProjectInsights
{
    public class StringHelper
    {
        public static string SanitizeEmail(string line)
        {
            return line.Substring(0, line.IndexOf("@")).Replace(".", Constants.Space);
        }

        public static int GetInsertion(string[] metricLine)
        {
            return int.Parse(metricLine[1].Replace("insertions(+)", "").Replace("insertion(+)", "").Trim());
        }

        public static int GetRemoval(string[] metricLine)
        {
            return int.Parse(metricLine[2].Replace("deletions(-)", "").Replace("deletion(-)", "").Trim());
        }

        public static int GetChanges(string[] metricLine)
        {
            return int.Parse(metricLine[1].Replace("insertions(+)", "").Replace("insertion(+)", "").Replace("deletions(-)", "").Replace("deletion(-)", "").Trim());
        }
    }
}
