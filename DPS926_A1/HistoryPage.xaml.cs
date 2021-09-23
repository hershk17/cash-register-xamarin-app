using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace DPS926_A1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();

            historyView.ItemsSource = new ObservableCollection<ItemPurchased>(MainPage.purchased_items);
        }

        private void historyView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ItemPurchasedDetails((ItemPurchased)e.Item));
        }
    }
}