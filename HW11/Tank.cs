using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    internal class Tank
    {
        private string Name { get; }
        private byte Ammunition { get; }
        private byte Armor { get; }
        private byte Maneuverability { get; }

        private static readonly Random random = new Random();

        public Tank(string name)
        {
            Name = name;
            Ammunition = (byte)random.Next(1, 101);
            Maneuverability = (byte)random.Next(1, 101);
            Armor = (byte)random.Next(1, 101);
        }
        public Tank(string name, byte am, byte ar, byte m)
        {
            Name = name;
            Ammunition = am;
            Maneuverability = ar;
            Armor = m;
        }

        public string GetCharacteristicks()
        {
            return $"|Ammunition - {Ammunition} | Armor - {Armor} | Maneuverability - {Maneuverability}|";
        }

        public override string ToString()
        {
            return $"|{Name,-7} | {Ammunition,-4} | {Armor,-4} | {Maneuverability,-4}|";
        }

        public static Tank operator *(Tank a, Tank b)
        {
            if (a.Armor == b.Armor && a.Ammunition == b.Ammunition && a.Maneuverability == b.Maneuverability)
                throw new Exception("Tanks are identical");

            if (a.Ammunition > b.Ammunition && a.Armor > b.Armor)
                return a;

            if (a.Ammunition > b.Ammunition && a.Maneuverability > b.Maneuverability)
                return a;

            if (a.Armor > b.Armor && a.Maneuverability > b.Maneuverability)
                return a;

            else return b;
        }
    }
}
