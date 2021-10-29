using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A2.Services;


namespace A2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {
       
        public home()
        {
            InitializeComponent();
            //var transactions = tservice.Init();
        }

        async void navToBuyBTC(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new buybtc());
            
        }
        async void navToHist(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new history());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var transactionList = await App.Database.GetRecent();
            btcapi api = new btcapi();
            var data = api.getInfo();

            //Where(p == p.id.Equals(1)).FirstOrDefault();
            var serialized = JsonConvert.SerializeObject(data, Formatting.Indented);

            double currprice = data.data[0].quote.USD.price;
            int price = Convert.ToInt32(currprice);
            Cash.Text = "$" + transactionList[0].Cash.ToString();
            owned.Text = transactionList[0].Btc.ToString();
            totalval.Text = "$" + ((transactionList[0].Btc * price)+ transactionList[0].Cash).ToString();
        }
    }
}