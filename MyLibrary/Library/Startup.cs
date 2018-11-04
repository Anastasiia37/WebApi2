// <copyright file="Startup.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using BusinessLogic.DataProvider;
using BusinessLogic.LibraryService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.DataProvider;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    /// <summary>
    /// Class for configuration
    /// </summary>
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
            /*services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IDataProvider, InMemoryDataProvider>();
            services.AddSingleton<LibraryContext, LibraryContext>();*/


            string con = "Server=(localdb)\\mssqllocaldb;Database=librarydb;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<IDataProvider, LibraryContext>(options => options.UseSqlServer(con));

            //services.AddDbContext<ILibraryContext, LibraryContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My First ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}