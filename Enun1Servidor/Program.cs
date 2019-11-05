using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Pipes;

namespace Enun1Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            int posX, posY;

            NamedPipeServerStream npss = new NamedPipeServerStream("mi_pipe", PipeDirection.InOut);
            npss.WaitForConnection();

            StreamReader s_read = new StreamReader(npss);
            StreamWriter s_write = new StreamWriter(npss);

            
        }
    }
}
