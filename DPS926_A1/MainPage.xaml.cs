using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DPS926_A1
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Item> list;
        public static ObservableCollection<ItemPurchased> purchased_items = new ObservableCollection<ItemPurchased>();
        private Item selected_item;
        private string selected_quantity;
        private double selected_cost;

        public MainPage()
        {
            InitializeComponent();

            clearFields();

            list = new ObservableCollection<Item>() {
                new Item("Pants", 20, 50.7),
                new Item("Shoes", 50, 90),
                new Item("Hats", 10, 20.5),
                new Item("TShirts", 10, 33.8),
                new Item("Dresses", 24, 140.3)
            };

            ListView.ItemsSource = list;
        }

        private void clearFields()
        {
            labelType.Text = "Type";
            labelTotal.Text = "Total";
            labelQuantity.Text = "Quantity";
            selected_item = null;
            selected_quantity = "";
            selected_cost = 0;
        }

        private void updateCost()
        {
            if (selected_item != null)
            {
                selected_cost = Int32.Parse(selected_quantity) * selected_item.price;
                labelTotal.Text = selected_cost.ToString();
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selected_item = (Item)e.SelectedItem;

            if (selected_item != null)
            {
                labelType.Text = selected_item.name;
            }

            if (selected_quantity != "")
            {
                updateCost();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            selected_quantity += ((Button)sender).Text;
            labelQuantity.Text = selected_quantity;
            
            updateCost();
        }

        private void Backspace_Clicked(object sender, EventArgs e)
        {
            if (selected_quantity != "")
            {
                selected_quantity = selected_quantity.Remove(selected_quantity.Length - 1);
                labelQuantity.Text = selected_quantity;

                if (selected_quantity == "")
                {
                    labelTotal.Text = "";
                } 
                else
                {
                    updateCost();
                }
            }
        }

        private void BuyButton_Clicked(object sender, EventArgs e)
        {
            if(selected_item == null)
            {
                DisplayAlert("ERROR", "Please select an item to purchase.", "OK");
            }
            else if (selected_quantity == "")
            {
                DisplayAlert("ERROR", "Please enter the quantity to purchase.", "OK");
            }
            else
            {
                int idx = list.IndexOf(selected_item);
                int qty = Int32.Parse(selected_quantity);

                if (qty > list[idx].qty)
                {
                    DisplayAlert("ERROR", "Quantity selected is more than quantity available, please try again.", "OK");
                }
                else
                {
                    ItemPurchased itemPurchased = new ItemPurchased(selected_item.name, Int32.Parse(selected_quantity), selected_cost, DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-US")));
                    purchased_items.Add(itemPurchased);

                    DisplayAlert("Success", "You purchased " + itemPurchased.name, "OK");

                    list[idx].qty -= qty;
                    labelTotal.Text = list[idx].qty.ToString();

                    clearFields();
                    ListView.SelectedItem = null;
                }
            }
        }

        private void ManageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManagePage());
        }
    }
}
