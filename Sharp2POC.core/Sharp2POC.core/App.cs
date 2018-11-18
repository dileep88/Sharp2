using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels; 
using Sharp2POC.Core.ViewModels;

namespace Sharp2POC.core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Repos
            /*Registers repositories with the IoC*/
            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Services
            /*Registers services with the Inversion of Control pattern [IoC]*/
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Register UserDialogs
            /*Register the UserDialogs instance as a Singleton
              UserDialogs allows for dialogs to be called from Core code*/
            Mvx.RegisterSingleton(() => UserDialogs.Instance);

            RegisterAppStart<MainViewModel>();
        }
    }
}
