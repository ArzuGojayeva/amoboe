﻿using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Eterna.Utilities.Extension
{
    public static class FileExtension
    {
        public static bool CheckFileType(this IFormFile file,string type)
        {
            return file.ContentType.Contains(type);
        }
        public static bool CheckFileSize(this IFormFile file,int size)
        {
            return file.Length / 1024 > size;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file,string root,string mainpath)
        {
            string uniqefilename=Guid.NewGuid().ToString()+ "_" +file.FileName;
            string path = Path.Combine(root, "admin", "images", mainpath, uniqefilename);
            FileStream stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return uniqefilename;
        }
    }
}
