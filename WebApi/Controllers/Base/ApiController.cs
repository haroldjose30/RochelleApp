using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Framework.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers.Base
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler notificationHandler;

        protected ApiController(INotificationHandler<DomainNotification> _notificationHandler)
        {
            notificationHandler = (DomainNotificationHandler)_notificationHandler;
        }

        protected IEnumerable<DomainNotification> Notifications => notificationHandler.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!notificationHandler.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = notificationHandler.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            try
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    NotifyError(string.Empty, erroMsg);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void NotifyError(string code, string message)
        {
            notificationHandler.Handle(new DomainNotification(code, message), CancellationToken.None);
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }
}
 