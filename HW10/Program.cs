//main
{

    String[] spamKeywords = { "spam", "bad" };
    int commentMaxLength = 40;
    ITextAnalyzer[] textAnalyzers1 = {
new SpamAnalyzer (spamKeywords),new NegativeTextAnalyzer (),new
TooLongTextAnalyzer (commentMaxLength)
};
    ITextAnalyzer[] textAnalyzers2 = {
new SpamAnalyzer (spamKeywords),
new TooLongTextAnalyzer (commentMaxLength),
new NegativeTextAnalyzer ()
};
    ITextAnalyzer[] textAnalyzers3 = {
new TooLongTextAnalyzer (commentMaxLength),
new SpamAnalyzer (spamKeywords),
new NegativeTextAnalyzer ()
};
    ITextAnalyzer[] textAnalyzers4 = {
new TooLongTextAnalyzer (commentMaxLength),
new NegativeTextAnalyzer (),
new SpamAnalyzer (spamKeywords)
};
    ITextAnalyzer[] textAnalyzers5 = {
new NegativeTextAnalyzer (),
new SpamAnalyzer (spamKeywords),
new TooLongTextAnalyzer (commentMaxLength)
};
    ITextAnalyzer[] textAnalyzers6 = {
new NegativeTextAnalyzer (),
new TooLongTextAnalyzer (commentMaxLength),
new SpamAnalyzer (spamKeywords) };

    // тестові коментарі
    String[] tests = new String[8];
    tests[0] = "This comment is so good.";                              // OK
    tests[1] = "This comment is so Loooooooooooooooooooooooooooong.";   // TOO_LONG
    tests[2] = "Very negative comment !!!! = (!!!!;";                   // NEGATIVE_TEXT
    tests[3] = "Very BAAAAAAAAAAAAAAAAAAAAAAAAD comment with: |;";      // NEGATIVE_TEXT or TOO_LONG
    tests[4] = "This comment is so bad ....";                           // SPAM
    tests[5] = "The comment is a spam, maybeeeeeeeeeeeeeeeeeeeeee!";    // SPAM or TOO_LONG
    tests[6] = "Negative bad :( spam.";                                 // SPAM or NEGATIVE_TEXT
    tests[7] = "Very bad, very neg = (, very ..................";       // SPAM or NEGATIVE_TEXT or TOO_LONG

    ITextAnalyzer[][] textAnalyzers = { textAnalyzers1, textAnalyzers2, textAnalyzers3, textAnalyzers4, textAnalyzers5, textAnalyzers6 };
    int numberOfAnalyzer;                                               // номер аналізатора, зазначений в ідентифікатор
                                                                        //textAnalyzers {№}
    int numberOfTest = 0;                                               // номер тесту, який відповідає індексу тестових коментарів
    foreach (String test in tests)
    {
        numberOfAnalyzer = 1;
        Console.Write("test #" + numberOfTest + ":");
        Console.WriteLine(test);
        foreach (ITextAnalyzer[] analyzers in textAnalyzers)
        {
            Console.Write(numberOfAnalyzer + ":");
            //Console.WriteLine(CheckLabels(analyzers, test));
            numberOfAnalyzer++;
        }
        numberOfTest++;
    }
}

enum Label { SPAM, NEGATIVE_TEXT, TOO_LONG, OK }

interface ITextAnalyzer
{
    public Label processText(String text);
}abstract class KeywordAnalyzer : ITextAnalyzer
{
    public Label processText(string text)
    {
        throw new NotImplementedException();
    }
}class SpamAnalyzer : KeywordAnalyzer, ITextAnalyzer
{
    private readonly string[] spamKeywords;

    public SpamAnalyzer(string[] spamKeywords)
    {
        this.spamKeywords = spamKeywords;
    }

    public Label processText(string text)
    {
        throw new NotImplementedException();
    }
}

class NegativeTextAnalyzer : KeywordAnalyzer, ITextAnalyzer
{
    protected virtual string[] GetKeywords()
    {
        return new string[0];
    }

    protected virtual Label GetLabel()
    {
        return new Label();
    }

    public Label processText(string text)
    {
        throw new NotImplementedException();
    }
}

class TooLongTextAnalyzer : ITextAnalyzer
{
    private int maxLength;

    public TooLongTextAnalyzer(int ml)
    {
        if (ml < 0) maxLength = 0;
        maxLength = ml;
    }

    public Label processText(string text)
    {
        throw new NotImplementedException();
    }
}