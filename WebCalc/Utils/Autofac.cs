using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using DomainModels.Repository;
using System.Web.Mvc;
using NH = DomainModels.NHibernate;

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
            builder.RegisterType<NH.UserRepository>().As<IUserRepository>();
            builder.RegisterType<NH.ORRepository>().As<IOperationResultRepository>();
            builder.RegisterType<NH.OperationRepository>().As<IOperationRepository>();
            builder.RegisterType<NH.LikeRepository>().As<ILikeRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}