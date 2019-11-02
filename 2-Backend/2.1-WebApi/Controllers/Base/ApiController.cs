using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        private readonly DomainNotificationHandler _notificationHandler;

        protected ApiController(INotificationHandler<DomainNotification> notificationHandler)
        {
            this._notificationHandler = (DomainNotificationHandler)notificationHandler;
        }

        protected IEnumerable<DomainNotification> Notifications => _notificationHandler.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notificationHandler.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {

            
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    statusCode = 200,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                statusCode =400,
                errors = _notificationHandler.GetNotifications().Select(n => n.Value)
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
            _notificationHandler.Handle(new DomainNotification(code, message), CancellationToken.None);
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
 