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
	public class ManageActiveLoadsViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		public ManageActiveLoadsViewModel(IMvxNavigationService _nav)
		{
			nav = _nav; 
			HomeTitle = "Welcome Home!";

            ManageLoad = new MvxObservableCollection<ManageLoadItem>(new[]
            {
                new ManageLoadItem(null,"All Load IDs", () => Task.CompletedTask),
                  new ManageLoadItem(null,"09878", () => Task.CompletedTask),
                  new ManageLoadItem(null,"09878", () => Task.CompletedTask),
                  new ManageLoadItem(null,"09878", () => Task.CompletedTask), 
            });
            NavigateToMenuItemCommand = new MvxAsyncCommand<ManageLoadItem>(NavigateToMenuItem);
        }

        public IList<ManageLoadItem> ManageLoad { get; }

        public IMvxAsyncCommand<ManageLoadItem> NavigateToMenuItemCommand { get; }

        private Task NavigateToMenuItem(ManageLoadItem item)
        {
            return item.NavigationTask.Invoke();
        }

        //This is a property that is used to set the home title text view in the homefragment.xml file
        public string HomeTitle { get; set; }
         
	}
}
