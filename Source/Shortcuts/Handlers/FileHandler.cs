using System;
using System.IO;

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
}