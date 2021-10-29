using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A2.Views;
using A2.Services;
using System.IO;

namespace A2
{
    public partial class App : Application
    {

        static Database db;
        public static Database Database
        {
            get
            {
                if (db == null)
                {
                    db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "transactions.db"));

                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new home());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
