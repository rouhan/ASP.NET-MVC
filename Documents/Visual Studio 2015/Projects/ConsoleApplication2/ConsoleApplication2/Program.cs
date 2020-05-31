using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            Program bn = new Program();
            string key = "0123456789ABCDEFFEDCBA9876543210";
            string un1 = "0A30DCA8";
            string atc1 = "01F5";
            byte[] atc = Encoding.ASCII.GetBytes(atc1);
            byte[] un = Encoding.ASCII.GetBytes(un1);


            bn.deriveSK_MK(key, atc, un);
        }
        private void deriveSK_MK(string mkac, byte[] atc, byte[] upn)
        {

            byte[] r = new byte[8];
            Array.Copy(atc, atc.Length - 2, r, 0, 2);
            Array.Copy(upn, upn.Length - 4, r, 4, 4);

            deriveCommonSK_SM(mkac, r);
        }
        private void deriveCommonSK_SM(string mksm, byte[] rand)
        {
            byte[] rl = new byte[8];
            Array.Copy(rand, rl, 8);
            rl[2] = (byte)0xf0;
            //byte[] skl = jceHandler.encryptData(rl, mksm);
            //byte[] rr = Arrays.copyOf(rand, 8);
            //rr[2] = (byte)0x0f;
            //byte[] skr = jceHandler.encryptData(rr, mksm);
            //Util.adjustDESParity(skl);
            //Util.adjustDESParity(skr);
            //return jceHandler.formDESKey(SMAdapter.LENGTH_DES3_2KEY, ISOUtil.concat(skl, skr));
        }
        public static byte[] concat(byte[] array1, byte[] array2)
        {
            byte[] concatArray = new byte[array1.Length + array2.Length];
            Array.Copy(array1, 0, concatArray, 0, array1.Length);
            Array.Copy(array2, 0, concatArray, array1.Length, array2.Length);
            return concatArray;
        }
        public static void adjustDESParity(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                bytes[i] = (byte)(b & 0xfe | (b >> 1 ^ b >> 2 ^ b >> 3 ^ b >> 4 ^ b >> 5 ^ b >> 6 ^ b >> 7 ^ 0x01) & 0x01);
            }
        }
    }
}
