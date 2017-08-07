using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfApplication1
{
    public class FilesUtils
    {
        public static string GetFileName(string directory, IEnumerable<string> extensions, int fileIndex)
        {
            return Path.GetFileName(GetFilePath(directory, extensions, fileIndex));
        }

        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }
        public static string GetFilePath(string directory, IEnumerable<string> extensions, int fileIndex)
        {
            return Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).Where(f => extensions.Contains(System.IO.Path.GetExtension(f))).ToArray()[fileIndex];
        }

        public static int GetFilesCount(string directory, IEnumerable<string> extensions)
        {
            return Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).Count(f => extensions.Contains(System.IO.Path.GetExtension(f)));
        }
    }
}
