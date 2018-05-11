using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class ProfileRepo
    {
        private DataContext _db;

        public ProfileRepo()
        {
            _db = new DataContext();
        }

        public WishListViewModel GetMyWishList(int Id)
        {
            /*
            Here im fetching all WishListItems with wishListId equal to Id, 
            then i create a list out of it and make the List in WishListViewModel
            be equal to that list and return the WishListViewModel up to the controller.
             */
            var ListItems = (from Wl in _db.WishListItemTable
                            join Bk in _db.BookTable on Wl.BookId equals Bk.ID
                            where Wl.UserId == Id
                            select new WishListItemViewModel
                            {
                                Id = Wl.Id,
                                BookId = Bk.ID,
                                BookName = Bk.Name,
                                UserId = Id,
                                Image = Bk.Image,
                                Description = Bk.Description,
                                Rating = Bk.Rating

                            }).ToList();
            var MyWishList = new WishListViewModel(){Id = Id, Items = ListItems};
            return MyWishList;
        }
        public PaymentListViewModel GetMyPaymentList(int Id)
        {
            /*
            Here i find all Payment details that the user has and return it
            all the way back to the controller
             */
            var ListItems = (from Pl in _db.CardInformationTable
                            where Pl.UserId == Id
                            select new PaymentInfoViewModel
                            {
                                Id = Pl.Id,
                                CardNumber = Pl.CardNumber,
                                CardHolder = Pl.CardHolder,
                                ExpireMonth = Pl.ExpireMonth,
                                ExpireYear = Pl.ExpireYear
                            }).ToList();
            var List = new PaymentListViewModel()
            {
                Payments = ListItems
            };
            return List;
        }
        public int AddPayment(PaymentListViewModel Model)
        {
            /*
            Here im createing a new CardInformation from the model i get from the user
            and add it to the CardInformationTable
             */
            var Payment = new CardInformation()
            {
                CardHolder = Model.NewPayment.CardHolder,
                CardNumber = Model.NewPayment.CardNumber,
                UserId = Model.NewPayment.UserId,
                ExpireMonth = Model.NewPayment.ExpireMonth,
                ExpireYear = Model.NewPayment.ExpireYear
            };
            _db.Add(Payment);
            _db.SaveChanges();
            return Model.NewPayment.UserId;
        }
        public void DeletePayment(int PaymentId)
        {
            /*
            Here i find the payment to that the user wants to delete with PaymentId
             */
            var Payment = (from Pm in _db.CardInformationTable
                        where Pm.Id == PaymentId
                        select new CardInformation
                        {
                            Id = Pm.Id,
                            CardNumber = Pm.CardNumber,
                            CardHolder = Pm.CardHolder,
                            ExpireMonth = Pm.ExpireMonth,
                            ExpireYear = Pm.ExpireYear
                        }).FirstOrDefault();
            _db.Remove(Payment);
            _db.SaveChanges();
        }

        public UserViewModel GetInformation(int Id)
        {
            var Information = (from Usr in _db.UserInformationTable
                              where Usr.Id == Id
                              select new UserViewModel
                              {
                                  Description = Usr.Description,
                                  Image = Usr.ProfileImage,
                                  Name = Usr.Name,
                                  FavBook = Usr.FavBook,
                                  Id = Usr.Id
                              }).FirstOrDefault();
            return Information;
        }
        public List<OrdersViewModel> GetAllOrders(int Id)
        {
            var Orders = (from Od in _db.OrderTable
                            where Od.UserId == Id
                            select new OrdersViewModel
                            {
                                OrderId = Od.Id,
                                OrderPrice = Od.OrderPrice
                            }).ToList();
            foreach(var order in Orders)
            {
                var OrderItem = (from Oi in _db.OrderItemTable
                                where Oi.OrderId == order.OrderId
                                join Bk in _db.BookTable on Oi.BookId equals Bk.ID
                                select new OrderItemViewModel
                                {
                                    BookId = Oi.BookId,
                                    OrderId = Oi.OrderId,
                                    Quantity = Oi.Quantity,
                                    Price = Oi.Price,
                                    Name = Bk.Name,
                                    Image = Bk.Image
                                }).ToList();
                order.OrderItem = OrderItem;
            }
            return Orders;
        }
        public void EditUserInformation(UserViewModel Model)
        {
            var User = (from Usr in _db.UserInformationTable
                            where Usr.Id == Model.Id
                            select Usr).FirstOrDefault();
            if(User.ProfileImage != Model.Image)
            {
                User.ProfileImage = Model.Image;
            }
            else{}
                User.Description = Model.Description;
                User.FavBook = Model.FavBook;

            _db.SaveChanges();
        }
        public AddressListViewModel GetMyAddressBook(int Id)
        {
            var Countries = (from Ct in _db.CountryTable
                            select new CountryViewModel
                            {
                                Name = Ct.Name
                            }).ToList();
            var ListItems = (from Ab in _db.AddressTable
                            where Ab.UserId == Id
                            select new AddressViewModel
                            {
                                Id = Ab.Id,
                                StreetLine = Ab.StreetLine,
                                PostalCode = Ab.PostalCode,
                                Country = Ab.Country,
                                City = Ab.City,
                                Province = Ab.Province
                            }).ToList();

            var List = new AddressListViewModel()
            {
                AddressBook = ListItems,
                Countries = Countries
            };
            return List;
        }
        public int AddAddress(AddressListViewModel Model)
        {
            var Address = new Address
            {
                UserId = Model.NewAddress.UserId.Value,
                StreetLine = Model.NewAddress.StreetLine,
                PostalCode = Model.NewAddress.PostalCode,
                Country = Model.NewAddress.Country,
                City = Model.NewAddress.City,
                Province = Model.NewAddress.Province
            };
            _db.Add(Address);
            _db.SaveChanges();
            return Model.NewAddress.UserId.Value;
        }
        public void DeleteAddress(int AddressId)
        {
            var Address = (from Ad in _db.AddressTable
                            where Ad.Id == AddressId
                            select new Address
                            {
                                Id = Ad.Id,
                                UserId = Ad.UserId,
                                StreetLine = Ad.StreetLine,
                                PostalCode = Ad.PostalCode,
                                Country = Ad.Country,
                                City = Ad.City,
                                Province = Ad.Province
                            }).FirstOrDefault();
            _db.Remove(Address);
            _db.SaveChanges();
        }
    }
}