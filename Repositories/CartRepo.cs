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
        private CookieOptions _options;

        public CartRepo()
        {
            _db = new DataContext();
            //Cart = new CartViewModel();
            _options = new CookieOptions();
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

            
            var RetVal = ItemToString.Aggregate((a, b) => a = a + "|" + b);
            RetVal += "<";
            return RetVal;
            
        }
        public string CreateString(List<string> Cart)
        {
            string RetVal = "";
            for(var i = 0; i < Cart.Count();i++)
            {
                RetVal += Cart[i];
                RetVal += "<";
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
            var CountriesView = (from Ct in _db.CountryTable
                            select new CountryViewModel
                            {
                                Name = Ct.Name
                            }).ToList();
            var AddressBook = new AddressListViewModel(){AddressBook = Addresses, Countries = CountriesView};
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
        
        public List<string> SplitItems(string Cart)
        {
            Console.WriteLine("Cart: "+ Cart);
            var ListOfWords = new List<string>();
            if(Cart != null )
            {
                ListOfWords.AddRange(Cart.Split(new char[] { '<' }, StringSplitOptions.RemoveEmptyEntries));
            }
            return ListOfWords;
        }
        public CartViewModel CreateView(List<string> ItemList)
        {
            var Cart = new CartViewModel();
            var CartList = new List<CartItemViewModel>();
            double CartTotal = 0.0;
            for(var i = 0; i < ItemList.Count();i++)
            {
                var ListOfVars = new List<string>();
                ListOfVars.AddRange(ItemList[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                var CartItem = new CartItemViewModel()
                {
                    Id = i+1,
                    BookId = Int32.Parse(ListOfVars[0]),
                    Price = Double.Parse(ListOfVars[1]),
                    Quantity = Int32.Parse(ListOfVars[2]),
                    TotalPrice = Double.Parse(ListOfVars[3]),
                    BookName = ListOfVars[4]
                };
                CartList.Add(CartItem);
                CartTotal += CartItem.TotalPrice;
            }
            Cart.Cart = CartList;
            Cart.CartTotalPrice = CartTotal;
            return Cart;
        }
        public CompleteOrderViewModel CompleteOrder(CheckOutViewModel Model, int AddressId, int PaymentId)
        {
            var CompleteOrder = new CompleteOrderViewModel();
            if(PaymentId != 0 && AddressId != 0)
            {
                var Payment = GetPaymentById(PaymentId);
                var Address = GetAddressById(AddressId);
                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            else if(PaymentId != 0 && AddressId == 0)
            {
                var Payment = GetPaymentById(PaymentId);
                var Address = new AddressViewModel()
                {
                    StreetLine = Model.UserAddresses.NewAddress.StreetLine,
                    PostalCode = Model.UserAddresses.NewAddress.PostalCode,
                    Country = Model.UserAddresses.NewAddress.Country
                };

                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            else if(PaymentId == 0 && AddressId != 0)
            {
                var Address = GetAddressById(AddressId);
                var Payment = new PaymentInfoViewModel()
                {
                    CardHolder = Model.UserPayments.NewPayment.CardHolder,
                    CardNumber = Model.UserPayments.NewPayment.CardNumber,
                    ExpireMonth = Model.UserPayments.NewPayment.ExpireMonth,
                    ExpireYear = Model.UserPayments.NewPayment.ExpireYear
                };
                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            else
            {
                var Address = new AddressViewModel()
                {
                    StreetLine = Model.UserAddresses.NewAddress.StreetLine,
                    PostalCode = Model.UserAddresses.NewAddress.PostalCode,
                    Country = Model.UserAddresses.NewAddress.Country
                };
                var Payment = new PaymentInfoViewModel()
                {
                    CardHolder = Model.UserPayments.NewPayment.CardHolder,
                    CardNumber = Model.UserPayments.NewPayment.CardNumber,
                    ExpireMonth = Model.UserPayments.NewPayment.ExpireMonth,
                    ExpireYear = Model.UserPayments.NewPayment.ExpireYear
                };
                CompleteOrder.UserAddress = Address;
                CompleteOrder.UserPayment = Payment;
            }
            return CompleteOrder;
        }
    }
}