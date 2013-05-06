using System.IO;
using System.Linq;
using System.Windows.Forms;
using Shortcuts.Resources;

namespace Shortcuts.Handlers
{
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

            var files = info.GetFiles("*.shortc", SearchOption.AllDirectories)
                .OrderBy(x => x.Name)
                .Select((x, i) => new FileReference(x, i))
                .ToDictionary(x => x.Id);

            foreach (var reference in files.Values)
            {
                _Console.WriteLine("{0:D4} {1}",reference.Id,Path.GetFileNameWithoutExtension(reference.FileInfo.FullName));
            }

            _Console.WriteLine("Indtast talkode for at kopiere");
            var result = _Console.ReadLine();
            int id;
            int.TryParse(result, out id);

            using (var file = new StreamReader(files[id].FileInfo.OpenRead()))
            {
                var fileContent = file.ReadToEnd();
                _Console.WriteLine(string.Format("{0}", fileContent));
                Clipboard.SetText(fileContent);
            }
        }
    }

    public class FileReference
    {
        public FileInfo FileInfo { get; set; }
        public int Id { get; set; }

        public FileReference(FileInfo fileInfo, int id)
        {
            FileInfo = fileInfo;
            Id = id;
        }
    }
}