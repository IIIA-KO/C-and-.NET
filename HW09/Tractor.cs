using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Tractor : AgriculturalTransport
    {
        private Tractor(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Tractor() : this("Сільськогосподарська Техніка", "Трактор", 55.0, 15) { }
    }
}
