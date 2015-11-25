using ProxyGenerator.Container;

namespace ProxyGenerator.Builder
{
    public interface IProxyBuilderHttpCall
    {
        /// <summary>
        /// Den passenden HttpCall zusammenbauen und prüfen ob Post oder Get verwendet werden soll
        /// Erstellt wird: post("/Home/LoadAll", data) oder get("/Home/LoadAll?userId=" + id)
        /// </summary>
        string BuildHttpCall(ProxyMethodInfos methodInfo);
    }
}