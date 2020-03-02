using System;
using System.Collections.Generic;
using System.Text;
using EpicTariff;
using EpicTariff.Data;

namespace EpicTariff.Interface
{
    public class InputOutput
    {
        public void Writer(string write)
        {
            Console.WriteLine(write);
        }

        public string Reader()
        {
            string read;
            read = Console.ReadLine();
            return read;
        }
    }
}
