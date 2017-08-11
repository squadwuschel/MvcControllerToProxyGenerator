namespace ProxyGenerator.Interfaces
{
    public interface ILogManager
    {
        void AddMessage(string name, string message);
        string GetCompleteLogAsString(bool writelog);
    }
}