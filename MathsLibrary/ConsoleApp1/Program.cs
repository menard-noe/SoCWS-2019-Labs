﻿using ConsoleApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient client = new MathsOperationsClient("BasicHTTP");

            //MathsOperationsClient client = new MathsOperationsClient();
            Console.WriteLine(client.Add(100, 101));
            Console.WriteLine(client.Multiply(100, 101));
            Console.ReadLine();
        }
    }
    
}
