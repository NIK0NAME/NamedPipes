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

            Console.WriteLine("Introducir coordenadas");
            Console.Write("Posicion X: ");
            posX = int.Parse(Console.ReadLine());

            Console.Write("Posicion Y: ");
            posY = int.Parse(Console.ReadLine());

            StreamReader s_read = new StreamReader(npss);
            StreamWriter s_write = new StreamWriter(npss);

            s_write.WriteLine(posX);
            s_write.WriteLine(posY);

            String palabra = Console.ReadLine();
            while(palabra.CompareTo("fin") == 0)
            {
                s_write.WriteLine(palabra);
                palabra = Console.ReadLine();
            }

            posX = int.Parse(s_read.ReadLine());
            posY = int.Parse(s_read.ReadLine());

            Console.WriteLine("Coordenadas -> X: " + posX + " Y: " + posY);

            s_read.Close();
            s_write.Close();
        }
    }
}
