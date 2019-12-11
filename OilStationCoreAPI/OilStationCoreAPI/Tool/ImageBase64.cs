using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.Tool
{
    public class ImageBase64
    {
        /// <summary>
        /// Image 转成 base64
        /// </summary>
        /// <param name="fileFullName"></param>
        public static string ImageToBase64(string fileRelativePath)
        {
            try
            {
            //    Bitmap bmp = new Bitmap(fileFullName);
            //    MemoryStream ms = new MemoryStream();
                var suffix = fileRelativePath.Substring(fileRelativePath.LastIndexOf('.') + 1,
                    fileRelativePath.Length - fileRelativePath.LastIndexOf('.') - 1).ToLower();
                //var suffixName = suffix == "png"
                //    ? ImageFormat.Png
                //    : suffix == "jpg" || suffix == "jpeg"
                //        ? ImageFormat.Jpeg
                //        : suffix == "bmp"
                //            ? ImageFormat.Bmp
                //            : suffix == "gif"
                //                ? ImageFormat.Gif
                //                : ImageFormat.Jpeg;

                //bmp.Save(ms, suffixName);
                //byte[] arr = new byte[ms.Length]; ms.Position = 0;
                //ms.Read(arr, 0, (int)ms.Length); ms.Close();
                string base64="data:image/"+suffix+";base64," +
                Convert.ToBase64String(System.IO.File.ReadAllBytes($"{Directory.GetCurrentDirectory()}{fileRelativePath}"));
                return base64;
            }
            catch
            {
                return null;
            }

        }
    }
}
