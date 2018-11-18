using Android.OS;
using Android.Runtime;
using Android.Views;
using Sharp2POC.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Sharp2POC.Droid;

namespace Sharp2POC.Fragments.Menu
{
	[MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, AddToBackStack = true, IsCacheableFragment = true)]
	[Register("carwash_droid.fragments.AboutFragment")]
	public class AboutFragment : BaseFragment<AboutViewModel>
	{
		protected override int FragmentId => Resource.Layout.aboutfragment;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			ShowHamburgerMenu = true;

			var view = base.OnCreateView(inflater, container, savedInstanceState);

			return view;
		}
	}
}