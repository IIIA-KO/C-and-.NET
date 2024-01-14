using HW9;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

try
{
    Random r = new Random();
    int n = r.Next(1, 10);
    Transport[] arr = new Transport[n];
    double TotalSum = 0, TotalTime = 0;

    for (int i = 0; i < n; i++)
    {
        int j = r.Next(1, 10);
        switch (j)
        {
            case 1:
                arr[i] = new Bus();
                break;

            case 2:
                arr[i] = new TrolleyBus();
                break;

            case 3:
                arr[i] = new Tram();
                break;

            case 4:
                arr[i] = new Car();
                break;

            case 5:
                arr[i] = new Truck();
                break;

            case 6:
                arr[i] = new Motorcycle();
                break;

            case 7:
                arr[i] = new Scooter();
                break;

            case 8:
                arr[i] = new Tractor();
                break;

            case 9:
                arr[i] = new Harvester();
                break;

            default:
                break;
        }
    }

    Console.WriteLine("Список транспоту, який необхідно використати: ");
    foreach (Transport t in arr)
    {
        Console.WriteLine(t.Name);
    }
    Console.WriteLine();


    foreach (Transport t in arr)
    {
        int meteres = 0;
        Console.Write($"Введіть відстань, яку ви проїхали на {t.Name} у метрах: ");
        if (!int.TryParse(Console.ReadLine(), out meteres))
        {
            throw new Exception("Неправильно введене значення");
        }
        if (meteres < 0) meteres = Math.Abs(meteres);

        Console.WriteLine($"Ви проїхали {meteres} метрів на {t.Name} зі швидкістю {t.Speed:N2} км/год і витратили {t.CalculateFare(meteres):N2} гривень та {t.CalculateTime(meteres):N2} хвилин\n");

        TotalSum += t.CalculateFare(meteres);
        TotalTime += t.CalculateTime(meteres);
    }
    Console.WriteLine();

    Console.WriteLine($"Загалом витрачено {TotalSum:N2} гривень та {TotalTime:N2} хвилин");

    Console.WriteLine("Розрахунки проводяться з урахуванням того що:\n1) Ціна за літр бензину - 34,14 гривень\n2) Ціна проїзду на публічному транспорті - 10 гривень");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}