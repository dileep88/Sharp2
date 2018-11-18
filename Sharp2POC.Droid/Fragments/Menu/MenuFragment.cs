using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using Sharp2POC.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Sharp2POC.Droid;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Sharp2POC.Fragments.Menu
{
	[MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
	[Register("carwash_droid.fragments.MenuFragment")]
	public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
	{
		//Navigation Menu
		private NavigationView _navigationView;
		private IMenuItem _previousMenuItem;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			View view = this.BindingInflate(Resource.Menu.menu_navigation, null);

			_navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
			_navigationView.SetNavigationItemSelectedListener(this);

			return view;
		}

		public bool OnNavigationItemSelected(IMenuItem item)
		{
			//Set Current Item to previous
			_previousMenuItem = item;

			//Navigate to new view
			Navigate(item.ItemId);

			return true;
		}

		private async void Navigate(int itemId)
		{			
			//Add a small delay to prevent any UI issues
			await Task.Delay(TimeSpan.FromMilliseconds(250));

			switch (itemId)
			{
				case Resource.Id.nav_settings:
					ViewModel.ShowSettingsCommand.Execute();
					(Activity as MainActivity)?.DrawerLayout.CloseDrawers();
					break;
				case Resource.Id.nav_about:
					ViewModel.ShowAboutCommand.Execute();
					(Activity as MainActivity)?.DrawerLayout.CloseDrawers();
					break;
			}
		}
	}
}