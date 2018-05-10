using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
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
                            BookName = Bk.Name,
                            Quantity = Quantity,
                            TotalPrice = Bk.TotalPrice * Quantity
                        }).SingleOrDefault();
            var ItemToString = new List<string>();
            ItemToString.Add(Item.BookId.ToString());
            ItemToString.Add(Item.Price.ToString());
            ItemToString.Add(Item.Quantity.ToString());
            ItemToString.Add(Item.TotalPrice.ToString());
            ItemToString.Add(Item.BookName.ToString());

            
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
        public CheckOutViewModel CheckOut(CartViewModel Model)
        {
            var Addresses = (from Ab in _db.AddressTable
                            where Ab.UserId == Model.UserId
                            select new AddressViewModel
                            {
                                Id = Ab.Id,
                                StreetLine = Ab.StreetLine,
                                PostalCode = Ab.PostalCode,
                                Country = Ab.Country
                            }).ToList();
            var Payments = (from Pm in _db.CardInformationTable
                            where Pm.UserId == Model.UserId
                            select new PaymentInfoViewModel
                            {
                                Id = Pm.Id,
                                CardNumber = Pm.CardNumber,
                                CardHolder = Pm.CardHolder,
                                ExpireMonth = Pm.ExpireMonth,
                                ExpireYear = Pm.ExpireYear
                            }).ToList();
            var AddressBook = new AddressListViewModel(){AddressBook = Addresses};
            var PaymentBook = new PaymentListViewModel(){Payments = Payments};

            var CheckOutModel = new CheckOutViewModel()
            {
                Cart = Model,
                UserAddresses = AddressBook,
                UserPayments = PaymentBook
            };

            return CheckOutModel;
        }
        public AddressViewModel GetAddressById(int AddressId)
        {
            Console.WriteLine("AddressID: " + AddressId);
            var Address = (from Ad in _db.AddressTable
                            where Ad.Id == AddressId
                            select new AddressViewModel
                            {
                                Id = Ad.Id,
                                StreetLine = Ad.StreetLine,
                                PostalCode = Ad.PostalCode,
                                Country = Ad.Country
                            }).FirstOrDefault();
            return Address;
        }
        public PaymentInfoViewModel GetPaymentById(int PaymentId)
        {
            var Payment = (from Pm in _db.CardInformationTable
                            where Pm.Id == PaymentId
                            select new PaymentInfoViewModel
                            {
                                Id = Pm.Id,
                                CardNumber = Pm.CardNumber,
                                CardHolder = Pm.CardHolder,
                                ExpireMonth = Pm.ExpireMonth,
                                ExpireYear = Pm.ExpireYear
                            }).FirstOrDefault();
            return Payment;
        }
        public void AddOrder(CompleteOrderViewModel Model)
        {
            
            var Cart = Model.Cart.Cart;
            foreach(var CartItem in Cart)
            {
                int OrderID;
                if(_db.OrderTable.Count() == 0)
                {
                    OrderID = 1;
                }
                else
                {
                    OrderID = _db.OrderTable.Last().Id +1;
                }
                var OrderItem = new OrderItem()
                {
                    
                    OrderId = OrderID,
                    BookId = CartItem.BookId,
                    Quantity = CartItem.Quantity,
                    Price = CartItem.TotalPrice
                };
                _db.Add(OrderItem);
            }
            var Order = new Order()
            {
                UserId = Model.UserId,
                OrderPrice = Model.TotalPrice
            };
            _db.Add(Order);
            _db.SaveChanges();
        }
    }
}