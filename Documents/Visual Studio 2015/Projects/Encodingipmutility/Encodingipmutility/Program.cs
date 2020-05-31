using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encodingipmutility
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = "C:\\Users\\asad\\Desktop\\Testipm.ipm";
            Encoding ebcdic = Encoding.GetEncoding("IBM037");
            //Read File 
            string text = File.ReadAllText(textFile, ebcdic);
            Console.WriteLine(text);
            Console.WriteLine();
            //byte[] barr = Encoding.ASCII.GetBytes(text);
            //byte[] bar2r =ConvertEbcdicToAscii(barr);

            //for (int loop = 0; loop < bar2r.Length - 1; loop++)
            //{
            //    Console.WriteLine( bar2r[loop]);
            //}
            string textFile2 = "C:\\Users\\asad\\Desktop\\Testipmout.ipm";

            File.WriteAllText(textFile2, text);

            Console.Read();
        }
        public static byte[] ConvertAsciiToEbcdic(byte[] asciiData)
        {
            // Create two different encodings. 
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037"); //Retutn Ebcdic Data 
            return Encoding.Convert(ascii, ebcdic, asciiData);
        }

        public static byte[] ConvertEbcdicToAscii(byte[] ebcdicData)
        {
            // Create two different encodings. 
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037"); //Retutn Ascii Data 
            return Encoding.Convert(ebcdic, ascii, ebcdicData);
        }
    }
}
