namespace ProxyGenerator.Container
{
    /// <summary>
    /// Die generierten Proxyeigenschaften für einen Controller
    /// </summary>
    public class GeneratedProxyEntry
    {
        public GeneratedProxyEntry()
        {
            FilePath = string.Empty;
            FileContent = string.Empty;
            FileName = string.Empty;
        }

        public string FileName { get; set; }
        public string FileContent { get; set; }
        public string FilePath { get; set; }
    }
}
