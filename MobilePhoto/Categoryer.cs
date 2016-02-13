using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace MobilePhoto
{
    public class Categoryer
    {
        public static void Category(String srcDir, String destDir)
        {
            var dir = new DirectoryInfo(srcDir);
            dir.GetFiles().ToList().ForEach(fileInfo =>
            {
                MoveFileTo(fileInfo, destDir);
            });
            dir.GetDirectories().ToList().ForEach(dirInfo =>
            {
                Category(dirInfo.FullName, destDir);
            });
        }

        private static void MoveFileTo(FileInfo srcFileInfo, String destDir)
        {
            string createDate = srcFileInfo.LastWriteTime.ToString("yyyyMM");
            string ext = srcFileInfo.Extension;
            string imagesExt = "jpg|jpeg|png";
            string vedioExt = "mp4|3gp";

            string path = destDir + @"\";
            if (Regex.IsMatch(ext, imagesExt, RegexOptions.IgnoreCase))
            {
                path += @"照片\" + createDate + @"\";
            }
            else if (Regex.IsMatch(ext, vedioExt, RegexOptions.IgnoreCase))
            {
                path += @"视频\" + createDate + @"\";
            }
            else
            {
                path += @"其他\" + createDate + @"\";
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            srcFileInfo.MoveTo(path + srcFileInfo.Name);
        }
    }
}
