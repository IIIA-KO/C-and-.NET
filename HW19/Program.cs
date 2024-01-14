Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

//-----------------------------------------MENU--------------------------------------------------------
string[] menuItems = new string[] { "Task 1", "Task 2", "Exit" };
int row = Console.CursorTop;
int col = Console.CursorLeft;
int index = 0;
try
{
    while (true)
    {
        DrawMenu(menuItems, row, col, index);
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.DownArrow:
                if (index < menuItems.Length - 1)
                    index++;
                break;
            case ConsoleKey.UpArrow:
                if (index > 0)
                    index--;
                break;
            case ConsoleKey.Enter:
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        Task1();
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        Task2();
                        Console.Clear();
                        break;
                    case 2:
                        return;
                }
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
static void DrawMenu(string[] items, int row, int col, int index)
{
    Console.SetCursorPosition(col, row);
    for (int i = 0; i < items.Length; i++)
    {
        if (i == index)
        {
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.WriteLine(items[i]);
        Console.ResetColor();
    }
    Console.WriteLine();
}
//-----------------------------------------------------------------------------------------------------

static void Task1()
{
    string FileName = "Day17.txt";

    string[] menuItems = new string[] { "Save info to file", "Load info from file", "Exit" };
    int row = Console.CursorTop;
    int col = Console.CursorLeft;
    int index = 0;
    while (true)
    {
        DrawMenu(menuItems, row, col, index);
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.DownArrow:
                if (index < menuItems.Length - 1)
                    index++;
                break;
            case ConsoleKey.UpArrow:
                if (index > 0)
                    index--;
                break;
            case ConsoleKey.Enter:
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        Save(FileName);
                        Console.Clear();
                        break;

                    case 1:
                        Console.Clear();
                        Load(FileName);
                        Console.Clear();
                        break;

                    case 2:
                        return;
                }
                break;
        }
    }
    File.Delete(FileName);
}
static void Save(string fileName)
{
    if (File.Exists(fileName)) throw new Exception("Error: File already exists");

    using (FileStream stream = new FileStream(fileName, FileMode.Create))
    {
        using BinaryWriter bw = new BinaryWriter(stream, System.Text.Encoding.UTF8);

        Console.WriteLine("Enter some data to save it: ");
        Console.Write("Enter name: "); string name = Console.ReadLine();
        Console.Write("Enter surname: "); string surname = Console.ReadLine();
        Console.Write("Enter patronymic: "); string patronymic = Console.ReadLine();

        Console.Write("Enter day of birth: "); int day = int.Parse(Console.ReadLine());
        Console.Write("Enter month of birth: "); int month = int.Parse(Console.ReadLine());
        Console.Write("Enter year of birth: "); int year = int.Parse(Console.ReadLine());
        if (day <= 0) day = 1;
        if (month <= 0) month = 1;
        DateTime birthday = new DateTime(year, month, day);

        FileStruct file = new FileStruct(name, surname, patronymic, birthday);

        bw.Write(surname);
        bw.Write(name);
        bw.Write(patronymic);
        bw.Write(birthday.Day);
        bw.Write(birthday.Month);
        bw.Write(birthday.Year);

        bw.Write(file.DoubleMatrix.GetLength(0));
        bw.Write(file.DoubleMatrix.GetLength(1));

        for (int i = 0; i < file.DoubleMatrix.GetLength(0); i++)
            for (int j = 0; j < file.DoubleMatrix.GetLength(1); j++)
                bw.Write(file.DoubleMatrix[i, j]);

        bw.Write(file.IntegerMatrix.GetLength(0));
        bw.Write(file.IntegerMatrix.GetLength(1));

        for (int i = 0; i < file.IntegerMatrix.GetLength(0); i++)
            for (int j = 0; j < file.IntegerMatrix.GetLength(1); j++)
                bw.Write(file.IntegerMatrix[i, j]);

        bw.Write(file.CurrenTade.Day);
        bw.Write(file.CurrenTade.Month);
        bw.Write(file.CurrenTade.Year);
    }
}
static void Load(string fileName)
{
    if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);

    using (FileStream stream = new FileStream(fileName, FileMode.Open))
    {
        using BinaryReader br = new BinaryReader(stream, System.Text.Encoding.UTF8);

        string surname = br.ReadString();
        Console.WriteLine(surname);

        string name = br.ReadString();
        Console.WriteLine(name);

        string patronymic = br.ReadString();
        Console.WriteLine(patronymic);

        int bd = br.ReadInt32();
        int bm = br.ReadInt32();
        int by = br.ReadInt32();
        DateTime birth = new(by, bm, bd);
        Console.WriteLine($"{birth:dd-MM-yyyy}");

        int drow = br.ReadInt32();
        int dcol = br.ReadInt32();
        double[,] DMatrix = new double[drow, dcol];
        Console.WriteLine("Double Matrix: ");
        for (int i = 0; i < drow; i++)
        {
            for (int j = 0; j < dcol; j++)
            {
                DMatrix[i, j] = br.ReadDouble();
                Console.Write(DMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int irow = br.ReadInt32();
        int icol = br.ReadInt32();
        int[,] IMatrix = new int[irow, icol];
        Console.WriteLine("Integer Matrix: ");
        for (int i = 0; i < irow; i++)
        {
            for (int j = 0; j < icol; j++)
            {
                IMatrix[i, j] = br.ReadInt32();
                Console.Write(IMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int cd = br.ReadInt32();
        int cm = br.ReadInt32();
        int cy = br.ReadInt32();
        DateTime today = new(cy, cm, cd);
        Console.WriteLine($"{today:dd-MM-yyyy}");
    }
    Console.WriteLine("Press any key...");
    Console.ReadKey();
}

static void Task2()
{
    string FileName = "Code.txt";

    string code = string.Join("\n", File.ReadLines(FileName));
    Console.WriteLine("Code:\n" + code);

    string[] res = code.Split(' ');
    for (int i = 0; i < res.Length; i++)
        if (res[i].Length >= 3)
            res[i] = res[i].ToUpper();
    code = String.Empty;
    foreach (string s in res)
        code += (s + " ");
   
    string[] result = code
        .Replace("public", "private")
        .Split('\n', ' ', '\t')
        .Where(x => !string.IsNullOrWhiteSpace(x))
        .ToArray();

    for (int i = 0; i < result.Length; i++)
    {
        char[] arr = result[i].ToCharArray();
        Array.Reverse(arr);
        result[i] = new string(arr);
    }
    File.WriteAllLines("ReverseCode.txt", result);

    Console.WriteLine("\n\nPress any key...");
    Console.ReadKey();
}

struct FileStruct
{
    public int[,] IntegerMatrix;
    public double[,] DoubleMatrix;
    public string Name, Surname, Patronymic;
    public DateTime BirthDay, CurrenTade = DateTime.Today;
    Random random = new Random();

    public FileStruct(string name, string surname, string patronymic, DateTime bd)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        BirthDay = bd;

        int r = random.Next(2, 6);
        int c = random.Next(2, 6);
        IntegerMatrix = new int[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                IntegerMatrix[i, j] = random.Next(1, 5);

        r = random.Next(2, 6);
        c = random.Next(2, 6);
        DoubleMatrix = new double[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                DoubleMatrix[i, j] = Math.Round(random.NextDouble() * (5 - 1) + 1, 1);
    }
}