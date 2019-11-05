using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Pipes;

namespace RepasoPipes
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int hb, db;

            NamedPipeServerStream npss = new NamedPipeServerStream("niko_pipe", PipeDirection.InOut, 4);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Esperando conexion...");

            npss.WaitForConnection();

            StreamWriter s_write = new StreamWriter(npss);
            StreamReader s_read = new StreamReader(npss);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conexion establecida");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Introducir valores (hb) la pasta que hay e (db) la pasta que se debe ;)");
            Console.Write("hb: ");
            hb = int.Parse(Console.ReadLine());
            Console.Write("db: ");
            db = int.Parse(Console.ReadLine());

            s_write.WriteLine(hb);
            s_write.WriteLine(db);

            

            String pal = leerPalabra();
            while(pal != "fin")
            {
                Console.Write("Importe: ");
                int importe = int.Parse(Console.ReadLine());
                s_write.WriteLine(pal);
                s_write.WriteLine(importe);
                pal = leerPalabra();
            }

            s_write.WriteLine(pal);

            hb = int.Parse(s_read.ReadLine());
            db = int.Parse(s_read.ReadLine());

            s_write.Close();
            s_read.Close();

            int saldo = hb - db;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Slado: " + saldo + " $");
        }

        static String leerPalabra()
        {
            String palabra = "";
            do
            {
                Console.Write("Introducir opcion: ");
                palabra = Console.ReadLine();
            } while (palabra != "fin" && palabra != "ingreso" && palabra != "reintegro");

            return palabra;
        }
    }
}
