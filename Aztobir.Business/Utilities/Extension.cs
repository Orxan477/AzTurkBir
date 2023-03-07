using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Utilities
{
    public static class Extension
    {
        public static bool CheckType(IFormFile file, string type)
        {
            if (!file.ContentType.Contains("image/"))
            {
                return false;
            }
            return true;
        }
        public static bool CheckSize(IFormFile file, int size)
        {
            if (file.Length / 1024 > size)
            {
                return false;
            }

            return true;
        }
        public async static Task<string> SaveFileAsync(IFormFile file, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string rootpath = Path.Combine(root, folder, fileName);
            using (FileStream fileStream = new FileStream(rootpath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
