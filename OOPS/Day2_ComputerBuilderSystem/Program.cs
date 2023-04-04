using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_ComputerBuilderSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.CPU = "Intel Core i7";
            computer.RAM = 16;
            computer.HardDisk = 512;
            computer.GraphicsCard = "NVIDIA GeForce GTX 1660 Ti";
            computer.BuildComputer();

        }
    }
    public class Computer
    {
        private string cpu;
        private int ram;
        private int hardDisk;
        private string graphicsCard;

        public string CPU
        {
            get { return cpu; }
            set { cpu = value; }
        }

        public int RAM
        {
            get { return ram; }
            set { ram = value; }
        }

        public int HardDisk
        {
            get { return hardDisk; }
            set { hardDisk = value; }
        }

        public string GraphicsCard
        {
            get { return graphicsCard; }
            set { graphicsCard = value; }
        }

        public void BuildComputer()
        {
            // Code to build a computer
            Console.WriteLine(GraphicsCard);
        }
    }


}
