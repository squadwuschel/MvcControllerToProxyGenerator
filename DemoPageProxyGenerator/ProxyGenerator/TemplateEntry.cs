using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGenerator
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
