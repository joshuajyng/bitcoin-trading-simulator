using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class history : ContentPage
    {
        public history()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var transactionList = await App.Database.GetTrans();
            if (transactionList != null)
            {
                TransItems.ItemsSource = transactionList;
            }
        }
      
    }
}