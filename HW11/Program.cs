using HW11;

const string t34 = "T-34";
const string pantera = "Pantera";


Tank[] tanks = new Tank[10];
for(int i = 0; i < 5; i++)
{
    tanks[i] = new Tank(t34);
    tanks[i + 5] = new Tank(pantera);
}

try
{
    for (int i = 0; i < 5; i++)
    {
        Tank tmp = tanks[i] * tanks[i + 5];
        Console.WriteLine($"{tanks[i]}  VERSUS  {tanks[i + 5]}");
        Console.WriteLine($"Winner is - {tmp}\n\n");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}