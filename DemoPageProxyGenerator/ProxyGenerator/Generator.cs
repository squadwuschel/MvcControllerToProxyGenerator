using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;
using ProxyGenerator.Manager;

namespace ProxyGenerator
{
    public class Generator
    {
        #region Member
        private ProxySettings ProxySettings { get; set; }
        #endregion

        public Generator(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
        }

        public string AddAngularJsProxyGenerator()
        {
            



            return string.Empty;
        }



    }
}
