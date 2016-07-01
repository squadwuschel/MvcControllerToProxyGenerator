using System;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator
{
    public class FileHelper : IFileHelper
    {
        #region Member
        IProxyGeneratorFactoryManager Factory { get; set; }
        #endregion

        #region Konstruktor
        public FileHelper(IProxyGeneratorFactoryManager proxyGeneratorFactory)
        {
            Factory = proxyGeneratorFactory;
        }
        #endregion

        /// <summary>
        /// Zum Ermitteln des Hauptpfades des Webprojektes
        /// </summary>
        public string GetParentDirectory(string path, string pathNameToFind)
        {
            if (!path.Contains(pathNameToFind))
            {
                throw new Exception("The 'WebProjectPath' was not found, because the 'WebProjectName' was wrong.");
            }

            if (string.IsNullOrEmpty(path) || path.TrimEnd(System.IO.Path.DirectorySeparatorChar).EndsWith(pathNameToFind))
                return path;

            string parent = System.IO.Path.GetDirectoryName(path);

            if (path.Contains(pathNameToFind))
                return GetParentDirectory(parent, pathNameToFind);

            return parent;
        }

        /// <summary>
        /// Gibt zum übergebenen Dateinamen den Ausgabepfad zurück in dem die Proxy Dateien erstellt werden sollen.
        /// </summary>
        /// <param name="fileName">Der Dateiname der an den Pfad angehängt werden soll.</param>
        /// <param name="alternateOutputPath">Ein alternativer Ausgabepfad der übergeben werden kann</param>
        public string GetProxyFileOutputPath(string fileName, string alternateOutputPath)
        {
            var proxySettings = Factory.GetProxySettings();

            //Wenn ein alternativer Ausgabepfad übergeben wurde, dann die Datei hier ablegen und nicht bei der Standardausgabe
            if (!string.IsNullOrEmpty(alternateOutputPath))
            {
                var localPath = GetParentDirectory(proxySettings.FullPathToTheWebProject, proxySettings.WebProjectName);
                return System.IO.Path.Combine(localPath, alternateOutputPath, fileName);
            }

            if (!string.IsNullOrEmpty(proxySettings.ProxyFileOutputPath))
            {
                var localPath = GetParentDirectory(proxySettings.FullPathToTheWebProject, proxySettings.WebProjectName);
                return System.IO.Path.Combine(localPath, proxySettings.ProxyFileOutputPath, fileName);
            }

            return fileName;
        }

    }
}
