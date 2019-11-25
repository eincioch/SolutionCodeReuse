using Northwind.Entities.Entity;
using Northwind.RestService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Northwin.AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductItemPage : ContentPage
    {
        public bool IsNew { get; set; }
        public ProductItemPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var RestClient = new ServiceClient();
            var Item = (Product)BindingContext;
            if (IsNew)
            {
                Item = await RestClient.CreateAsync(Item);
            }
            else {
                await RestClient.UpdateAsync(Item);
            }
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var RestClient = new ServiceClient();
            var Item = (Product)BindingContext;

            await RestClient.DeleteAsync(Item.Id);
            await Navigation.PopAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}