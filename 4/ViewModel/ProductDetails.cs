using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ViewModel
{
    public class ProductDetails : IViewModel
    {
        //Messages
        public string MessageEmptyFields { get; set; }

        //Static Data
        private int _productID { get; set; } 
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; } = null;
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; } = null;
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductSubcategoryID { get; set; } 
        public string ModelId { get; set; } 
        public DateTime? SellEndDate { get; set; }
        public DateTime SellStartDate { get; set; }

        //Display Data
        public List<string> Colors { get; set; }
        public List<bool> Flags { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> SizesUnits { get; set; }
        public List<string> WeightUnits { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubCategories { get; set; }
        public List<string> ModelIds { get; set; }

        //Actions
        public Action CloseWindow { get; set; }
        public Action<string> DisplayErrorMessage { get; set; }
        //CommandsData
        public string ActionText { get; set; }

        //Commands
        public Command DisplayMessage { get; set; }
        public Command AddItemToDataBase { get; set; }

        public IProductService ProductService { get; set; }

        public ProductDetails(): this(new ProductService())
        {

        }

        public ProductDetails(IProductService productService)
        {
            ProductService = productService;
            DisplayMessage = new Command(ShowPopupWindow);
            AddItemToDataBase = new Command(SaveProduct);
            Colors = ProductService.GetProductColors();
            Sizes = ProductService.GetProductSizes();
            SizesUnits = ProductService.GetSizeUnits();
            WeightUnits = ProductService.GetWeightUnits();
            Flags = new List<bool> { true, false };
            ProductLines = ProductService.GetProductLines();
            Classes = ProductService.GetProductClasses();
            Styles = ProductService.GetProductStyles();
            ProductSubCategories = ProductService.GetProductSubcategories();
            ModelIds = ProductService.GetProductModels();
        }

        public ProductDetails(Product product, IProductService productService) : this(productService)
        {
            ProductName = product.Name;
            ProductNumber = product.ProductNumber;
            MakeFlag = product.MakeFlag;
            FinishedGoodsFlag = product.FinishedGoodsFlag;
            Color = product.Color;
            SafetyStockLevel = product.SafetyStockLevel;
            ReorderPoint = product.ReorderPoint;
            StandardCost = product.StandardCost;
            ListPrice = product.ListPrice;
            Size = product.Size;
            SizeUnitMeasureCode = product.SizeUnitMeasureCode;
            WeightUnitMeasureCode = product.WeightUnitMeasureCode;
            Weight = product.Weight;
            DaysToManufacture = product.DaysToManufacture;
            ProductLine = product.ProductLine;
            Class = product.Class;
            Style = product.Style;
            ProductSubcategoryID = product.ProductSubcategoryID.HasValue ? ProductService.GetSubcategoryNameByID(product.ProductSubcategoryID ?? 0) : null;
            ModelId = product.ProductModelID.HasValue ? ProductService.GetModelNameByID(product.ProductModelID ?? 0) : null;
            _productID = product.ProductID;
            SellStartDate = product.SellStartDate;
            SellEndDate = product.SellEndDate;
        }
        

        private void ShowPopupWindow()
        {
            DisplayErrorMessage(MessageEmptyFields);
        }

        private void SaveProduct()
        {
            MessageEmptyFields = "";
            Product product = GetProduct();
            if (product.SellEndDate == null || product.SellEndDate > product.SellStartDate)
            {
                ProductService.Insert(product);
                CloseWindow();
            }
            else
            {
                MessageEmptyFields = "Start date must be before end date";
                ShowPopupWindow();
            }
        }

        private Product GetProduct()
        {
            Product product = new Product();
            product.rowguid = new Guid();
            product.Name = ProductName;
            product.ProductNumber = ProductNumber;
            product.MakeFlag = MakeFlag;
            product.FinishedGoodsFlag = FinishedGoodsFlag;
            product.Color = Color;
            product.SafetyStockLevel = SafetyStockLevel;
            product.ReorderPoint = ReorderPoint;
            product.StandardCost = StandardCost;
            product.ListPrice = ListPrice;
            product.Size = Size;
            product.SizeUnitMeasureCode = SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = WeightUnitMeasureCode;
            product.Weight = Weight;
            product.DaysToManufacture = DaysToManufacture;
            product.ProductLine = ProductLine;
            product.Class = Class;
            product.Style = Style;
            product.ProductSubcategoryID = (ProductSubcategoryID != null && ProductSubcategoryID.Length > 0) ? 
                ProductService.GetSubcategoryIDByName(ProductSubcategoryID) : (int?)null;
            product.ProductModelID = (ModelId != null && ModelId.Length > 0) ?
                ProductService.GetModelIDByName(ModelId) : (int?)null; 
            product.SellStartDate = SellStartDate;
            product.SellEndDate = SellEndDate;
            product.ModifiedDate = DateTime.Today;
            product.ProductID = _productID;
            return product;
        }
    }
}
