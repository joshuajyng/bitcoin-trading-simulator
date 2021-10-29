using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A2.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class buybtc : ContentPage
    {
        public int currcash;
        public int currbtc;
        public int currp;
        public buybtc()
        {
            InitializeComponent();
       
        }
        public async void Buy(System.Object sender, System.EventArgs e)
        {
            await App.Database.AddTrans(new transaction
            {
                Cash = currcash - (currp* Convert.ToInt32(amountentry.Text)),
                Amount = Convert.ToInt32(amountentry.Text),
                Btc = currbtc + Convert.ToInt32(amountentry.Text),
                Buy = "Buy"
            });
            await DisplayAlert("Success", "Bought " + amountentry.Text + " Bitcoin for $" + currp.ToString() + "!", "OK");
            Cash.Text = "$" + (currcash - (currp * Convert.ToInt32(amountentry.Text))).ToString();
            currbtc = currbtc + Convert.ToInt32(amountentry.Text);
            owned.Text = currbtc.ToString();
            amountentry.Text = string.Empty;
        
        }

        public async void Sell(System.Object sender, System.EventArgs e)
        {
            await App.Database.AddTrans(new transaction
            {
                Cash = currcash + (currp * Convert.ToInt32(amountentry.Text)),
                Amount = Convert.ToInt32(amountentry.Text),
                Btc = currbtc - Convert.ToInt32(amountentry.Text),
                Buy = "Sell"
            });
            await DisplayAlert("Success", "Sold " + amountentry.Text + " Bitcoin for $" + currp.ToString() + "!", "OK");
            Cash.Text = "$" + (currcash + (currp * Convert.ToInt32(amountentry.Text))).ToString();
            currbtc = currbtc - Convert.ToInt32(amountentry.Text);
            owned.Text = currbtc.ToString();
            amountentry.Text = string.Empty;
            
        }
        public void reloadPrice(System.Object sender, System.EventArgs e)
        {
            btcapi api = new btcapi();
            var data = api.getInfo();
            int price = currp;

            //Where(p == p.id.Equals(1)).FirstOrDefault();
            var serialized = JsonConvert.SerializeObject(data, Formatting.Indented);

            double currprice = data.data[0].quote.USD.price;
            int cprice = Convert.ToInt32(currprice);
            CurrPrice.Text = "$" + Convert.ToString(cprice);
            currp = cprice;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var transactionList = await App.Database.GetRecent();
            currcash = transactionList[0].Cash;
            currbtc = transactionList[0].Btc;
            owned.Text = transactionList[0].Btc.ToString();
            Cash.Text = "$" + Convert.ToString(transactionList[0].Cash);
            btcapi api = new btcapi();
            var data = api.getInfo();


            double currprice = data.data[0].quote.USD.price;
            int cprice = Convert.ToInt32(currprice);
            currp = cprice;
            CurrPrice.Text = "$"+cprice.ToString();
        }
    }
}