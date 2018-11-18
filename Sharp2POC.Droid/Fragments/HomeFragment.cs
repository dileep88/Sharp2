using Android.OS;
using Android.Runtime;
using Android.Views;
using Sharp2POC.Core.ViewModels;
using Sharp2POC.Droid;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Sharp2POC.Fragments
{
	[MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
	[Register("carwash_droid.fragments.HomeFragment")]
	public class HomeFragment : BaseFragment<HomeViewModel>
	{
		protected override int FragmentId => Resource.Layout.homefragment;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			ShowHamburgerMenu = true;

			var view = base.OnCreateView(inflater, container, savedInstanceState);

			return view;
		}
	}
}