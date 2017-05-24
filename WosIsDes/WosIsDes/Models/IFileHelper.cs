using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WosIsDes.Models
{
    public interface IFileHelper
    {
        byte[] GetImageAsByteArray(string imageFilePath);
    }
}
