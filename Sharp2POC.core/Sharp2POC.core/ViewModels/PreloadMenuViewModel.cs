using Sharp2POC.Core.ViewModels.Base;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using Sharp2POC.Core.Models;
using System.Collections.Generic;
using Sharp2POC.core.Models;
using System.Threading.Tasks;
using MvvmCross.ViewModels; 

namespace Sharp2POC.Core.ViewModels
{
	//Landing screen when you open the app
	public class PreloadMenuViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		public PreloadMenuViewModel(IMvxNavigationService _nav)
		{
			nav = _nav; 
			HomeTitle = "Welcome Home!";

            MenuItems = new MvxObservableCollection<NavigationMenuItem>(new[]
            {
                new NavigationMenuItem("Preload Package Scan", () => NavigationService.Navigate<PreloadPackageScanViewModel>()),
                new NavigationMenuItem("Preload Smart Scan Setup",
                    () => NavigationService.Navigate<PreloadSmartScanSetupViewModel>()),
                new NavigationMenuItem("Bulk Delivery Setup",
                    () => NavigationService.Navigate<ManageLoadsViewModel>()),
                new NavigationMenuItem("Driver Load", () =>  NavigationService.Navigate<ManageActiveLoadsViewModel>()),
                new NavigationMenuItem("SPA", () =>  NavigationService.Navigate<DeviceAndScannerInfoViewModel>()),
                new NavigationMenuItem("Beacon Maintenance", () => Task.CompletedTask),
            });
            NavigateToMenuItemCommand = new MvxAsyncCommand<NavigationMenuItem>(NavigateToMenuItem);
        }

        public IList<NavigationMenuItem> MenuItems { get; }

        public IMvxAsyncCommand<NavigationMenuItem> NavigateToMenuItemCommand { get; }

        private Task NavigateToMenuItem(NavigationMenuItem item)
        {
            return item.NavigationTask.Invoke();
        }

        //This is a property that is used to set the home title text view in the homefragment.xml file
        public string HomeTitle { get; set; }
         
	}
}
