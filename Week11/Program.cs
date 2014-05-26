using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week11
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));
            bw.Write("조영호");
            bw.Write("국어");
            bw.Write(80);

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));

            string name = br.ReadString();
            string subject = br.ReadString();
            int score = br.ReadInt32();

            Console.WriteLine("{0}\t{1}\t{2}", name, subject, score);

            br.Close();
        }
    }
}
