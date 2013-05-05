using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortcuts
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            JobRunner.Run(args);
            Console.ReadLine();
        }
    }
}
