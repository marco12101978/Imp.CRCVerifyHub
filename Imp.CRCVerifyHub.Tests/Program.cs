using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imp.CRCVerifyHub.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("");
            Console.WriteLine("TESTE 1 CHECKSUN -> A8 A9");
            byte[] buffer = new byte[] { 0x16, 0x4F, 0x50, 0x4E, 0x17 };

            Array.ForEach(buffer, b => Console.Write($"{b:X2} "));
            Console.WriteLine($" CHECKSUN -> {Crc16.Services.ChecksumGenerator(algorithm: Crc16.Crc16Algorithm.Ccitt,bytes: buffer, start: 1,length: buffer.Length -1).ToString("X2").Insert(2, " ")}");

            Console.WriteLine("");
            Console.WriteLine("TESTE 2 CHECKSUN -> 39 63");
            buffer = new byte[] { 0x44, 0x53, 0x50, 0x30, 0x30, 0x30, 0x17 };

            Array.ForEach(buffer, b => Console.Write($"{b:X2} "));
            Console.WriteLine($" CHECKSUN -> {Crc16.Services.ChecksumGenerator(Crc16.Crc16Algorithm.Ccitt, buffer).ToString("X2").Insert(2, " ")}");


            Console.WriteLine("");
            Console.WriteLine("TESTE 3 CHECKSUN -> 38 B6");
            buffer = new byte[] { 0x44, 0x45, 0x58, 0x30, 0x30, 0x33, 0x30, 0x30, 0x30, 0x17 };

            Array.ForEach(buffer, b => Console.Write($"{b:X2} "));
            Console.WriteLine($" CHECKSUN -> {Crc16.Services.ChecksumGenerator(Crc16.Crc16Algorithm.Ccitt, buffer).ToString("X2").Insert(2, " ")}");


            Console.WriteLine("");
            Console.WriteLine("TESTE 3 CHECKSUN -> 1B D3");
            buffer = new byte[] { 0x44,0x53,0x50,0x30,0x33,0x32,0x20,0x20,0x20,0x20,0x49,0x4D,0x50,0x45,0x52,0x49,0x55,0x4D,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x46,0x72,0x6F,0x6E,0x74,0x42,0x6F,0x78,0x20,0x20,0x20,0x20,0x17 };

            Array.ForEach(buffer, b => Console.Write($"{b:X2} "));
            Console.WriteLine($" CHECKSUN -> {Crc16.Services.ChecksumGenerator(Crc16.Crc16Algorithm.Ccitt, buffer).ToString("X2").Insert(2, " ")}");

            Console.ReadKey();

        }
    }
}
