using System;
using System.IO;
using System.Security.AccessControl;

namespace Shortcuts.Handlers
{
    public class ListHandler : Handler
    {
        private readonly string _folderName;

        /// <summary>
        /// Constructor
        /// </summary>
        public ListHandler() : this("Files")
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="folderName">The folder containing the files</param>
        public ListHandler(string folderName)
        {
            _folderName = folderName;
        }

        public override void Handle()
        {
            var info = GetAndEnsureDirectory();

            foreach (var fileInfo in info.GetFiles("*.shortc", SearchOption.AllDirectories))
            {
                _Console.WriteLine(Path.GetFileNameWithoutExtension(fileInfo.FullName)); 
            }
        }

        private DirectoryInfo GetAndEnsureDirectory()
        {
            var info = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _folderName));
            if (!info.Exists)
                info.Create();

            return info;
        }
    }
}