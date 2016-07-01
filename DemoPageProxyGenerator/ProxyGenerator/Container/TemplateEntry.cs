using ProxyGenerator.Enums;

namespace ProxyGenerator.Container
{
    public class TemplateEntry
    {
        #region Member
        /// <summary>
        /// Das Template für die Ausgabe
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Der Template typ wie jQueryJs oder AngularJs oder AngularTs
        /// </summary>
        public TemplateTypes TemplateType { get; set; }

        /// <summary>
        /// Der Suffix der an den Namen des Controllers für den Service gehängt wird z.b. HomeSrv oder HomeService
        /// </summary>
        public string TemplateSuffix { get; set; }

        /// <summary>
        /// Es kann ein Globaler Ausgabepfad verwendet werden, oder der Pfad kann für jeden Templatetypen einzeln festgelegt werden.
        /// </summary>
        public string OutputPath { get; set; }
        #endregion

        #region Konstruktor
        public TemplateEntry()
        {
            Template = string.Empty;
            TemplateType = TemplateTypes.AngularJsModule;
            TemplateSuffix = string.Empty;
            OutputPath = string.Empty;
        }
        #endregion
    }
}
    