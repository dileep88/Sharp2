using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.ViewModels;

namespace Sharp2POC.Fragments
{
	public abstract class BaseFragment<TViewModel> : MvxFragment where TViewModel : class, IMvxViewModel
	{
		protected Toolbar Toolbar { get; private set; }
		protected MvxActionBarDrawerToggle DrawerToggle { get; private set; }
		protected bool ShowHamburgerMenu { get; set; } = false;

		public new TViewModel ViewModel
		{
			get { return base.ViewModel as TViewModel; }
			set { base.ViewModel = value; }
		}

		protected BaseFragment()
		{
			RetainInstance = true;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = this.BindingInflate(FragmentId, null);

			Toolbar = view.FindViewById<Toolbar>(Droid.Resource.Id.toolbar);
			if (Toolbar != null)
			{
				var mainActivity = Activity as MainActivity;
				if (mainActivity == null)
					return view;

				mainActivity.Title = "";
				mainActivity.SetSupportActionBar(Toolbar);

				if (ShowHamburgerMenu)
				{
					mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);

					DrawerLayout drawerLayout = mainActivity.FindViewById<DrawerLayout>(Droid.Resource.Id.drawer_layout);
					drawerLayout?.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);

					DrawerToggle = new MvxActionBarDrawerToggle(
						Activity,                               // host Activity
						mainActivity.DrawerLayout,              // DrawerLayout object
						Toolbar,                                // nav drawer icon to replace 'Up' caret
						Droid.Resource.String.drawer_open,            // "open drawer" description
						Droid.Resource.String.drawer_close            // "close drawer" description
					);

					DrawerToggle.DrawerOpened += (sender, e) => mainActivity.HideSoftKeyboard();
					mainActivity.DrawerLayout.AddDrawerListener(DrawerToggle);
				}
				else
				{
					DrawerLayout drawerLayout = mainActivity.FindViewById<DrawerLayout>(Droid.Resource.Id.drawer_layout);
					drawerLayout?.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
				}

				mainActivity.HideSoftKeyboard();
			}

			return view;
		}

		protected abstract int FragmentId { get; }

		public override void OnConfigurationChanged(Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			if (Toolbar != null)
			{
				DrawerToggle?.OnConfigurationChanged(newConfig);
			}
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
			if (Toolbar != null)
			{
				DrawerToggle?.SyncState();
			}
		}
	}
}