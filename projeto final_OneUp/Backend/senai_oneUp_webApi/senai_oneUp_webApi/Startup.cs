using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_oneUp_webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()

                .AddNewtonsoftJson(options =>
                {

                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services
                .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("oneUp-projetoFinal-Senai")),

                    ClockSkew = TimeSpan.FromMinutes(30),

                    ValidIssuer = "OneUp.webApi",

                    ValidAudience = "OneUp.webApi"
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "oneUp", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            services.Configure<ForwardedHeaderOptions>(options =>
            {
                options.KnowProxies.Add(IPAddress.Parse("54.221.50.225"));
            });

            // services.AddCors(options => {
            //     options.AddPolicy("CorsPolicy",
            //         builder =>
            //         {
            //             builder.WithOrigins("http://1up-company.cf/:3000",
            //                                 "http://1up-company.cf:3000",
            //                                 "http://1up-company.cf",
            //                                 "http://1upapplication-env.eba-neiizbvp.us-east-1.elasticbeanstalk.com"
            //                                 )
            //                                         .AllowAnyHeaders()
            //                                         .AllowAnyMethods()
            //                                         .AccessControlAllowOrigin();
            //         }
            //     );
            // });

            services.AddCors(options => 
                    {
                        options.AddPolicy("CorsPolicy",
                            builder => builder .AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader()
                            );
                    });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

          //  app.UseStaticFiles(new StaticFileOptions
           // {
           //     FileProvider = new PhysicalFileProvider(
//Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
//RequestPath = "/Resources"
//});

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.Json", "oneUp.webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseCors("CorsPolicy");
            
            app.UseCors(x => x
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
            );

            app.UseForwardedHeaders(new ForwardedHeaderOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
