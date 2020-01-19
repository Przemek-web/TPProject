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
    public class ProductList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Product Product { get; set; }

        public List<Product> products;

        public IProductService ProductService { get; set; }

        public Action<string> MessageBoxShowDelegate { get; set; }

        public string ActionText { get; set; }

        public Command DisplayAddWindow { get; set; }
        public Command RemoveEntity { get; set; }
        public Command DisplayDetails { get; set; }

        public IWindowResolver WindowResolver { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged("Products");
            }
        }

        public Action CloseWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProductList() : this(new ProductService()) { }

        public ProductList(IProductService productService)
        {
            ProductService = productService;
            Products = ProductService.GetAllProducts();
            ActionText = "Message";
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
            ProductDetails productDetailsViewModel = new ProductDetails();
            ShowDetails(productDetailsViewModel);
        }

        private void RemoveProduct()
        {
            ProductService.Delete(Product.ProductID);
        }

        private void ShowDetails()
        {
            ProductDetails productDetailsViewModel = new ProductDetails(Product, this.ProductService);
            ShowDetails(productDetailsViewModel);
        }

        private void ShowDetails(ProductDetails viewModel)
        {
            viewModel.DisplayErrorMessage = this.MessageBoxShowDelegate;
            IOperationWindow window = WindowResolver.GetWindow();
            window.BindViewModel(viewModel);
            window.Show();
        }
    }
}
