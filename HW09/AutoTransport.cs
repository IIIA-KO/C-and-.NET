using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal abstract class AutoTransport : Transport
    {
        public AutoTransport(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }
    }
}
