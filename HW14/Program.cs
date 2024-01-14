DateTime CurDate = DateTime.Today;

Client client1 = new("Петренко Петро Петрович", new(CurDate.Year, CurDate.Month, CurDate.Day), 1000, 5, 30);        //відсотки нараховуються
Client client2 = new("Іваненко Іван Іванович", new(CurDate.Year, CurDate.Month, CurDate.Day), 900, 10, 60);         //відсотки не нараховуються
Client client3 = new("Степаненко Степан Степанович", new(CurDate.Year, CurDate.Month, CurDate.Day), 5000, 8, 50);   //відсотки нараховуються
Client client4 = new("Гриценко Гриць Грицьович", new(CurDate.Year, CurDate.Month, CurDate.Day), 1500, 15, 90);      //відсотки нараховуються

Bank bank = new Bank();

bank.AddClient(client1);
bank.AddClient(client2);
bank.AddClient(client3);
bank.AddClient(client4);



foreach (Client c in bank.clients)
    if (c.account.Balance >= 1000)
        bank.DevidentEvent += c.GetDevidents;

foreach (Client c in bank.clients)
    bank.ShowClients += c.Print;


bank.PrintClients();

DateTime tmp = CurDate;
while (true)
{
    if (tmp == CurDate.AddYears(1)) break;


    tmp = tmp.AddDays(1);

    foreach (Client c in bank.clients)
        c.devident_term--;

    if (tmp.Day == 1)
    {
        Console.WriteLine($"Дата: {tmp:dd-MM-yyyy}");

        foreach (Client c in bank.clients)
            if (c.devident_term <= 0)
            {
                bank.DevidentEvent -= c.GetDevidents;
                c.devident_term = 0;
            }
        bank.PayDevidents();
        bank.PrintClients();
    }
}


delegate void DevidentDelegate();
delegate void ShowDelegate();

class Account
{
    public decimal Balance { get; set; }

    public Account() => Balance = 0;
    public Account(decimal sum) => Balance = sum;

    public void Put(decimal sum)
    {
        if (sum < 0) sum = Math.Abs(sum);
        Balance += sum;
    }

    public void Take(decimal sum)
    {
        if (Balance >= sum) Balance -= sum;
    }
}

class Client
{
    private readonly string PIB;
    DateTime DateOfAccountCreation;
    public Account account;
    public int percent, devident_term;

    public Client(string pib, DateTime date, decimal money, int p, int dt)
    {
        PIB = pib;
        DateOfAccountCreation = date;
        account = new Account(money);

        if (p > 100) percent = 100;
        else percent = p;

        devident_term = dt;
    }

    public void GetDevidents()
    {
        this.account.Balance = this.account.Balance + ((this.account.Balance / 100) * this.percent);
    }

    public void Print()
    {
        Console.WriteLine($"| {PIB,-30} | {DateOfAccountCreation:dd-MM-yyyy} | {account.Balance,10:N2} | {percent,4}% | {devident_term} |");
    }
}

class Bank
{
    public List<Client> clients;

    public Bank() => clients = new List<Client>();

    public void AddClient(Client client)
    {
        clients.Add(client);
    }

    public event ShowDelegate ShowClients;
    public void PrintClients()
    {
        Console.WriteLine("Список клієнтів: ");
        ShowClients();
        Console.WriteLine(new String('-', 100));
    }

    public event DevidentDelegate DevidentEvent;
    public void PayDevidents()
    {
        DevidentEvent?.Invoke();
    }
}