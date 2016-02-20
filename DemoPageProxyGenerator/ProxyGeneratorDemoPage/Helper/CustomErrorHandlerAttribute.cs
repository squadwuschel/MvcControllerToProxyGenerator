using System.Web.Mvc;

namespace ProxyGeneratorDemoPage.Helper
{
    /// <summary>
    /// Custom Error Handler der über der passenden Controller Funktion verwendet wird um unbehandelte Ausnahmen abzufangen.
    /// </summary>
    public class CustomErrorHandlerAttribute : HandleErrorAttribute
    {
        public bool IsAjaxCall { get; set; }

        public override void OnException(ExceptionContext context)
        {
            if (IsAjaxCall)
            {
                context.ExceptionHandled = true;
                var jsonResult = new JsonResult();
                jsonResult.Data = new {Message = context.Exception.Message , MessageType = "Error"};
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                jsonResult.ExecuteResult(context);
            }
            else
            {
                // if not an ajax request, continue with logic implemented by MVC -> html error page
                base.OnException(context);
            }
        }
    }
}