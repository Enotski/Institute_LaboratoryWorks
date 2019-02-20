using System;
using OP_ClassLib;

namespace Laba_1
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Составить:");
                Console.WriteLine("1.Счет\n2.Накладную\n3.Квитанцию\n4.Выход");
                int key;
                while (!int.TryParse(Console.ReadLine(), out key)) { }
                Console.Clear();
                switch (key)
                {
                    case 1:
                        Bill newBill = new Bill();
                        newBill.SetBillConsole();
                        Console.Clear();
                        Console.WriteLine(newBill.Print());
                        Console.ReadKey();
                        break;
                    case 2:
                        Invoice newInoice = new Invoice();
                        newInoice.SetInvoiceConsole();
                        Console.Clear();
                        Console.WriteLine(newInoice.Print());
                        Console.ReadKey();
                        break;
                    case 3:
                        Reciept newReciept = new Reciept();
                        newReciept.SetRecieptConsole();
                        Console.Clear();
                        Console.WriteLine(newReciept.Print());
                        Console.ReadKey();
                        break;
                    case 4:
                        return;
                }
                Console.Clear();
            }
        }
    }
}
