using System;
using System.Collections.Generic;

namespace Memory
{
    class Item
    {
        private double num;

        public Item()
        {
            this.num = 0.0;
        }
        public Item(double num)
        {
            this.num = num;
        }

        public double Num
        {
            get { return this.num; }
            set { this.num = value; }
        }
    }
    class MemoryBase
    {
        private List<Item> items;

        public MemoryBase()
        {
            items = new List<Item>();
        }

        public void addItem(double num)
        {
            items.Add(new Item(fixNumber(num)));
        }
        public void removeItem(int idx)
        {
            try
            {
                if (idx >= items.Count || idx < 0) throw new Exception("Index aldaatai!");
                items.RemoveAt(idx);
            }
            catch (Exception e)
            {
                Console.WriteLine("Aldaa: " + e);
            }
        }
        public void itemMinus(int idx, double num)
        {
            try
            {
                if (idx >= items.Count || idx < 0) throw new Exception("Index aldaatai!");
                items[idx].Num = fixNumber(items[idx].Num - num);
            }
            catch (Exception e)
            {
                Console.WriteLine("Aldaa: " + e);
            }
        }
        public void itemPlus(int idx, double num)
        {
            try
            {
                if (idx >= items.Count || idx < 0) throw new Exception("Index aldaatai!");
                items[idx].Num = fixNumber(items[idx].Num + num);
            }
            catch (Exception e)
            {
                Console.WriteLine("Aldaa: " + e);
            }
        }
        public void print()
        {
            Console.WriteLine("-- Memory List --");
            for(int i = items.Count - 1; i >= 0 ; i--)
                Console.WriteLine($"{i}. {items[i].Num}");
        }
        public static double fixNumber(double val)
        {
            return Math.Round(val, 12, MidpointRounding.AwayFromZero);
        }
    }
}

namespace Naranbat
{
    class Calculator
    {
        private double num1, num2;
        private char op;
        public Memory.MemoryBase mem;
        public double Num1
        {
            get { return num1; }
            set { num1 = value; }
        }
        public double Num2
        {
            get { return num2; }
            set { num2 = value; }
        }
        public Calculator()
        {
            mem = new Memory.MemoryBase();
            num1 = 0;
            num2 = 0;
            op = ' ';
        }
        public double plus()
        {
            return Memory.MemoryBase.fixNumber(this.Num1 + this.Num2);
        }
        public double minus()
        {
            return Memory.MemoryBase.fixNumber(this.Num1 - this.Num2);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            int k = 1, idx;
            double num;
            while (k != 8)
            {
                Console.WriteLine("1. num1 + num2, 2. num1 - num2, 3. MS, 4. MC by index, 5. show M list, 6. M+ by index, 7. M- by index, 8. exit");
                k = int.Parse(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        Console.Write("Num 1: ");
                        calc.Num1 = double.Parse(Console.ReadLine());
                        Console.Write("Num 2: ");
                        calc.Num2 = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Hariu: {calc.plus()}");
                        break;
                    case 2:
                        Console.Write("Num 1: ");
                        calc.Num1 = double.Parse(Console.ReadLine());
                        Console.Write("Num 2: ");
                        calc.Num2 = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Hariu: {calc.minus()}");
                        break;
                    case 3:
                        Console.Write("Num: ");
                        num = double.Parse(Console.ReadLine());
                        calc.mem.addItem(num);
                        break;
                    case 4:
                        Console.Write("Index: ");
                        idx = int.Parse(Console.ReadLine());
                        calc.mem.removeItem(idx);
                        break;
                    case 5:
                        calc.mem.print();
                        break;
                    case 6:
                        Console.Write("Num: ");
                        num = double.Parse(Console.ReadLine());
                        Console.Write("Index: ");
                        idx = int.Parse(Console.ReadLine());
                        calc.mem.itemPlus(idx, num);
                        break;
                    case 7:
                        Console.Write("Num: ");
                        num = double.Parse(Console.ReadLine());
                        Console.Write("Idx: ");
                        idx = int.Parse(Console.ReadLine());
                        calc.mem.itemMinus(idx, num);
                        break;
                    default:
                        k = 8;
                        Console.WriteLine("Bye");
                        break;
                }
            }
        }
    }
}
