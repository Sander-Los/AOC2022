using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class AOCDirectory
    {
        public string Name { get; set; }
        public bool isRoot = false;
        public List<AOCDirectory> Directories = new();
        public List<AOCFile> Files = new();
        public AOCDirectory Parent { get; set; }
        public int TotalSize { get; set; }
       
        public int GetFileSize()
        {
            var sum = 0;
            foreach(var dir in Directories)
            {
                sum += dir.GetFileSize();
            }
            TotalSize = sum + Files.Sum(x => x.Size);
            return TotalSize;
           
        }

        public List<AOCDirectory> GetDirectoriesWithMaxSize(int maxSize)
        {
            var result = new List<AOCDirectory>();

            if (this.TotalSize < maxSize)
            {
                result.Add(this);
            }
            foreach (var directory in Directories)
            {
                result.AddRange(directory.GetDirectoriesWithMaxSize(maxSize));
            }

            return result;
        }
    }
}
