using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPS926_A1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestockPage : ContentPage
    {
        public RestockPage()
        {
            InitializeComponent();

            stockList.ItemsSource = MainPage.list;
        }

        private void restockBtn_clicked(object sender, EventArgs e)
        {
            if (stockList.SelectedItem == null)
            {
                DisplayAlert("Error", "Please select an item to restock.", "OK");
            }
            else
            {
                if(restockEntry.Text == null)
                {
                    DisplayAlert("Error", "Please enter quantity of item to restock.", "OK");
                } 
                else
                {
                    int idx = MainPage.list.IndexOf((Item)stockList.SelectedItem);
                    MainPage.list[idx].qty += Int32.Parse(restockEntry.Text);

                    DisplayAlert("Success", "Item was restocked.", "OK");

                    stockList.SelectedItem = null;
                    restockEntry.Text = "";
                }
            } 
        }

        private void cancelBtn_clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void restockEntry_Focused(object sender, FocusEventArgs e)
        {
            cancelGrid.IsVisible = !cancelGrid.IsVisible;
        }
    }
}