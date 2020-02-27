using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class InputOutput
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

        public int IdGenerator(List<int> ids)
        {
            int id = ids.Count + 1;
            return id;
        }
    }
}
