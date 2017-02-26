using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace logic4fun
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new logic4fun.View.SierpinskiTriangle();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
