using APIProviders;
using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace MoviesLibrary
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
            services.AddHttpClient();
            services.AddDbContext<MovieContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);
            services.AddIdentity<UserRegistration, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MovieContext>();

            var setting = new SettingService(Configuration.GetValue<string>("FilmApiKey"));
            services.AddSingleton(i => setting);

            services.AddTransient<IApiMovieProvider, MovieProvider>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IFavouriteMovieService, FavouriteMovieService>();
            services.AddTransient<ICommentService, CommentService>();

            // add swagger;


            

           // services.AddSwaggerGen();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
