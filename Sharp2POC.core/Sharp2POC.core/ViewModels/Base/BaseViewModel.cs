using MvvmCross;
using MvvmCross.Localization;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Sharp2POC.Core.ViewModels.Base
{
	public class BaseViewModel : MvxViewModel
	{
		public IMvxLanguageBinder TextSource => new MvxLanguageBinder("", GetType().Name);
        public IMvxNavigationService NavigationService { get; protected set; }

        public BaseViewModel()
		{
            NavigationService = Mvx.Resolve<IMvxNavigationService>();
        }
	}
}
