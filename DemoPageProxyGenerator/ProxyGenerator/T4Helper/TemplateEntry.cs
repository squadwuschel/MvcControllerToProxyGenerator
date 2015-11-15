namespace ProxyGenerator.T4Helper
{
    public class TemplateEntry
    {
        public string Template { get; set; }
        public TemplateTypes TemplateType { get; set; }

        public TemplateEntry()
        {
            Template = string.Empty;
            TemplateType = TemplateTypes.AngularJsModule;
        }
    }
}
