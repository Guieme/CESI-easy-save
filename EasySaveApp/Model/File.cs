using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveApp.Model
{
    //This class permit to classifiate all files to copy with differents checked to, for example, copy them , or crypt them ,etc
    internal class Files
    {
        public string Directory { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FullPath { get; set; }
        public DateTime LastModified { get; set; }
        public long FileSize { get; set; }
        //Constructor used to stock the file
        public Files(string name, string path, string extension, DateTime lastModified, long size, string directory)
        {
            Name = name;
            Directory = directory;
            Extension = extension;
            LastModified = lastModified;
            FileSize = size;
            FullPath = path;
        }
    }
}
