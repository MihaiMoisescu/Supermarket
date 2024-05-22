using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    internal class ProductsBLL
    {
        private SupermarketDBEntities context=new SupermarketDBEntities();

        public ObservableCollection<Product> ProductsList { get; set;}

        public string ErrorMessage { get; set; }

        public ObservableCollection<Product> GetAllProducts()
        {
            var products = context.Products.ToList();

            var results = new ObservableCollection<Product>();
            foreach (var product in products)
            {
                results.Add(product);
            }
            return results;
        }

        public void AddProduct(object obj)
        {
            Product product= obj as Product;

            if(product != null)
            {
                if (ProductsList.FirstOrDefault(o => o.Name == product.Name) != null)
                    ErrorMessage = "Exista deja un produs cu acest nume.";
                else if (string.IsNullOrEmpty(product.Name))
                    ErrorMessage = "Numele produsului nu poate fi nul!";
                else if (string.IsNullOrEmpty(product.Barcode))
                    ErrorMessage = "Codul de bare nu poate fi nul!";
                else
                {
                    product.IsActive= true;
                    context.AddProduct(product.Name, product.Barcode,product.IsActive,product.CategoryID,product.ProducerID, new ObjectParameter("productID", product.ProductID));
                    context.SaveChanges();
                    product.ProductID=context.Products.Max(prod=>prod.ProductID);
                    ProductsList.Add(product);
                    ErrorMessage = "";
                }
               
            }
            else
            {
                ErrorMessage = "Campurile nu pot fi nule!";
            }
        }
        public void UpdateProduct(object obj) 
        {
            Product product= obj as Product;

            if (ProductsList.FirstOrDefault(prod => prod.ProductID == product.ProductID).ProducerID != product.ProducerID)
            {
                ErrorMessage = "Nu puteti modifica producatorul produsului!";
            }
            else if(ProductsList.FirstOrDefault(prod => prod.ProductID == product.ProductID).CategoryID != product.CategoryID)
            {
                ErrorMessage = "Nu puteti modifica categori din care face parte un produs!";
            }
            else
            {
                context.ModifyProduct(product.ProductID, product.Name,product.Barcode,product.IsActive,product.CategoryID, product.ProducerID);
                context.SaveChanges();
                ErrorMessage = "";
            }
        }
        public void DeleteProduct(object obj) 
        {
            Product product= obj as Product;

            if (product != null)
            {
                if (string.IsNullOrEmpty(product.Name))
                    ErrorMessage = "Numele produsului nu poate fi nul!";
                else if (string.IsNullOrEmpty(product.Barcode))
                    ErrorMessage = "Codul de bare nu poate fi nul!";
                else
                {

                    product.IsActive = false;
                    context.DeleteProduct(product.ProductID, product.IsActive);
                    context.SaveChanges();

                    ErrorMessage = "";
                }

            }
            else
            {
                ErrorMessage = "Campurile nu pot fi nule!";
            }
        }
        public ObservableCollection<GetProductsFromProducer_Result> GetProductsFromProducer(int producerID,int categoryID) 
        {
            ObservableCollection<GetProductsFromProducer_Result> results=new ObservableCollection<GetProductsFromProducer_Result>();
            var products=context.GetProductsFromProducer(producerID, categoryID).ToList();
            foreach( var product in products )
            {
                results.Add(product);
            }
            return results;
        }

    }
}
