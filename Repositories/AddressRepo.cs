using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class AddressRepo
    {
        private DataContext _db;

        public AddressRepo()
        {
            _db = new DataContext();
        }
        /*
        public AddressListViewModel GetMyAddressBook(int Id)
        {
            var Countries = (from Ct in _db.CountryTable
                            select new CountryVieWModel
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
        */
    }
}