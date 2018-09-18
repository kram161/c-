using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWork
{
    public class BinFile
    {
        public byte[] Data { get; set; }
        public string Path { get; set; }

        public void Read()
        {
            FileStream file = new FileStream(Path, FileMode.Open);
            Data = new byte[file.Length];
            file.Read(Data, 0, (int)file.Length);
            file.Dispose();
        }
        public void Write()
        {
            FileStream file = new FileStream(Path, FileMode.Create);
            file.Write(Data, 0, Data.Length);
            file.Flush();
            file.Dispose();
        }
    }
}
