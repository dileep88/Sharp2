using System.Threading.Tasks;
using Sharp2POC.Core.Models;
using Sharp2POC.Core.Services.Interfaces;
using Sharp2POC.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;

namespace Sharp2POC.Core.ViewModels
{
	public class SQLSampleViewModel : BaseViewModel
	{
		private readonly IMvxNavigationService nav;
		private readonly ISQLSampleService sql;

		public SQLSampleViewModel(ISQLSampleService _sql, IMvxNavigationService _nav)
		{
			nav = _nav;
			sql = _sql;

			SQLSampleTitle = "SQL Sample";
		}

		//The Initialize function is an overridden method, as part of the MvxViewModel class, 
		//that is automatically run when a MvxViewModel object is instantiated.
		public override Task Initialize()
		{
			SQLObjects = new MvxObservableCollection<SQLExampleObject>();
			SQLObjects.ReplaceWith(sql.ReturnList());

			return base.Initialize();
		}

		public string SQLSampleTitle { get; set; }

		//MvxObservableCollection variables are used to allow lists to be bound to MvxListViews in the xml files.
		//This is required to display a list on a screen.
		private MvxObservableCollection<SQLExampleObject> _sqlobjects;
		public MvxObservableCollection<SQLExampleObject> SQLObjects
		{
			get { return _sqlobjects; }
			set
			{
				_sqlobjects = value;
				RaisePropertyChanged(() => SQLObjects);
			}
		}

		private SQLExampleObject _selectedobject = new SQLExampleObject() { Name = "Select An Object" };
		public SQLExampleObject SelectedObject
		{
			get { return _selectedobject; }
			set
			{
				_selectedobject = value;
				//RaisePropertyChanged() updates the UI when a property value has changed
				RaisePropertyChanged(() => SelectedObject);
			}
		}

		public MvxCommand RefreshListCommand => new MvxCommand(RefreshList);
		private void RefreshList()
		{
			sql.GenerateSampleList();
			SQLObjects.ReplaceWith(sql.ReturnList());
		}

		public MvxCommand DeleteObjectCommand => new MvxCommand(DeleteObject);
		private void DeleteObject()
		{
			sql.Remove(SelectedObject);
			SelectedObject = new SQLExampleObject() { Name = "Select An Object" };
			SQLObjects.ReplaceWith(sql.ReturnList());
		}
	}
}