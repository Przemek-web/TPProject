using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Service;
using DataLayer;

namespace ViewModel
{
    public class ProductList : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged("Products");
            }
        }
        public Product Product { get; set; }

        public Action<string> MessageBoxShowDelegate { get; set; }

        public string ActionText { get; set; }
        public IWindowService WindowResolver { get; set; }

        public Command DisplayAddWindow { get; set; }
        public Command RemoveEntity { get; set; }
        public Command DisplayDetails { get; set; }

        public IProductService ProductService { get; set; }
        public Action CloseWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProductList() : this(new ProductService()) { }

        public ProductList(IProductService productService)
        {
            ProductService = productService;
            Products = ProductService.GetAllProducts();
            ActionText = "Message.";
            DisplayAddWindow = new Command(ShowAddWindow);
            RemoveEntity = new Command(RemoveProduct);
            DisplayDetails = new Command(ShowDetails);
            ProductService.CollectionChanged += OnProductsChanged;
        }

        private void OnProductsChanged()
        {
            Products = ProductService.GetAllProducts();
        }

        public void ShowAddWindow()
        {
            ProductDetails productDetails = new ProductDetails();
            ShowDetailsViewModel(productDetails);
        }

        public void ShowAddWindowTest()
        {
            ProductDetails productDetails = new ProductDetails(new ProductService());
            ShowDetailsViewModel(productDetails);
        }

        private void RemoveProduct()
        {
            ProductService.Delete(Product.ProductID);
        }

        private void ShowDetails()
        {
            ProductDetails productDetails = new ProductDetails(Product, ProductService);
            ShowDetailsViewModel(productDetails);
        }

        private void ShowDetailsViewModel(ProductDetails viewModel)
        {
            viewModel.DisplayErrorMessage = MessageBoxShowDelegate;
            IOperationWindow window = WindowResolver.GetWindow();
            window.BindViewModel(viewModel);
            window.Show();
        }
    }
}
