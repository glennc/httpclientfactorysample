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
        private ValuesService _valuesService;

        public IEnumerable<string> Values;

        public IndexModel(ValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        public async Task OnGet()
        {
            Values = await _valuesService.GetValues();
        }
    }
}
