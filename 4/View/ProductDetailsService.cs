using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View
{
    public class ProductDetailsService : IWindowService
    {
        public IOperationWindow GetWindow()
        {
            return new ProductDetailsWindow();
        }
    }
}
