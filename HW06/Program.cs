try
{
    string password;
    Console.WriteLine("CREATE PASSWORD");
    Console.WriteLine("Password must be longer than 10 symbols\nPassword must contain at least one lowercase letter !\nPassword must contain at least one uppercase letter\nPassword must containt at least one special symbol ('!', '\"', '#', '$', '%', '&', ' \' ', '(', ')', '*', '+', '-', '.', '/', '@', '?')\nPassword must contain at least one number");
    Console.Write("Enter password: "); password = Console.ReadLine();

    TryPassword p = new TryPassword(password);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

class TryPassword
{
    private string _password;

    public bool Check_Password(string pass)
    {
        string upper = "QWERTYUIOPASDFGHJKLZXCVBNM";
        string lower = "qwertyuiopasdfghjklzxcvbnm";
        string numbers = "0123456789";
        string symbols = "!\\#$%&,()*+-./\"\'@~?";

        if (pass.Length < 10)
        {
            throw new Exception("Exception: Password is too short");
        }
        if (pass.IndexOfAny(numbers.ToCharArray()) == -1)
        {
            throw new Exception("Exception: Password doesn't contain numbers ('0', '1', '2', '3', '4', '5', '6', '7', '8', '9')");
        }
        if (pass.IndexOfAny(upper.ToCharArray()) == -1)
        {
            throw new Exception("Exception: Password doesn't contain uppercase letters");
        }
        if (pass.IndexOfAny(lower.ToCharArray()) == -1)
        {
            throw new Exception("Exception: Password doesn't contain lowercase letters");
        }
        if (pass.IndexOfAny(symbols.ToCharArray()) == -1)
        {
            throw new Exception("Exception: Password doesn't contain special symbols ('!', '\"', '#', '$', '%', '&', ' \' ', '(', ')', '*', '+', '-', '.', '/')");
        }
        return true;
    }

    public TryPassword(string pass)
    {
        if (Check_Password(pass))
        {
            Console.WriteLine("Your password was successfuly created !");
            _password = pass;
        }
    }
}