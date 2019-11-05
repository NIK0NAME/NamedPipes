using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Pipes;

namespace Enun1Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            int posX, posY;
            NamedPipeClientStream npcs = new NamedPipeClientStream(".", "mi_pipe", PipeDirection.InOut);
            npcs.Connect();

            StreamReader s_read = new StreamReader(npcs);
            StreamWriter s_write = new StreamWriter(npcs);
        }
    }
}
