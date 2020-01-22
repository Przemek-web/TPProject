using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View
{
    class ProductDetailsWindow : IOperationWindow
    {
        private ProductDetails productDetails;
        public event VoidHandler OnClose;

        public ProductDetailsWindow()
        {
            productDetails = new ProductDetails();
        }

        public void BindViewModel<T>(T viewModel) where T : IViewModel
        {
            productDetails.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                OnClose?.Invoke();
                productDetails.Close();
            };
        }

        public void Show()
        {
            productDetails.Show();
        }
    }
}


