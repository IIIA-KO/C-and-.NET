using System.Text;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

try
{
    Task1();
    //Task2();
    //Task3();
    //Task4();
    //Task5();
    //Task6();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

static void Task1()
{
    //Дана последовательность непустых строк.
    //Используя метод Aggregate, получить строку, состоящую из начальных символов всех строк исходной последовательности

    string[] array = { "Lorem", "Ipsum", "Dolor", "Aset" };
    Console.WriteLine(string.Join('\t', array));

    var query = array.Aggregate(new StringBuilder(), (x, y) => x.Append(y[0]));
    Console.WriteLine(string.Join('\t', query));
}
static void Task2()
{
    //Дана целочисленная последовательность.
    //Используя метод Aggregate, найти произведение последних цифр всех элементов последовательности.
    //Чтобы избежать целочисленного переполнения, при вычислении произведения использовать вещественный числовой тип

    double[] arr = GenerateDoubleArray(100, 1000);
    Console.WriteLine(string.Join('\t', arr));

    var query = arr
        .Select(x => x % 10)
        .Aggregate(1.0, (x, y) => x * y);
    Console.WriteLine(String.Join('\t', query));
}
static void Task3()
{
    //Дано целое число N(> 0).
    //Используя методы Range и Sum, найти сумму 1 + (1 / 2) + … +(1 / N)(как вещественное число)

    Console.Write("Введіть ціле число N ( > 0): "); int N = int.Parse(Console.ReadLine());
    if (N <= 0) throw new Exception("Error: Unavailable value");

    double query = Enumerable.Range(1, N).Sum(i => 1.0 / i);
    Console.WriteLine(query);
}
static void Task4()
{
    //Дана целочисленная последовательность A.
    //Сгруппировать элементы последовательности A, оканчивающиеся одной и той же цифрой,
    //и на основе этой группировки получить последовательность строк вида «D: S»,
    //где D – ключ группировки(то есть некоторая цифра, которой оканчивается хотя бы одно из чисел последовательности A),
    //а S – сумма всех чисел из A, которые оканчиваются цифрой D.
    //Полученную последовательность упорядочить по возрастанию ключей

    int[] A = GenerateIntArray(100, 1000);
    Console.WriteLine(String.Join('\t', A));

    var query = A
        .GroupBy(e => e % 10)
        .OrderBy(e => e.Key);

    foreach (var item in query)
    {
        foreach (var item2 in item)
            Console.WriteLine(item2);
        Console.WriteLine(item.Key + ":" + item.Sum() + "\n");
    }
}
static void Task5()
{
    //Выходная последовательность содержит сведения о клиентах магазина.
    //Каждый элемент последовательности включает код клиента, ФИО, Дата покупки,
    //список покупок: название, цена, количество.
    //Вывести информацию о купленных товарах каждым клиентом, количество товаров, стоимость купленных товаров.
    //Проанализировать покупок по месяцам: количество и сумма покупки

    Client[] clients = new Client[10];
    clients[0] = new("Петро");
    clients[1] = new("Іван");
    clients[2] = new("Степан");
    clients[3] = new("Анна");
    clients[4] = new("Інна");
    clients[5] = new("Валентин");
    clients[6] = new("Олександр");
    clients[7] = new("Євгенія");
    clients[8] = new("Михайло");
    clients[9] = new("Дар'я");

    Console.WriteLine("Список клієнтів: ");
    for (int i = 0; i < clients.Length; i++) clients[i].Print();

    Console.WriteLine("\n\n[/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/][/]\n\n");
    var query = clients
        .GroupBy(e => e.Date.Month)
        .OrderBy(m => m.Key);

    foreach (var item in query)
    {
        Console.WriteLine("Місяць - " + item.Key);
        foreach (var item2 in item)
        {
            item2.Print();
        }
        Console.WriteLine($"Загальна к-ть товарів за місяць - {item.Sum(c => c.Count)}\nЗагальна сума товарів за місяць - {item.Sum(c => c.TotalPrice)}");
        Console.WriteLine(new String('=', 50));
        Console.WriteLine();
    }
}
static void Task6()
{
    //Обработка отдельных последовательностей для каждого года, присутствующего в исходных данных,
    //найти школу с наибольшим номером среди школ, которые окончили абитуриенты, поступившие в этом году,
    //и вывести год и найденный номер школы.
    //Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию номера года.
    //Указание. Использовать группировку по полю «год» и метод Max

    Entrant[] entrants = new Entrant[5];
    entrants[0] = new Entrant("Довженко");
    entrants[1] = new Entrant("Фітільов");
    entrants[2] = new Entrant("Лозов'ягін");
    entrants[3] = new Entrant("Франко");
    entrants[4] = new Entrant("Шевченко");

    Console.WriteLine("Список абітурієнтів: ");
    Console.WriteLine($"| Номер | Рік    | Прізвище        |");
    for (int i = 0; i < entrants.Length; i++) Console.WriteLine(entrants[i]);

    var query = entrants
        .GroupBy(e => e.EntranceYear)
        .ToList();

    foreach (var item in query)
        Console.WriteLine($"{item.Key} - {item.Max(i => i.SchoolNumber)}");
}

static int[] GenerateIntArray(int min = -10, int max = 10)
{
    Random random = new Random();
    int[] arr = new int[random.Next(5, 15)];
    for (int i = 0; i < arr.Length; i++)
        arr[i] = random.Next(min, max + 1);
    return arr;
}
static double[] GenerateDoubleArray(int min = -10, int max = 10)
{
    Random random = new Random();
    double[] arr = new double[random.Next(5, 15)];
    for (int i = 0; i < arr.Length; i++)
        arr[i] = random.Next(min, max + 1);
    return arr;
}

public class Client
{
    public int Code { get; set; }
    public string Name { get; set; }
    public DateTime Date = new();
    public int Count;
    public double TotalPrice;

    public List<Purchase> purchases;
    private Random random;

    public Client(string n)
    {
        random = new Random();

        Code = random.Next(100, 1000);
        Name = n;
        Date = GenRandomDate(new DateTime(2000, 10, 4), DateTime.Today, random);

        purchases = new();
        for (int i = 0; i < random.Next(3, 8); i++) purchases.Add(new());

        Count = purchases.Count;
        TotalPrice = purchases.Sum(p => p.Price);
    }

    public static DateTime GenRandomDate(DateTime from, DateTime to, Random random = null)
    {
        if (from >= to)
            throw new Exception("The parameter \"from\" must be smaller than the parameter \"to\"!");

        if (random == null)
            random = new Random();

        int daysDiff = (to - from).Days;
        return from.AddDays(random.Next(daysDiff));
    }

    public void Print()
    {
        Console.WriteLine($"| {Name,-10} | {Code,-5} | {Date:dd-MM-yyyy} |");
        for (int i = 0; i < purchases.Count; i++) Console.WriteLine(purchases[i]);
        Console.WriteLine($"Кількість товарів - {purchases.Count}\nЗагальна ціна товарів - {TotalPrice}");
        Console.WriteLine(new String('-', 50));
    }
}
public class Purchase
{
    public string Name { get; set; }
    public double Price { get; set; }

    private Random random;

    private string[] Names = { "Хліб", "Молоко", "Борошно", "Масло", "Гречка", "Олія", "Цукерки" };
    public Purchase()
    {
        random = new Random();
        Name = Names[random.Next(Names.Length)];
        Price = random.Next(10, 150);
    }

    public override string ToString() => $"| {Name,-10} | {Price,-5} |";
}

public class Entrant
{
    public int SchoolNumber { get; set; }
    public int EntranceYear { get; set; }
    public string Surname { get; set; }

    private Random random;

    public Entrant(string s)
    {
        random = new();
        SchoolNumber = random.Next(1, 101);
        EntranceYear = random.Next(DateTime.Now.Year - 1, DateTime.Now.Year + 1);
        Surname = s;
    }

    public override string ToString() => $"| {SchoolNumber,-5} | {EntranceYear,-6} | {Surname,-15} |";
}