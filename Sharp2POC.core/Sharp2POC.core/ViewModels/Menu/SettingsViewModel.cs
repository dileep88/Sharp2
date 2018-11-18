using Sharp2POC.Core.Models;
using Sharp2POC.Core.ViewModels.Base;
using System.Collections.Generic;
using MvvmCross.Navigation;
using MvvmCross.Commands;

namespace Sharp2POC.Core.ViewModels
{
	public class SettingsViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		public SettingsViewModel(IMvxNavigationService _nav)
		{
			nav = _nav;

			SettingsTitle = "Settings";
			Description = "Here you can have the configuration to your application be managable by the user. Allowing them to change things like: " +
								   "Timer Intervals, Data Upload Rate [if you are connected to an SQL server], Color Scheme, and more!";
		}

		private List<RadioChoice> _choices = new List<RadioChoice>()
		{
			new RadioChoice(){ Name = "Choice 1", Value = "Choice 1 Selected" },
			new RadioChoice(){ Name = "Choice 2", Value = "Choice 2 Selected" },
			new RadioChoice(){ Name = "Choice 3", Value = "Choice 3 Selected" }
		};

		public List<RadioChoice> Choices
		{
			get
			{
				return _choices;
			}

			set
			{
				_choices = value;
				RaisePropertyChanged(() => Choices);
			}
		}
		
		private RadioChoice _selectedChoice = new RadioChoice() { Name = "", Value = "Select A Choice" };
		public RadioChoice SelectedChoice
		{
			get { return _selectedChoice; }
			set
			{
				_selectedChoice = value;
				RaisePropertyChanged(() => SelectedChoice);
			}
		}

		public string SettingsTitle { get; set; }
		public string Description { get; set; }

		public MvxCommand NavgiateHomeCommand => new MvxCommand(NavgiateHome);
		private void NavgiateHome()
		{
			nav.Navigate<HomeViewModel>();
		}
	}
}
