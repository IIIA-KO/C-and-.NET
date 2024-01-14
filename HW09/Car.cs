using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Car : AutoTransport
    {
        private Car(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Car() : this("Автомобільний Транспорт", "Машина", 80.0, 10) { }
    }
}