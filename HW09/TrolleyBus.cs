using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class TrolleyBus : PublicTransport
    {
        private TrolleyBus(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
        public TrolleyBus() : this("Публічний Транспорт", "Тролейбус", 75.0, 0) { }
    }
}
