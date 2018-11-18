using Sharp2POC.Core.ViewModels.Base;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.Commands;

namespace Sharp2POC.Core.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService _navigationService;
		
		public MenuViewModel(IMvxNavigationService nav)
		{
			_navigationService = nav;
		}

		public IMvxAsyncCommand ShowSettingsCommand => new MvxAsyncCommand(ShowSettings);

		private async Task ShowSettings()
		{
			await _navigationService.Navigate<SettingsViewModel>();
		}

		public IMvxAsyncCommand ShowAboutCommand => new MvxAsyncCommand(ShowAbout);

		private async Task ShowAbout()
		{
			await _navigationService.Navigate<AboutViewModel>();
		}
	}
}