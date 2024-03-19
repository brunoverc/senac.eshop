using MediatR;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.Services;
using Senac.eShop.Domain.Interfaces;
using Senac.eShop.Domain.Shared.Transaction;
using Senac.eShop.Infra.Data.Context;
using Senac.eShop.Infra.Data.Repositories;
using Senac.eShop.Infra.Data.UoW;
using System.Reflection;

namespace Senac.eShop.Infra.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatr();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            //Você deve adicionar para todos os projetos
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //services.AddMediatR(AppDomain.CurrentDomain.Load("Senac.eShop.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            //Você deve adicionar para todos os projetos
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EShopDbContext>();

            //Altera para suas classes de repositório
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IBasketAppService, BasketAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IPaymentMethodAppService, PaymentMethodAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IVoucherAppService, VoucherAppService>();
        }
    }
}
