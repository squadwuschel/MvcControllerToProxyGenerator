using ProxyGenerator.Enums;

namespace ProxyGenerator.Interfaces
{
    public interface ISettingsManager
    {
        void LoadSettingsFromWebConfig();

        /// <summary>
        /// Setzt den alternativen Ausgabepfad für die Templates im passenden Template
        /// </summary>
        /// <param name="templateType"></param>
        string GetAlternateOutputpath(TemplateTypes templateType);
    }
}