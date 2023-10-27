using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.AutoMapper;
using SocialNetwork.Business.Concrete;
using SocialNetwork.Core.Utilities.EmailHelper;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.DependencyResolvers
{
    public static class ServiceRegistration
    {
        public static void Create(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDAL, EFUserDAL>();
            
            // Cloudflare
            // Dependency Injection, Dependency Inversion, IOC
            // AddSingleton, AddScoped, AddTrasient
            services.AddTransient<IMailHelper, MailHelper>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
