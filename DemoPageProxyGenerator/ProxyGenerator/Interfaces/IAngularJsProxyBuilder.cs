﻿using System.Collections.Generic;
using ProxyGenerator.Container;
using ProxyGenerator.Manager;

namespace ProxyGenerator.Interfaces
{
    public interface IAngularJsProxyBuilder
    {
        List<GeneratedProxyEntry> BuildProxy(List<ProxyControllerInfo> proxyControllerInfos);
        IProxyGeneratorFactoryManager Factory { get; set; }
    }
}