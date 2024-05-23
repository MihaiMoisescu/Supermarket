using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class StockBLL
    {
        private SupermarketDBEntities context;

        
        public string ErrorMessage { get; set; }
        public StockBLL()
        {
            context = new SupermarketDBEntities();
        }

        public ObservableCollection<Stock> StocksList { get; set; }


        public ObservableCollection<Stock> GetAllStocks()
        {
            var stocks = context.Stocks.ToList();
            var result = new ObservableCollection<Stock>();

            foreach(var stock in stocks)
                result.Add(stock);
            return result;
        }

        public void AddStock(object obj)
        {
            Stock stock=obj as Stock;
            if(stock != null)
            {
                if(stock.ProductID.ToString()==null)
                    ErrorMessage = "ProductID nu poate fi null";
                else if(stock.Quantity==null)
                    ErrorMessage = "Trebuie sa introduceti o cantitate";
                else if(stock.PurchasePrice==null)
                    ErrorMessage = "Precizati pretul de achizitie";
                else if(stock.DateOfSupply==null)
                    ErrorMessage = "Precizati data de achizitie";
                else
                {
                    stock.SellingPrice = Helper.Functions.GetSellingPrice(stock.PurchasePrice);
                    stock.IsActive= true;
                    context.AddStock(stock.ProductID, stock.Quantity, stock.IsActive, stock.Unit, stock.DateOfSupply, stock.ExpirationDate, stock.PurchasePrice, stock.SellingPrice, new ObjectParameter("stockID", stock.StockID));
                    context.SaveChanges();
                    stock.StockID=context.Stocks.Max(x => x.StockID);
                    StocksList.Add(stock);
                    ErrorMessage = "";
                }
            }
            else
            {
                ErrorMessage = "Nu puteti introduce un stock null.";
            }
        }
        public void DeleteStock(object obj)
        {
            Stock stock= obj as Stock;
            if(stock!=null)
            {
                stock.IsActive = false;
                context.DeleteStock(stock.StockID, stock.IsActive);
                context.SaveChanges();
                StocksList.FirstOrDefault(o => o.StockID == stock.StockID).IsActive = false;
                ErrorMessage = "";
            }
        }

        public void UpdateStock(object obj)
        {
            Stock stock= obj as Stock;
            if(stock!=null)
            {
                if (stock.PurchasePrice > stock.SellingPrice)
                    ErrorMessage = "Pret de vanzare prea mic.";
                else
                {
                    context.ModifyStock(stock.StockID,stock.SellingPrice);
                    context.SaveChanges() ;
                    StocksList.FirstOrDefault(o=>o.StockID==stock.StockID).SellingPrice = stock.SellingPrice;
                    ErrorMessage = "";
                }
            }
        }
       
    }
}
