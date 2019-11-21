using Newtonsoft.Json;
using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.RestService.Services
{
    public class ServiceClient
    {
        string BaseEndPoint = "http://172.16.2.21:5000/api/Products";

        HttpClient httpClient;

        public ServiceClient()
        {
            httpClient = new HttpClient();
        }


        public async Task<List<Product>> GetProductsAsync()
        {

            var products = new List<Product>();
            var Uri = new Uri(BaseEndPoint);

            try
            {
                var Response = await httpClient.GetAsync(Uri);
                if (Response.IsSuccessStatusCode)
                {
                    var Content = await Response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(Content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return products;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            Product Product = null; //para devolver
            var Uri = new Uri(BaseEndPoint);

            try
            {
                var Json = JsonConvert.SerializeObject(product);
                StringContent Content = new StringContent(Json,Encoding.UTF8,"application/json");

                var Response = await httpClient.PostAsync(Uri,Content);
                if (Response.IsSuccessStatusCode)
                {
                    var ResponceContent = await Response.Content.ReadAsStringAsync();
                    Product = JsonConvert.DeserializeObject<Product>(ResponceContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return Product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            Product Product = null; //para devolver
            var Uri = new Uri(BaseEndPoint);

            try
            {
                var Json = JsonConvert.SerializeObject(product);
                StringContent Content = new StringContent(Json, Encoding.UTF8, "application/json");

                var Response = await httpClient.PutAsync(Uri, Content);
                if (Response.IsSuccessStatusCode)
                {
                    var ResponceContent = await Response.Content.ReadAsStringAsync();
                    Product = JsonConvert.DeserializeObject<Product>(ResponceContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return Product;
        }

        public async Task DeleteAsync(int id)
        {
            var Uri = new Uri(BaseEndPoint);

            try
            {
                var Response = await httpClient.DeleteAsync($"{Uri}/{id}");
                if (Response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Producto eliminado!!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }
    }
}
