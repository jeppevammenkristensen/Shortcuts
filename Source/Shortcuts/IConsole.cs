namespace Shortcuts
{
    public interface IConsole
    {
        void WriteLine(string value, params object[] parameters);
        string ReadLine();
    }
}