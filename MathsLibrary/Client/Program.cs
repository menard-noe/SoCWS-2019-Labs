using Client.MathsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient client = new MathsOperationsClient("Mathieu");
            Console.WriteLine(client.Add(100, 101));
            Console.WriteLine(client.Multiply(100, 101));
            Console.ReadLine();
        }
    }
}
