using ProxyGenerator.Enums;

namespace ProxyGenerator.Container
{
    public class TemplateEntry
    {
        public string Template { get; set; }
        public TemplateTypes TemplateType { get; set; }

        /// <summary>
        /// Der Suffix der an den Namen des Controllers für den Service gehängt wird z.b. HomeSrv oder HomeService
        /// </summary>
        public string TemplateSuffix { get; set; }

        public TemplateEntry()
        {
            Template = string.Empty;
            TemplateType = TemplateTypes.AngularJsModule;
            TemplateSuffix = string.Empty;
        }
    }
}
    