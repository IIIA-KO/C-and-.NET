using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Harvester : AgriculturalTransport
    {
        private Harvester(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public Harvester() : this("Сільськогосподарська Техніка", "Комбайн", 8, 4) { }
    }
}
