using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPS926_A1
{
    public class ItemPurchased : Item
    {
        public string purchase_date { get; set; }

        public ItemPurchased() { }

        public ItemPurchased(string name, int qty, double price, string date) : base(name, qty, price)
        {
            purchase_date = date;
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPurchasedDetails : ContentPage
    {
        public ItemPurchasedDetails(ItemPurchased item)
        {
            InitializeComponent();

            itemName.Text = "Item Name: " + item.name;
            itemQty.Text = "Quantity: " + item.qty.ToString();
            itemDate.Text = "Purchased on: " + item.purchase_date;
            itemPrice.Text = "Total amount: " + item.price.ToString();
        }
    }
}