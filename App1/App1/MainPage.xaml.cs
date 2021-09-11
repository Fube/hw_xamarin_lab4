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
        //public Entry
        //    bill,
        //    tip,
        //    guests;
        //public Label
        //    totalBill,
        //    totalTip;

        public MainPage()
        {
            InitializeComponent();
            _model = new TipModel();
            //SetUpPage();
        }

        private void SetUpPage()
        {
            RowDefinitionCollection rowDef = new RowDefinitionCollection();

            for (int x = 0; x < 7; x++)
            {
                rowDef.Add(
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) }
                );
            }

            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1.0, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2.0, GridUnitType.Star) }
                },

                RowDefinitions = rowDef,
            };

            Image maple = new Image
            {
                Source = "maple.jpg"
            };
            grid.Children.Add(maple);
            Grid.SetColumnSpan(maple, 2);

            bill = new Entry();
            tip = new Entry();
            guests = new Entry();

            Tuple<Entry, string>[] listEntry =
            {
                Tuple.Create(bill, "Enter bill"),
                Tuple.Create(tip, "Enter tip"),
                Tuple.Create(guests, "Number of Guests"),
            };
            for (int j = 0; j < listEntry.Length; j++)
            {
                listEntry[j].Item1.Placeholder = listEntry[j].Item2;
                grid.Children.Add(listEntry[j].Item1, 1, j + 1);
            }



            string[] rows =
           {
                "Bill: ",
                "Tip: ",
                "No of Guests",
                "Total Bill: ",
                "Total Tip: ",
            };
            int i = 0;
            for (i = 0; i < rows.Length; i++)
            {
                Label label = new Label
                {
                    Text = rows[i]
                };
                grid.Children.Add(label, 0, i + 1);
            }

            --i;

            totalBill = new Label
            {

                Style = Resources["greyLabel"] as Style
            };

            totalTip = new Label
            {
                Style = Resources["greyLabel"] as Style
            };

            grid.Children.Add(totalBill, 1, i++);
            grid.Children.Add(totalTip, 1, i++);


            Button calcBtn = new Button
            {
                BackgroundColor = Color.DarkGreen,
                Text = "CALCULATE BILL",
            };
            calcBtn.Clicked += CalculateBill;
            grid.Children.Add(calcBtn, 0, i);
            Grid.SetColumnSpan(calcBtn, 1);

            Button clearBtn = new Button
            {
                BackgroundColor = Color.Magenta,
                Text = "CLEAR",
            };
            clearBtn.Clicked += Clear;
            grid.Children.Add(clearBtn, 1, i++);
            Grid.SetColumnSpan(clearBtn, 1);
            Content = grid;
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
    }
}
