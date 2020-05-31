using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisaCaller.Helper;

namespace VisaCaller
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Code trying to call visa api 
            //FundTransfer ft = new FundTransfer();
            //ft.TestPushFundsTransactions();
            HelloWorld hw = new HelloWorld();
            hw.TestHelloWorld();
            Console.Read();

        }
    }

}


