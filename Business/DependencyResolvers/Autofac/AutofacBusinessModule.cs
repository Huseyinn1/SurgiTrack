using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnalAtreziManager>().As<IAnalAtreziService>();
            builder.RegisterType<EfAnalAtreziDal>().As<IAnalAtreziDal>();

            builder.RegisterType<AntiRefluManager>().As<IAntiRefluService>();
            builder.RegisterType<EfAntiRefluDal>().As<IAntiRefluDal>();

            builder.RegisterType<ApandisitManager>().As<IApandisitService>();
            builder.RegisterType<EfApandisitDal>().As<IApandisitDal>();

            builder.RegisterType<DiyafragmaHernisiManager>().As<IDiyafragmaHernisiService>();
            builder.RegisterType<EfDiyafragmaHernisiDal>().As<IDiyafragmaHernisiDal>();

            builder.RegisterType<EkstrofiVesikalisManager>().As<IEkstrofiVesikalisService>();
            builder.RegisterType<EfEkstrofiVesikalisDal>().As<IEkstrofiVesikalisDal>();

            builder.RegisterType<KolonPullThroughErkekManager>().As<IKolonPullThroughErkekService>();
            builder.RegisterType<EfKolonPullThroughErkekDal>().As<IKolonPullThroughErkekDal>();

            builder.RegisterType<KolonPullThroughKadinManager>().As<IKolonPullThroughKadinService>();
            builder.RegisterType<EfKolonPullThroughKadinDal>().As<IKolonPullThroughKadinDal>();

            builder.RegisterType<AmeliyatManager>().As<IAmeliyatService>();
            builder.RegisterType<EfAmeliyatDal>().As<IAmeliyatDal>();
            
            builder.RegisterType<HastaManager>().As<IHastaService>();
            builder.RegisterType<EfHastaDal>().As<IHastaDal>();

            builder.RegisterType<DoktorManager>().As<IDoktorService>();
            builder.RegisterType<EfDoktorDal>().As<IDoktorDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
