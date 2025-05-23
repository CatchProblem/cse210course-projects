public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = promptText;
        _entryText = entryText;
    }

}