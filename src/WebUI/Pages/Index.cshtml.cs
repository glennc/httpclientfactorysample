using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Services;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private ValuesService _service;

        [BindProperty]
        public IEnumerable<string> Values { get; set; }

        public IndexModel(ValuesService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            Values = await _service.GetValues();
        }
    }
}
