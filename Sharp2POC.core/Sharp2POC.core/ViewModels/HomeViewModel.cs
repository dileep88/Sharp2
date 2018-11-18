using Sharp2POC.Core.ViewModels.Base;
using MvvmCross.Navigation;
using MvvmCross.Commands;

namespace Sharp2POC.Core.ViewModels
{
	//Landing screen when you open the app
	public class HomeViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		public HomeViewModel (IMvxNavigationService _nav)
		{
			nav = _nav;
			
			HomeTitle = "Welcome Home!";
		}

		//This is a property that is used to set the home title text view in the homefragment.xml file
		public string HomeTitle { get; set; }

		//An MvxCommand that is used to bind a function to a button click within the homefragment.xml file
		//This specific command navigates the user to the SQL Sample screen when the button it is bound to is pressed
		public MvxCommand NavigateToSQLCommand => new MvxCommand(NavigateToSQL);
		private async void NavigateToSQL()
		{
			await nav.Navigate<SQLSampleViewModel>();
		}
	}
}
