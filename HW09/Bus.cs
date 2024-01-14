using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Bus : PublicTransport
    {
        private Bus(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Bus() : this("Публічний Транспорт", "Автобус", 90.0, 37) { }
    }
}
