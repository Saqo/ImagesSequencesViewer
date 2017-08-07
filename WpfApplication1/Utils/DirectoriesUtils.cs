using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfApplication1
{
    public class DirectoriesUtils
    {
        public static int DirectoriesWithFilesByExtensionsCount(string root, IEnumerable<string> extensions)
        {
            return Directory.GetDirectories(root).Count(x => Directory.EnumerateFiles(x, "*.*", SearchOption.TopDirectoryOnly).Any(y => extensions.Contains(System.IO.Path.GetExtension(y))));
        }

        public static IEnumerable<string> DirectoriesWithFilesByExtensions(string root, IEnumerable<string> extensions)
        {
            return Directory.GetDirectories(root).Where(x => Directory.EnumerateFiles(x, "*.*", SearchOption.TopDirectoryOnly).Any(y => extensions.Contains(System.IO.Path.GetExtension(y))));
        }
    }
}
