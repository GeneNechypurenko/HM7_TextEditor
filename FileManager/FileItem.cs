using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime LastWriteTime { get; set; }
        public FileItem(string name, string type, DateTime lastWriteTime)
        {
            Name = name;
            Type = type;
            LastWriteTime = lastWriteTime;
        }
    }
}
