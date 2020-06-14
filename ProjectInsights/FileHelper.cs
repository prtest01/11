﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInsights
{
    public class FileHelper
    {
        public static async Task<IList<string>> GetAuthorsFromFile(StreamReader output, string fileName)
        {
            var list = new List<string>();

            string line;
            while ((line = await output.ReadLineAsync()) != null)
            {
                if (line.Contains(fileName))
                {
                    string author = StringHelper.SanitizeGitBlameLine(line);
                    list.Add(author);
                }
            }

            return list;
        }

        public static ICollection<string> GetFiles(StreamReader output)
        {
            var files = new HashSet<string>();
            int count = 1;

            string line;
            while ((line = output.ReadLine()) != null)
            {
                if (count == Constants.StopCount && Constants.StopCount != -1) break;

                AddFile(files, line);
                count++;
            }

            return files;
        }

        public static void AddFile(HashSet<string> files, string line)
        {
            string extension = Path.GetExtension(line);
            bool includedDirectory = IsIncludedDirectory(line);

            if (extension == Constants.CSharpExtention && includedDirectory)
            {
                files.Add(line);
            }
        }

        static bool IsIncludedDirectory(string line) => Constants.ExcludedDirectories.Where(a => line.Contains(a)).Count() == 0;
    }
}
