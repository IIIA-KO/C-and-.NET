Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

try
{
    Task1();
    //Task2();
    //Task3();
    //Task4();
    //Task6();
    //Task7();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static void Task1()
{
    //Дана целочисленная последовательность. Извлечь из нее все положительные
    //числа, сохранив их исходный порядок следования.

    int[] arr = GenerateArray();
    Console.WriteLine(String.Join('\t', arr));

    var query = arr.Where(i => i > 0);
    Console.WriteLine(String.Join('\t', query));
}
static void Task2()
{
    //Дана целочисленная последовательность.Извлечь из нее все нечетные
    //числа, сохранив их исходный порядок следования и удалив все вхождения
    //повторяющихся элементов, кроме первых.

    int[] arr = GenerateArray();
    Console.WriteLine(String.Join('\t', arr));

    var query = arr.Where((i) => i % 2 != 0).ToHashSet();
    Console.WriteLine(String.Join('\t', query));
}
static void Task3()
{
    //Дана целочисленная последовательность.Извлечь из нее все четные
    //отрицательные числа, поменяв порядок извлеченных чисел на обратный.

    int[] arr = GenerateArray();
    Console.WriteLine(String.Join('\t', arr));

    var query = arr.Where((i) => i < 0 && i % 2 == 0).Reverse();
    Console.WriteLine(String.Join('\t', query));
}
static void Task4()
{
    //Даны цифра D(целое однозначное число) и целочисленная
    //последовательность A. Извлечь из A все различные положительные числа,
    //оканчивающиеся цифрой D(в исходном порядке).

    int[] A = GenerateArray(-100, 100);
    Console.WriteLine(String.Join('\t', A));

    Console.Write("Введіть число D (0 <= D <= 9): "); int D = int.Parse(Console.ReadLine());
    if (D < 0 || D > 9)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        throw new Exception("Error: unavailable value");
    }

    var query = A.Where(i => i > 0 && i % 10 == D);
    Console.WriteLine(String.Join('\t', query));
}
static void Task6()
{
    //Даны целое число K(> 0) и строковая последовательность A. Из элементов
    //A, извлечь те строки, которые имеют длину >K и начинаются с заглавной латинской
    //буквы.

    string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a nisi felis. Fusce in leo urna. Sed ipsum nibh, pulvinar varius tortor id, efficitur tristique velit. Quisque quis hendrerit justo.";
    string[] A = lorem
        .Replace(".", "")
        .Replace(",", "")
        .Split(' ');

    Console.WriteLine(string.Join(' ', A));

    Console.Write("Введіть число K (0 < K): "); int K = int.Parse(Console.ReadLine());
    if (K <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        throw new Exception("Error: unavailable value");
    }

    var query = A.Where(s => s.Length > K && char.IsUpper(s[0]));
    Console.WriteLine(String.Join('\t', query));
}
static void Task7()
{
    //Исходная последовательность содержит сведения о клиентах фитнес - центра.
    //Найти элемент последовательности с минимальной продолжительностью занятий.
    //Вывести эту продолжительность, а также соответствующие ей год и номер месяца(в
    //указанном порядке на той же строке). Если имеется несколько элементов с
    //минимальной продолжительностью, то вывести данные того из них, который
    //является последним в исходной последовательности.

    Client[] сlients = new Client[10];

    Console.WriteLine("Список клієнтів: ");
    Console.WriteLine($"| Код   | Рік    |Місяць| Години |");
    for (int i = 0; i < сlients.Length; i++)
    {
        сlients[i] = new Client();
        Console.WriteLine(сlients[i]);
    }

    Console.WriteLine("Результат: ");
    var query = сlients.OrderByDescending(c => c.Hours).Last();
    Console.WriteLine(String.Join(',', query));
}

static int[] GenerateArray(int min = -10, int max = 10)
{
    Random random = new Random();
    int[] arr = new int[random.Next(5, 15)];
    for (int i = 0; i < arr.Length; i++)
        arr[i] = random.Next(min, max + 1);
    return arr;
}

public class Client
{
    private Random r;
    public int Code { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Hours { get; set; }

    public Client()
    {
        r = new Random();
        Code = r.Next(1, 1001);
        Year = r.Next(1970, DateTime.Now.Year + 1);
        Month = r.Next(1, 13);
        Hours = r.Next(5000);
    }

    public override string ToString() => $"| {Code, -5} | {Year, -6} | {Month, -4} | {Hours, -6} |";
}