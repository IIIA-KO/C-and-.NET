using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal abstract class PublicTransport : Transport
    {
        public PublicTransport(string? type, string? name, double speed, double consumption) : base(type, name, speed, consumption) { }

        public override double CalculateFare(int distance)
        {
            return 10.0; //проїзд - 10 гривень
        }
    }
}
