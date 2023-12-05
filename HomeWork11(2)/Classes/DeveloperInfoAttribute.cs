using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_2_.Classes
{
    internal class DeveloperInfoAttribute : Attribute
    {
        public string Name {  get; private set; }
        public DateTime Date { get; private set; }

        public DeveloperInfoAttribute(string name, string date)
        {
            Name = name;
            Date = DateTime.Parse(date);
        }

        public override string ToString()
        {
            return $"{Name} {Date}";
        }
    }
}
