using System;
using System.IO;
using Shortcuts.Resources;

namespace Shortcuts.Handlers
{
    public abstract class FileHandler : Handler
    {
        private string _folderName;

        protected FileHandler(string folderName)
        {
            _folderName = folderName;
        }

        protected DirectoryInfo GetAndEnsureDirectory(out bool isNewlyCreated)
        {
            isNewlyCreated = false;
            var info = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _folderName));
            if (!info.Exists)
            {
                info.Create();
            }
            
            return info;
        }
    }

    public class ListHandler : FileHandler
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ListHandler() : this(Defaults.Default.FolderLocation)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="folderName">The folder containing the files</param>
        public ListHandler(string folderName) : base(folderName)
        {
            
        }

        public override void Handle()
        {
            bool isNewlyCreated;
            var info = GetAndEnsureDirectory(out isNewlyCreated);

            foreach (var fileInfo in info.GetFiles("*.shortc", SearchOption.AllDirectories))
            {
                _Console.WriteLine(Path.GetFileNameWithoutExtension(fileInfo.FullName));
            }
        }
    }
}