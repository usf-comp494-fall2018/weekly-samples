using Newtonsoft.Json;
using NorthwindUwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NorthwindUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<NorthwindDataResult> _results;
        public MainPage()
        {
            this.InitializeComponent();
            _results = new ObservableCollection<NorthwindDataResult>();
            lvResults.ItemsSource = _results;
        }

        private async void GetResultsButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboDataSource.SelectedIndex > -1)
            {
                _results.Clear();
                using (var client = new HttpClient())
                {
                    switch (comboDataSource.SelectedValue)
                    {
                        case "Customers":
                            var customerResponse =
                                await client.GetStringAsync("https://finalprojectcomp494.azurewebsites.net/api/customers");
                            var customerList = JsonConvert.DeserializeObject<List<Customer>>(customerResponse);
                            foreach (var customer in customerList.Where(c => c.CompanyName.ToUpper().Contains(tbCriteria.Text.ToUpper())))
                            {
                                _results.Add(new NorthwindDataResult()
                                {
                                    Id = customer.CustomerId,
                                    DisplayName = customer.CompanyName,
                                    DisplayDetails = $"{customer.ContactName} - {customer.ContactTitle} ({customer.City},{customer.Country})",
                                    ImagePath = GetImagePathForCategory(-1)
                                });
                            }
                            break;
                        case "Categories":
                            var categoryResponse =
                                await client.GetStringAsync("https://finalprojectcomp494.azurewebsites.net/api/categories");
                            var categoryList = JsonConvert.DeserializeObject<List<Category>>(categoryResponse);
                            foreach (var category in categoryList.Where(c => c.CategoryName.ToUpper().Contains(tbCriteria.Text.ToUpper())))
                            {
                                _results.Add(new NorthwindDataResult()
                                {
                                    Id = category.CategoryId.ToString(),
                                    DisplayName = category.CategoryName,
                                    DisplayDetails = $"{category.Description}",
                                    ImagePath = GetImagePathForCategory(category.CategoryId)
                                });
                            }
                            break;
                        case "Products":
                            var productResponse =
                                await client.GetStringAsync("https://finalprojectcomp494.azurewebsites.net/api/products");
                            var productList = JsonConvert.DeserializeObject<List<Product>>(productResponse);
                            foreach (var product in productList.Where(c => c.ProductName.ToUpper().Contains(tbCriteria.Text.ToUpper())))
                            {
                                _results.Add(new NorthwindDataResult()
                                {
                                    Id = product.ProductId.ToString(),
                                    DisplayName = product.ProductName,
                                    DisplayDetails = $"Qty/Unit: {product.QuantityPerUnit} - Reorder Level: {product.ReorderLevel} (Price: {product.UnitPrice:C})",
                                    ImagePath = GetImagePathForCategory(product.CategoryId ?? 0)
                                });
                            }
                            break;
                        case "Suppliers":
                            var supplierResponse =
                                await client.GetStringAsync("https://finalprojectcomp494.azurewebsites.net/api/suppliers");
                            var supplierList = JsonConvert.DeserializeObject<List<Supplier>>(supplierResponse);
                            foreach (var supplier in supplierList.Where(c => c.CompanyName.ToUpper().Contains(tbCriteria.Text.ToUpper())))
                            {
                                _results.Add(new NorthwindDataResult()
                                {
                                    Id = supplier.SupplierId.ToString(),
                                    DisplayName = supplier.CompanyName,
                                    DisplayDetails = $"{supplier.ContactName} - {supplier.ContactTitle} ({supplier.City},{supplier.Country})",
                                    ImagePath = GetImagePathForCategory(-1)
                                });
                            }
                            break;
                    }
                }
            }
        }

        private string GetImagePathForCategory(long categoryId)
        {
            // Default to Company unless it's a valid category Id
            string imagePath = "ms-appx:///Assets/Company.png";
            switch (categoryId)
            {
                case 1:
                    imagePath = "ms-appx:///Assets/Beverage.png";
                    break;
                case 2:
                    imagePath = "ms-appx:///Assets/Condiment.png";
                    break;
                case 3:
                    imagePath = "ms-appx:///Assets/Confection.png";
                    break;
                case 4:
                    imagePath = "ms-appx:///Assets/Dairy.png";
                    break;
                case 5:
                    imagePath = "ms-appx:///Assets/Grain.png";
                    break;
                case 6:
                    imagePath = "ms-appx:///Assets/Meat.png";
                    break;
                case 7:
                    imagePath = "ms-appx:///Assets/Produce.png";
                    break;
                case 8:
                    imagePath = "ms-appx:///Assets/Seafood.png";
                    break;
            }
            return imagePath;
        }
    }
}
