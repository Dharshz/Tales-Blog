using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Tales.AngularWeb.App_Start.Startup))]

namespace Tales.AngularWeb.App_Start
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            
            ConfigureStoreAuthentication(app);
        }

      
    }
}