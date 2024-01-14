namespace Bankomat
{
    internal class Account
    {
        private static Random random = new Random();

        private uint number;
        private short code;
        private decimal money;

        public Account()
        {
            code = (short)random.Next(1000, 10000);
            number = (uint)random.Next(100000, 1000000);

            Console.Write("Скільки грошей ви бажаєте покласти на ваш рахунок: ");
            if (!decimal.TryParse(Console.ReadLine(), out money))
                throw new Exception("Непраивильно введена кількість грошей");

            if (money < 0) money *= -1;
        }

        public uint GetNumber()
        {
            return number;
        }
        public short GetCode()
        {
            return code;
        }
        public decimal GetMoney()
        {
            return money;
        }
        internal void SetMoney(decimal money)
        {
            this.money = money;
        }


        public void PrintAccount()
        {
            Console.WriteLine($"Номер - {number} / Гроші - {money} / Пароль - {code}|");
        }

        public bool EnterAccount()
        {
            int attemps = 0;
            short tmp_code = 0;

            Console.WriteLine("У вас є 3 спроби, щоб увійти банківський обліковий запис");

            while (tmp_code != code && attemps < 3)
            {
                Console.Write("Введіть пароль: ");
                if (!short.TryParse(Console.ReadLine(), out tmp_code))
                    throw new Exception("Неправильно введений пароль");

                attemps++;
            }

            if (tmp_code == code)
            {
                Console.WriteLine("Ви успішно увійшли у ваш обліковий запис");
                return true;
            }
            else throw new Exception("Ви втратили 3 спроби");
        }
    }


    internal class Client
    {
        Account account;
        string name = "";
        public Client()
        {
            Console.Write("Введіть ваше ім'я: "); name = Console.ReadLine();
            account = new Account();
        }

        public Account GetAccount()
        {
            return account;
        }
        public string GetName()
        {
            return name;
        }

        public void PrintClient()
        {
            Console.Write($"| Ім'я: {name} | Рахунок: ");
            account.PrintAccount();
        }
    }


    internal class Bank
    {
        Client client;
        public Bank()
        {
            client = new Client();
        }

        public Client GetClient()
        {
            return client;
        }

        public void PrintBank()
        {
            client.PrintClient();
        }

        public void Menu()
        {
            int choice = -1;
            decimal tmp_money = 0;
            while (true)
            {
                bool flag = true;
                int back_or_end = -1;

                Console.Clear();
                Console.Write("1) Показати баланс\n2) Поповнити рахунок\n3) Зняти гроші з рахунку\n4) Вихід\n");
                Console.WriteLine("Введіть ваш вибір: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                    throw new Exception("Некоректно введене значення");

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"На вашому рахунку зараз {client.GetAccount().GetMoney()} гривень");

                        Console.WriteLine("1) Повернутися в меню\n2) Вийти");
                        while (flag)
                        {
                            if (!int.TryParse(Console.ReadLine(), out back_or_end))
                                throw new Exception("Некоректно введене значення");

                            switch (back_or_end)
                            {
                                case 1:
                                    flag = false;
                                    continue;

                                case 2:
                                    Console.Clear();
                                    System.Environment.Exit(0);
                                    break;

                                default:
                                    throw new Exception("Недопустиме значення");

                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Введіть суму грошей, на яку необхідно поповнити ваш рахунок: ");
                        if (!decimal.TryParse(Console.ReadLine(), out tmp_money))
                            throw new Exception("Некоректно введене значення");
                        if (tmp_money < 0) tmp_money = Math.Abs(tmp_money);

                        client.GetAccount().SetMoney(client.GetAccount().GetMoney() + tmp_money);
                        Console.WriteLine("Ваш рахунок: ");
                        client.GetAccount().PrintAccount();

                        Console.WriteLine("1) Повернутися в меню\n2) Вийти");
                        while (flag)
                        {
                            if (!int.TryParse(Console.ReadLine(), out back_or_end))
                                throw new Exception("Некоректно введене значення");

                            switch (back_or_end)
                            {
                                case 1:
                                    flag = false;
                                    continue;

                                case 2:
                                    Console.Clear();
                                    System.Environment.Exit(0);
                                    break;

                                default:
                                    throw new Exception("Недопустиме значення");

                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Введіть суму грошей, яку необхідно зняти з вашого рахунка: ");
                        if (!decimal.TryParse(Console.ReadLine(), out tmp_money))
                            throw new Exception("Некоректно введене значення");

                        if (tmp_money < 0) tmp_money = Math.Abs(tmp_money);

                        if (tmp_money > client.GetAccount().GetMoney())
                        {
                            throw new Exception("На рахунку недостатньо коштів для проведення операції");
                        }

                        client.GetAccount().SetMoney(client.GetAccount().GetMoney() - tmp_money);
                        Console.WriteLine("Ваш рахунок: ");
                        client.GetAccount().PrintAccount();

                        Console.WriteLine("1) Повернутися в меню\n2) Вийти");
                        while (flag)
                        {
                            if (!int.TryParse(Console.ReadLine(), out back_or_end))
                                throw new Exception("Некоректно введене значення");

                            switch (back_or_end)
                            {
                                case 1:
                                    flag = false;
                                    continue;

                                case 2:
                                    Console.Clear();
                                    System.Environment.Exit(0);
                                    break;

                                default:
                                    throw new Exception("Недопустиме значення");

                            }
                        }
                        break;

                    case 4:
                        Console.Clear();
                        System.Environment.Exit(0);
                        break;

                    default:
                        throw new Exception("Недопустиме значення");
                }
            }
        }
    }
}
