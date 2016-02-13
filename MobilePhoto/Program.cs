using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoto
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args == null || args.Length == 0)
            {
                System.Console.WriteLine("Please input source dir");
                return;
            }

            String srcDir = "";
            String destDir = "";

            if(args.Length == 1)
            {
                srcDir = args[0];
                destDir = System.Environment.CurrentDirectory;
            }
            else
            {
                srcDir = args[0];
                destDir = args[1];
            }

            Categoryer.Category(srcDir, destDir);

            System.Console.WriteLine("Finished!");
            System.Console.Read();
        }
    }
}
