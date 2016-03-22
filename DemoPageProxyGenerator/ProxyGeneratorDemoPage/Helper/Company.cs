using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace ProxyGeneratorDemoPage.Helper
{
    [TsClass]
    public class Company
    {
        public Company()
        {
            Name = String.Empty;
            Age = 0;
            ClientAccess = ClientAccess.All;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public ClientAccess ClientAccess { get; set; }
    }
}