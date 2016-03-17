namespace ProxyGenerator.Interfaces
{
    public interface IFileHelper
    {
        /// <summary>
        /// Zum Ermitteln des Hauptpfades des Webprojektes
        /// </summary>
        string GetParentDirectory(string path, string pathNameToFind);

        /// <summary>
        /// Gibt zum übergebenen Dateinamen den Ausgabepfad zurück in dem die Proxy Dateien erstellt werden sollen.
        /// </summary>
        /// <param name="fileName">Der Dateiname der an den Pfad angehängt werden soll.</param>
        string GetProxyFileOutputPath(string fileName);
    }
}