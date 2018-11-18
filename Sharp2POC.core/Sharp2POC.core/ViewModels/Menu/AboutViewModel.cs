using Sharp2POC.Core.ViewModels.Base;
using MvvmCross.Navigation;
using MvvmCross.Commands;

namespace Sharp2POC.Core.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		public AboutViewModel(IMvxNavigationService _nav)
		{
			nav = _nav;

			AboutTitle = "About This App!";
			Description = "Here you can describe your app with info like version number, device info, or provide links to the Terms of Service and Privacy Policy.";
		}

		public string AboutTitle { get; set; }

		public string Description { get; set; }
		
		public MvxCommand NavgiateHomeCommand => new MvxCommand(NavgiateHome);
		private void NavgiateHome()
		{
			nav.Navigate<HomeViewModel>();
		}
	}
}
