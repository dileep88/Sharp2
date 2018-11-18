using Android.App;
using Android.OS;
using Sharp2POC.Core.ViewModels;
using Android.Views.InputMethods;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Acr.UserDialogs;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Sharp2POC.Droid;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross;
using Sharp2POC.Core.Repositories.Interfaces;
using QATesting_Sample.Droid.Services;


namespace Sharp2POC
{//The MainActivity is the start-up of the application, which generates the Drawer [or menu] Layout, sets up 
 //User Dialogs, and provides some methods that could be used throughout the app, then navigates to the home screen 
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme",
            ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Draw UI
            SetContentView(Sharp2POC.Droid.Resource.Layout.main);
            DrawerLayout = FindViewById<DrawerLayout>(Droid.Resource.Id.drawer_layout);

            Mvx.RegisterSingleton<ISQLSampleRepository>(new AndroidSqliteDataService());

            //Setup Dialogs
            SetupUserDialogs();

            //Load Menu & Initial View
            if (bundle == null)
                ViewModel.ShowMenuAndDefaultView();
        }

        private void SetupUserDialogs()
        {
            //Initialize UserDialogs library
            UserDialogs.Init(this);

            //Apply Dialog Theme
            AlertConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
            ConfirmConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
            DatePromptConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
            TimePromptConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
            PromptConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
            LoginConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
            ActionSheetConfig.DefaultAndroidStyleId = Droid.Resource.Style.Theme_Dialog;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                try
                {
                    base.OnBackPressed();
                }
                catch
                {
                    base.MoveTaskToBack(false);
                }

        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
                return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}

