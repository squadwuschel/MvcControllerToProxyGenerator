using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;

namespace ProxyGenerator.Builder
{
    public class ProxyBuilderHelper
    {
        #region Member
        public ProxySettings ProxySettings { get; set; }
        #endregion

        #region Konstruktor

        public ProxyBuilderHelper(ProxySettings proxySettings)
        {
            ProxySettings = proxySettings;
        }
        #endregion

        #region Public Functions

        #endregion
    }
}
