using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependecyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>().SingleInstance();
            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();
            builder.RegisterType<EfTeacherDal>().As<ITeacherDal>().SingleInstance();
            builder.RegisterType<TeacherManager>().As<ITeacherService>().SingleInstance();
            builder.RegisterType<EfClassDal>().As<IClassDal>().SingleInstance();
            builder.RegisterType<ClassManager>().As<IClassService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
