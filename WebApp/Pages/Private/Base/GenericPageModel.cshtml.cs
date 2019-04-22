using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Private.Base
{
    public class GenericPageModelModel : PageModel
    {

        [BindProperty]
        public ErrorMessage errorMessage { get; set; } = new ErrorMessage();
       
    }

    public class ErrorMessage
    {
        public bool Success { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
