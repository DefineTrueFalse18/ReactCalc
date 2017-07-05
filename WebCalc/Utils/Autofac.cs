using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using DomainModels.Repository;
using System.Web.Mvc;
using EF = DomainModels.EntityFramework;

namespace WebCalc.Utils
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<EF.UserRepository>().As<IUserRepository>();
            builder.RegisterType<EF.OperationResultRepository>().As<IOperationResultRepository>();
            builder.RegisterType<EF.LikeRepository>().As<ILikeRepository>();
            builder.RegisterType<EF.OperationRepository>().As<IOperationRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}