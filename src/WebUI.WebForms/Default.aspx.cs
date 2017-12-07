using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Services;

namespace WebUI.WebForms
{
    public partial class _Default : Page
    {
        ValuesService ValuesService { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            ValuesService = Global.ServiceProvider.GetRequiredService<ValuesService>();

            RegisterAsyncTask(new PageAsyncTask(LoadData));
        }

        async Task LoadData()
        {
            repeater.DataSource = await ValuesService.GetValues();
            repeater.DataBind();
        }
    }
}