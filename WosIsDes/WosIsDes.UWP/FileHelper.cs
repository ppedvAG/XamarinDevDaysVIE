using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(WosIsDes.UWP.FileHelper))]
namespace WosIsDes.UWP
{
    class FileHelper : WosIsDes.Models.IFileHelper
    {
        public byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
    }
}