using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinqDay1
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}, name={Name}, age={Age}";
        }
        public override bool Equals(object? obj)
        {
           Employee employee= obj as Employee;
            if (employee == null)
            {
                return false;
            }
            return ID == employee.ID;
        }
        public override int GetHashCode()
        {
            return ID;
        }
    }
}
