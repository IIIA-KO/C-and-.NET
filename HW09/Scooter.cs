using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Scooter : MotoTransport
    {
        private Scooter(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Scooter() : this("Мото-транспорт", "Скутер", 85, 2.5) { }
    }
}
