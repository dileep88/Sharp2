using Sharp2POC.Core.ViewModels.Base;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Sharp2POC.Core.ViewModels
{
	public class MainViewModel : BaseViewModel
    {
		private readonly IMvxNavigationService navigationService;

		public MainViewModel(IMvxNavigationService n)
		{
			navigationService = n;
		}

		public void ShowMenuAndDefaultView()
		{
			navigationService.Navigate<MenuViewModel>();
			navigationService.Navigate<PreloadMenuViewModel>();
		}
	}
}