using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Tram : PublicTransport
    {
        private Tram(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Tram() : this("Публічний Транспорт", "Трамвай", 14.0, 0) { }
    }
}
