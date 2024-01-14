using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Motorcycle : MotoTransport
    {
        private Motorcycle(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Motorcycle() : this("Мото-транспорт", "Мотоцикл", 110, 6) { }
    }
}
