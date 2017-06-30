using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HorizontalListView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadIntitalPage();
        }

        private void LoadIntitalPage()
        {
            var page = FreshPageModelResolver.ResolvePageModel<ListViewPageModel>();
            var navigationService =
                new FreshNavigationContainer(page) { BarBackgroundColor = Color.SteelBlue };
            MainPage = navigationService;
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
