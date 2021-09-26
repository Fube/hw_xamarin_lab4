using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public TipModel _model;

        public MainPage()
        {
            InitializeComponent();
            _model = new TipModel();
        }


        private void CalculateBill(object sender, EventArgs e)
        {
            _model.Bill = decimal.Parse(bill.Text);
            _model.Tip = decimal.Parse(tip.Text);
            _model.Guests = int.Parse(guests.Text);

            totalBill.Text = _model.Total.ToString("C2");
            totalTip.Text = _model.TotalTip.ToString("C2");
        }

        private void Clear(object sender, EventArgs e)
        {
            _model.Clear();
            totalBill.Text = totalTip.Text = bill.Text = tip.Text = guests.Text = "";
        }

        async private void BillButtonClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Bill Price", "Enter the bill price");
            bill.Text = result;
        }

        async void TipAmountButtonClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Tip Amount", "Enter the desired tip amount");
            tip.Text = result;
        }
        async void GuestAmountButtonClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Number Of Guests", "Enter the number of guest(s)");
            guests.Text = result;
        }
    }
}
