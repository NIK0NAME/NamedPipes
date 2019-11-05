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

            posX = int.Parse(s_read.ReadLine());
            posY = int.Parse(s_read.ReadLine());

            String palabra = s_read.ReadLine();
            while (palabra.CompareTo("fin") == 0)
            {
                switch(palabra)
                {
                    case "up": posY -= 1; break;
                    case "down": posY += 1; break;
                    case "left": posX -= 1; break;
                    case "right": posX += 1; break;
                }
                palabra = s_read.ReadLine();
            }

            s_write.WriteLine(posX);
            s_write.WriteLine(posY);

            s_read.Close();
            s_write.Close();
        }
    }
}
