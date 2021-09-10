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

            Tuple<string, string>[] rows =
           {
                Tuple.Create("Bill: ", "Enter bill"),
                Tuple.Create("Tip: ", "Enter tip"),
                Tuple.Create("Total Bill: ", ""),
                Tuple.Create("Total Tip: ", ""),
            };

            int i = 0;
            for(i = 0; i < rows.Length; i++)
            {
                var label = new Label();
                label.Text = rows[i].Item1;
                grid.Children.Add(label, 0, i);

                View view;

                if(rows[i].Item2.Equals(""))
                {
                    view = new Label();
                }
                else
                {
                    view = new Entry();
                    (view as Entry).Placeholder = rows[i].Item2;
                }

                grid.Children.Add(view, 1, i);
            }

            var calcBtn = new Button();
            calcBtn.BackgroundColor = Color.Magenta;
            calcBtn.Text = "CALCULATE BILL";
            calcBtn.Clicked += CalculateBill;
            grid.Children.Add(calcBtn, 0, i++);

            var clearBtn = new Button();
            clearBtn.Clicked += Clear;
            grid.Children.Add(clearBtn, 0, i++);

        }

        private void CalculateBill(object sender, EventArgs e)
        {
            //_model.Bill = decimal.Parse(bill.Text);
            //_model.Tip = decimal.Parse(tip.Text);
            //_model.Guests = int.Parse(guests.Text);

            //totalBill.Text = _model.Total.ToString("C2");
            //totalTip.Text = _model.TotalTip.ToString("C2");
        }

        private void Clear(object sender, EventArgs e)
        {
            _model.Clear();
            //totalBill.Text = totalTip.Text = bill.Text = tip.Text = guests.Text = "";
        }
    }
}
