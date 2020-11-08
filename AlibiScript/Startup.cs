using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlibiScript.Helpers;
using AlibiScript.Interface;
using AlibiScript.Model;
using AlibiScript.Repository;
using AlibiScript.Service;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AlibiScript
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //���U�x��Repository
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));

            //���U�Ҧ�������Service��Interface
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //�s����Ʈw
            services.AddDbContext<AlibiDBContext>(options => options.UseSqlServer(Configuration["AlibiConnection"]));

            //���UJwt Helper
            services.AddSingleton<IJwtHelper, JwtHelper>();

            //���U�[�K�M��
            services.AddScoped<IEncryptionAdapter, BcryptHash>();
            //services.AddTransient<IUserService, UserService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            //���UJwt
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                // �����ҥ��ѮɡA�^�����Y�|�]�t WWW-Authenticate ���Y�A�o�̷|��ܥ��Ѫ��Բӿ��~��]
                options.IncludeErrorDetails = true; // �w�]�Ȭ� true�A���ɷ|�S�O����

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                    // �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

                    // �@��ڭ̳��|���� Issuer
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetValue<string>("JwtSettings:Issuer"),

                    // �q�`���ӻݭn���� Audience
                    ValidateAudience = false,
                    //ValidAudience = "JwtAuthDemo", // �����ҴN���ݭn��g

                    // �@��ڭ̳��|���� Token �����Ĵ���
                    ValidateLifetime = true,

                    // �p�G Token ���]�t key �~�ݭn���ҡA�@�볣�u��ñ���Ӥw
                    ValidateIssuerSigningKey = false,

                    // "1234567890123456" ���ӱq IConfiguration ���o
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSettings:SignKey")))
                };
            });
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

            app.UseCors();

            app.UseAuthentication(); //������

            app.UseAuthorization(); //�A���v

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
