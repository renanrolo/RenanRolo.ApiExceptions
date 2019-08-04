using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Diagnostics;
using RenanRolo.ApiExceptions.Exceptions;
using RenanRolo.ApiExceptions.TratarLog;

namespace RenanRolo.ApiExceptions
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    //await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                    //await context.Response.WriteAsync("ERROR!<br><br>\r\n");
                    //await context.Response.WriteAsync(" Escreve alguma mensagem de erro aqui se precisar     ");
                    //await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                    //await context.Response.WriteAsync("</body></html>\r\n");
                    //await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    string excecaoMensagem = "";

                    if (exceptionHandlerPathFeature?.Error is NaoGravaLogException)
                    {
                        NaoGravaLogException ex = exceptionHandlerPathFeature?.Error as NaoGravaLogException;
                        excecaoMensagem = ex.Message;
                    }
                    else if (exceptionHandlerPathFeature?.Error is GravaLogException)
                    {
                        GravaLogException ex = exceptionHandlerPathFeature?.Error as GravaLogException;

                        GravarLog.Gravar(ex);

                        excecaoMensagem = ex.Message;
                    }
                    else //SystemException
                    {
                        GravarLog.Gravar(exceptionHandlerPathFeature?.Error);

                        excecaoMensagem = "SystemException";
                    }

                    await context.Response.WriteAsync($"{{\"Mensagem\": \"Deu Erro\", \"Exception\": \"{excecaoMensagem}\" }}");
                });
            });

            app.UseMvc();
        }
    }
}
