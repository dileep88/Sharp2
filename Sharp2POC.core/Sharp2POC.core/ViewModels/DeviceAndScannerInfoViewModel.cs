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
	public class DeviceAndScannerInfoViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		public DeviceAndScannerInfoViewModel(IMvxNavigationService _nav)
		{
			nav = _nav; 
			HomeTitle = "Welcome Home!"; 
        }
         
        
        public string HomeTitle { get; set; }
         
	}
}
