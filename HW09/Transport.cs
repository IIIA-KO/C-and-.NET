using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal abstract class Transport
    {
        public virtual string? Type { get; set; }
        public virtual string? Name { get; }
        public virtual double Speed { get; set; }
        public virtual double Consumption { get; set; }

        public const double PriceGasoline = 34.14; //ціна за літр бензина (або 95-й, або 92-й: точно не пам'ятаю)

        public Transport(string? type, string? name, double speed, double consumption)
        {
            Type = type;
            Name = name;
            Speed = speed;
            Consumption = consumption;
        }

        public virtual double CalculateFare(int distance)
        {
            double KiloMetrDistance = (double)distance / 1000;                  //розрахунок ціни витраченого бензину
            double OneKilometrConsumtion = (double)Consumption / 100;
            double OneKilometrFare = PriceGasoline * OneKilometrConsumtion;
            return OneKilometrFare * KiloMetrDistance;
        }
        public virtual double CalculateTime(int distance)
        {
            return (((double)distance / 1000) / (double)Speed) * 60; //розрахунок часу на поїздку в хвилинах (в залежності від проїханої відстані в метрах)
        }
        public virtual void Print()
        {
            Console.WriteLine($"| {Type,-25} | {Name,-15} | {Speed,-5:N2} | {Consumption,5} |");
        }
    }
}
