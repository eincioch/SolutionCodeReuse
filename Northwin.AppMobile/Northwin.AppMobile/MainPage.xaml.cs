using Northwind.Entities.Entity;
using Northwind.RestService.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Northwin.AppMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing() {
            base.OnAppearing();
            var ResClient = new ServiceClient();
            ListView.ItemsSource = await ResClient.GetProductsAsync();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            await Navigation.PushAsync(new ProductItemPage { BindingContext = e.SelectedItem as Product, IsNew = false });
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductItemPage { BindingContext = new Product(), IsNew=true});
        }
    }
}
