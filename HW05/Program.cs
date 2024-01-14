//ВАРІАНТ - 9

using HW5;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine($"+{new String('=', 100)}+");
Console.WriteLine("ПОТЯГ");
Console.WriteLine("Статичні поля: ");
Console.WriteLine($"Тип потяга: {Train.train_type}");
Console.WriteLine($"Кількість персоналу, що обслуговує потян: {Train.stuff_count}");
Console.WriteLine($"+{new String('=', 100)}+\n\n");




Console.WriteLine($"+{new String('=', 100)}+");
Train t;
double max_speed;
uint wagons_count;
long items_count;
decimal price;

t = new Train();
Console.WriteLine("Потяг сворений за допомогою стандартного конструктора: ");
t.Print();

Console.Write("Введіть максимальну швидкість для потяга (мінімум 25 км/год, максимум 250 км/год): ");
if (!double.TryParse(Console.ReadLine(), out max_speed))
{
    Console.WriteLine("Неправильно введене значення");
    return;
}

Console.Write("Введіть кількість вагонів для потяга (мінімум 6 штук): ");
if (!uint.TryParse(Console.ReadLine(), out wagons_count))
{
    Console.WriteLine("Неправильно введене значення");
    return;
}

Console.Write("Введіть кількість одиниць товару чи ваниажу, що транспортує потяг (мінімум 10000 одиниць): ");
if (!long.TryParse(Console.ReadLine(), out items_count))
{
    Console.WriteLine("Неправильно введене значення");
    return;
}

Console.Write("Введіть ціну потяга (мінімум 2 млн. гривень): ");
if (!decimal.TryParse(Console.ReadLine(), out price))
{
    Console.WriteLine("Неправильно введене значення");
    return;
}

Console.WriteLine("Потяг з вашими значеннями: ");
t = new Train(max_speed, wagons_count, items_count, price);
t.Print();
Console.WriteLine($"+{new String('=', 100)}+\n\n");




Console.WriteLine($"+{new String('=', 100)}+");
Console.WriteLine("Методи управління класом: ");
Console.WriteLine($"Вантажоємність потяга: {t.GetLoadCapacity()}");
Console.WriteLine($"Об'єм вантажних вагонів потяга: {t.GetLoadCapacity()}");
Console.WriteLine($"Вага потяга: {t.GetTrainWeight()}\n");

Console.WriteLine("Методи доступу до закритих полів класа: ");
Console.WriteLine($"Номер потяга: {t.GetNumber()}\n");
Console.WriteLine($"Максимальна швидкість потяга потяга: {t.GetMaxSpeed()}\n");
Console.WriteLine($"Кількість вагонів потяга: {t.GetWagonsCount()}\n");
Console.WriteLine($"Кількість одиницьтовару чи вантажу потяга: {t.GetItemsCount()}\n");
Console.WriteLine($"Ціна потяга: {t.GetPrice()}\n");
Console.WriteLine($"+{new String('=', 100)}+\n\n");




Console.WriteLine($"+{new String('=', 100)}+");
double temperature, norm;
Console.WriteLine("Метод з передачею парметра за посиланням: ");
Console.Write("Введіть поточну температуру повітря: ");
if (!double.TryParse(Console.ReadLine(), out temperature))
{
    Console.WriteLine("Неправильно введене значення");
    return;
}

Console.Write("Введіть температуру необхідну для зберігання товару у вагонах потяга під час перевезення: ");
if (!double.TryParse(Console.ReadLine(), out norm))
{
    Console.WriteLine("Неправильно введене значення");
    return;
}
temperature = Train.NormalizeTemperature(ref temperature, norm);

Console.WriteLine($"Поточна температура повітря: {temperature}");
Console.WriteLine($"+{new String('=', 100)}+\n\n");