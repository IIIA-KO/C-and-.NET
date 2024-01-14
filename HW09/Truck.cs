using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Truck : AutoTransport
    {
        private Truck(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Truck() : this("Автомобільний Транспорт", "Вантажівка", 75.0, 25) { }
    }
}
