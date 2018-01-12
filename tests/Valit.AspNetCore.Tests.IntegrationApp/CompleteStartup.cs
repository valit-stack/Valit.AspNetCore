﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Valit.AspNetCore.Tests.IntegrationApp
{
    public class CompleteStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddValit(ctx => 
            {
                ctx.WithStrategy(picker => picker.Complete);
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
