using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Train
    {
        private readonly string number;     //Номер поїзда
        private double max_speed;           //Максимальна швидкість
        private uint wagons_count;          // Кількість вагонів
        private long items_count;           //Кількоість одиниць товару або вантажу, що перевозить потяг
        private decimal price;              //Ціна потяга


        //Статичні змінні, спільні для всіх об'єктів класу
        public readonly static string train_type = "Універсальний вантажний потяг";
        public readonly static int stuff_count = 5; //кількість працівників, що обслуговують потяг

        private static Random rnd = new Random();

        //Допоміжні функції
        private static char GetLetter()
        {
            return (char)rnd.Next(1040, 1066);
        }
        private static char GetNum()
        {
            return (char)rnd.Next(49, 58);
        }

        //Консрутори: стандартний та з визначенням усіх параметрів (окрім номера)
        public Train() : this(200, 6, 10000, 2000000) { }
        public Train(double max_sp, uint wag_count, long it_count, decimal price)
        {
            this.number = new string($"{GetLetter()}{GetLetter()}{GetNum()}{GetNum()}{GetNum()}{GetNum()}{GetLetter()}{GetLetter()}");

            if (max_sp < 25) this.max_speed = 25;               //найменша швидкість 25 км/год, найбільша - 250
            else if (max_sp > 250) this.max_speed = 250;
            else this.max_speed = max_sp;

            if (wag_count < 6) this.wagons_count = 6;                   //вагонів має бути щонайменше 6 шт.
            else this.wagons_count = wag_count;


            if (it_count < 10000) this.items_count = 10000;     //потяг має транспортувати щонайменше 10000 одиниць товару чи вантажу
            else this.items_count = it_count;

            if (price < 2000000) this.price = 2000000;          //наменша ціна на потяг - 2 млн. гривень
            else this.price = price;
        }

        //Методи доступу до закритих полів класу
        public string GetNumber()
        {
            return number;
        }
        public double GetMaxSpeed()
        {
            return max_speed;
        }
        public uint GetWagonsCount()
        {
            return wagons_count;
        }
        public long GetItemsCount()
        {
            return items_count;
        }
        public decimal GetPrice()
        {
            return price;
        }
        //setNumber немає, бо номер має бути незмінним
        public void SetMaxSpeed(double ms)
        {
            max_speed = ms;
        }
        public void SetWagonCount(uint wc)
        {
            wagons_count = wc;
        }
        public void SetLoadCapacity(long ic)
        {
            items_count = ic;
        }
        public void SetPrice(decimal p)
        {
            price = p;
        }


        //3 методи "управління класу"
        public long GetLoadCapacity()   //Скільки вантажу може перевозити потяг (у кілограмах). 1 вагон - приблизно 68 тон вантажу, окрім тих, в якомх машиністи (таких 2)
        {
            return (this.wagons_count - 2) * 68000;
        }
        public int GetWagonsVolume()    //Загальний об'єм вантажних вагонів потяга. 1 вагон - приблизно 140м кубічних
        {
            return (int)((this.wagons_count - 2) * 140);
        }
        public long GetTrainWeight()    //Загальна вага потяга (у кілограмах). 1 вагон - приблизно 26 тон
        {
            return this.wagons_count * 26000;
        }

        //Функція з передачею параметра по посиланню
        //Перевіряє температуру та корегує її (за необхідності )для
        //дотриманння правил збереження вантажу під час перевезення
        //нічого кращого в голову не прийшло ㄟ( ▔, ▔ )ㄏ
        public static double NormalizeTemperature(ref double cur_temperature, double normal_temperature)
        {
            if (cur_temperature < normal_temperature || cur_temperature > normal_temperature)
                cur_temperature = normal_temperature;
            return cur_temperature;
        }


        //Виведення інформації
        public void Print()
        {
            System.Console.WriteLine($"| {this.number,10} | {this.max_speed,5} | {this.wagons_count,4} | {this.items_count,8} | {this.price,10} |");
        }
    }
}
