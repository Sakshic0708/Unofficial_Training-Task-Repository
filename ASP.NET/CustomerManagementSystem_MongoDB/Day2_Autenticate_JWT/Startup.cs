using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Autenticate_JWT
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
            //var mongoConfig = Configuration.GetSection("MongoDB");
            //var client = new MongoClient(mongoConfig["ConnectionString"]);
            //var database = client.GetDatabase(mongoConfig["DatabaseName"]);
            services.AddAuthorization();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            //services.AddSingleton(database.GetCollection<User>("register"));
            //services.AddSingleton(database.GetCollection<Customer>("customer"));

            //services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
            var SecretKey = Configuration.GetSection("JWT:Secret");
            var Audience = Configuration.GetSection("JWT:ValidAudience");
            var Issuer = Configuration.GetSection("JWT:ValidIssuer");
            services.AddControllers();
            services.AddAuthorization();
            object value = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {

                     ValidateIssuerSigningKey = true,
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidIssuer = Issuer.Value,
                     ValidAudience = Audience.Value,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey.Value)),
                     ValidateLifetime = true,
                     RequireExpirationTime = false,

                     // Allow to use seconds for expiration of token
                     // Required only when token lifetime less than 5 minutes
                     // THIS ONE
                     ClockSkew = TimeSpan.Zero


                 };
             });
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
            });
        }
    }
}
