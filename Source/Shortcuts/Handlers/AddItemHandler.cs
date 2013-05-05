using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shortcuts.Extensions;
using Shortcuts.Resources;

namespace Shortcuts.Handlers
{
    public class AddItemHandler : FileHandler
    {
        public readonly AddItemOptions Options;

        public AddItemHandler(AddItemOptions options)
            : this(options, Defaults.Default.FolderLocation)
        {
        }

        public AddItemHandler(AddItemOptions options, string folder)  : base(folder)
        {
            Options = options;
        }

        public override void Handle()
        {
            EnsureOptions();

            bool directoryIsNewlyCreated = false;
            var currentDirectory = GetAndEnsureDirectory(out directoryIsNewlyCreated);

            var names = Options.Name.Split(new string[]{"/","\\"},StringSplitOptions.RemoveEmptyEntries);

            var fileName = names.Last();
            var directories = names.Except(new List<string>{fileName});

            foreach (var name in directories)
            {
                var currentPath = Path.Combine(currentDirectory.FullName, name);
                
                currentDirectory = new DirectoryInfo(currentPath);
                
                if (!currentDirectory.Exists)
                    currentDirectory.Create();
            }

            var fileInfo = new FileInfo(Path.Combine(currentDirectory.FullName, fileName + ".shortc"));
            if (fileInfo.Exists)
                throw new InvalidOperationException(string.Format(Resources.Resources.AddItemHandler_NameAllreadyExists, Options.Name));
            using (var writer = new StreamWriter(fileInfo.Create()))
            {
                writer.WriteLine(Options.Text);
            }

            _Console.WriteLine(Resources.Resources.AddItemHandler_ShortcutCreated);
        }

        private void EnsureOptions()
        {
            if (Options.Name.IsEmpty())
            {
                _Console.WriteLine(Resources.Resources.AddItemHandler_AddName);
                Options.Name = _Console.ReadLine();
            }

            if (Options.Text.IsEmpty())
            {
                _Console.WriteLine(Resources.Resources.AddItemHandler_AddText);
                Options.Text = _Console.ReadLine();
            }
        }
    }
}