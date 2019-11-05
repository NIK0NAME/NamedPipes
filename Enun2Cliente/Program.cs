using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Pipes;

namespace Enun2Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            int hb, db;

            NamedPipeClientStream npcs = new NamedPipeClientStream(".", "niko_pipe", PipeDirection.InOut);

            npcs.Connect();

            StreamReader s_read = new StreamReader(npcs);
            StreamWriter s_write = new StreamWriter(npcs);
            s_write.AutoFlush = true;

            hb = int.Parse(s_read.ReadLine());
            db = int.Parse(s_read.ReadLine());

            String pal = s_read.ReadLine();
            while(pal != "fin")
            {
                int importe = int.Parse(s_read.ReadLine());

                if (pal == "ingreso")
                {
                    hb += importe;
                }else
                {
                    db += importe;
                }

                pal = s_read.ReadLine();
            }

            s_write.WriteLine(hb);
            s_write.WriteLine(db);

            npcs.Close();
        }
    }
}
