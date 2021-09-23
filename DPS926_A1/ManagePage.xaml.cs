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
    public partial class ManagePage : ContentPage
    {
        public ManagePage()
        {
            InitializeComponent();
        }

        private void historyBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage());
        }

        private void restockBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RestockPage());
        }

        private void addBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddItem());
        }
    }
}