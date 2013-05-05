using System;
using System.IO;

namespace Shortcuts.Handlers
{
    public class ListTextHandler : Handler
    {
        public ListTextHandler(string[] args) : base(args)
        {

        }

        public override void Handle()
        {
            var info = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Files"));
            foreach (var fileInfo in info.GetFiles("*.shortc", SearchOption.AllDirectories))
            {
                _Console.WriteLine(Path.GetFileNameWithoutExtension(fileInfo.FullName)); 
            }
        }
    }
}