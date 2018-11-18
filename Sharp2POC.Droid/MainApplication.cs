using System;  
using Android.App; 
using Android.Runtime; 
using MvvmCross.Droid.Support.V7.AppCompat;
using Sharp2POC.core;

namespace Sharp2POC.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<MvxAppCompatSetup<App>, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}