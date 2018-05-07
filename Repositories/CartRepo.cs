using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BookCave.Repositories
{
    public class CartRepo
    {
        private DataContext _db;
        //public CartViewModel Cart;

        public CartRepo()
        {
            _db = new DataContext();
            //Cart = new CartViewModel();
        }
        public string AddToCart(int BookId, int Quantity)
        {
            var Item = (from Bk in _db.BookTable
                        where Bk.ID == BookId
                        select new CartItemViewModel
                        {
                            BookId = BookId,
                            Price = Bk.TotalPrice,
                            Quantity = Quantity,
                            TotalPrice = Bk.TotalPrice * Quantity
                        }).SingleOrDefault();
            var ItemToString = new List<string>();
            ItemToString.Add(Item.BookId.ToString());
            ItemToString.Add(Item.Price.ToString());
            ItemToString.Add(Item.Quantity.ToString());
            ItemToString.Add(Item.TotalPrice.ToString());
            
            var RetVal = ItemToString.Aggregate((a, b) => a = a + "," + b);
            RetVal += "|";
            return RetVal;
            
        }
        public string CreateString(List<string> Cart)
        {
            string RetVal = "";
            for(var i = 0; i < Cart.Count();i++)
            {
                RetVal += Cart[i];
                if(!(i == Cart.Count-1))
                {
                    RetVal += "|";
                }
            }
            return RetVal;
        }
    }
}