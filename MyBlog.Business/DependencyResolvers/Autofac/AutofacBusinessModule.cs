using Autofac;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories;

namespace MyBlog.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repositories
            builder.RegisterType<EfAboutMeRepository>().As<IAboutMeRepository>();
            builder.RegisterType<EfContactMeRepository>().As<IContactMeRepository>();
            builder.RegisterType<EfEducationRepository>().As<IEducationRepository>();
            builder.RegisterType<EfExperienceRepository>().As<IExperienceRepository>();
            builder.RegisterType<EfMyServiceRepository>().As<IMyServiceRepository>();
            builder.RegisterType<EfMyWorkRepository>().As<IMyWorkRepository>();
            builder.RegisterType<EfServiceRepository>().As<IServiceRepository>();
            builder.RegisterType<EfSkillRepository>().As<ISkillRepository>();
            builder.RegisterType<EfSocialMediaRepository>().As<ISocialMediaRepository>();
            builder.RegisterType<EfSummaryRepository>().As<ISummaryRepository>();
            builder.RegisterType<EfWorkRepository>().As<IWorkRepository>();
            builder.RegisterType<EfHomeRepository>().As<IHomeRepository>();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>();
            builder.RegisterType<EfRoleRepository>().As<IRoleRepository>();

            //Managers
            builder.RegisterType<AboutMeManager>().As<IAboutMeService>();
            builder.RegisterType<ContactMeManager>().As<IContactMeService>();
            builder.RegisterType<HomeManager>().As<IHomeService>();
            builder.RegisterType<MyServiceManager>().As<IMyServiceService>();
            builder.RegisterType<MyWorkManager>().As<IMyWorkService>();
            builder.RegisterType<SummaryManager>().As<ISummaryService>();
            builder.RegisterType<SkillManager>().As<ISkillService>();
            builder.RegisterType<EducationManager>().As<IEducationService>();
            builder.RegisterType<ExperienceManager>().As<IExperienceService>();
            builder.RegisterType<ServiceManager>().As<IServiceService>();
            builder.RegisterType<FileManager>().As<IFileService>();
            builder.RegisterType<WorkManager>().As<IWorkService>();
            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
        }
    }
}
