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
    public partial class AddItem : ContentPage
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void saveBtn_Clicked(object sender, EventArgs e)
        {
            if(itemName.Text == "")
            {
                DisplayAlert("Error", "Please enter the item name.", "OK");
            } 
            else if (itemPrice.Text == "")
            {
                DisplayAlert("Error", "Please enter the item price.", "OK");
            } 
            else if(itemQty.Text == "")
            {
                DisplayAlert("Error", "Please enter the item quantity.", "OK");
            }
            else
            {
                MainPage.list.Add(new Item(itemName.Text, Int32.Parse(itemPrice.Text), Int32.Parse(itemQty.Text)));
                DisplayAlert("Success", "New Item added successfully.", "OK");
                Navigation.PopAsync();
            }
        }

        private void cancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}