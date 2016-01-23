namespace ProxyGenerator
{
    /// <summary>
    /// Die verwendeten Const Values in den Templates
    /// </summary>
    static class ConstValuesTemplates
    {
        public const string ServiceName = "#ServiceName#";

        public const string PrototypeServiceCalls = "#PrototypeServiceCalls#";

        public const string ServiceParamters = "#ServiceParamters#";

        public const string ControllerFunctionName = "#ControllerFunctionName#";

        public const string ServiceCallAndParameters = "#ServiceCallAndParameters#";

        public const string InterfaceDefinitions = "#InterfaceDefinitions#";

        public const string ServiceFunctions = "#ServiceFunctions#";

        /// <summary>
        /// Achtung hier muss wird "{#" bzw. "#}" zum Maskieren verwendet, da wir im Template ein größer bzw. kleinerzeichen davor haben und es hier sonst Probleme mit dem T4 Template gibt.
        /// </summary>
        public const string ControllerFunctionReturnType = "{#ControllerFunctionReturnType#}";
    }
}
