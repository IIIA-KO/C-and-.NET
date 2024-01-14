using Indexer;
using Bankomat;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

Task1();
Task2();

static void Task1()
{
    Console.WriteLine($"+{new string('=', 100)}+");
    int min, max;

    try
    {
        Console.Write("Введіть мінімальне значення для індексатора: ");
        if (!int.TryParse(Console.ReadLine(), out min))
            throw new Exception("Некоректно введене значення");

        Console.Write("Введіть мінімальне значення для індексатора: ");
        if (!int.TryParse(Console.ReadLine(), out max))
            throw new Exception("Некоректно введене значення");

        Console.WriteLine("Значення індексів масиву цілих чисел: ");
        RangeOfArray roa = new RangeOfArray(min, max);
        for (int i = roa.getMin(); i <= roa.getMax(); i++)
        {
            roa[i] = i;
        }

        for (int j = roa.getMin(); j <= roa.getMax(); j++)
        {
            Console.WriteLine(roa[j]);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.WriteLine($"+{new string('=', 100)}+");
}

static void Task2()
{
    Console.WriteLine($"+{new string('=', 100)}+");
    try
    {
        Bank b = new Bank();
        Console.WriteLine("Інформація про ваш рахунок, нікому її не показуйте");
        b.PrintBank();
        if (b.GetClient().GetAccount().EnterAccount())
        {
            b.Menu();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.WriteLine($"+{new string('=', 100)}+");
}