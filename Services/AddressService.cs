using System;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Services;
using BookCave.Repositories;


//Má eyða þessari skrá
namespace BookCave.Services
{
    public class AddressService : IAddressService
    {
        private AddressRepo _addressRepo;

        public AddressService()
        {
            _addressRepo = new AddressRepo();
        }
        
        public void ProccessAddress(AddressInputModel Address)
        {
            if(string.IsNullOrEmpty(Address.StreetLine)){throw new Exception("Subject Is missing");}
            if(string.IsNullOrEmpty(Address.PostalCode)){throw new Exception("PostalCode Is missing");}
            if(string.IsNullOrEmpty(Address.Country)){throw new Exception("Country Is missing");}
            if(string.IsNullOrEmpty(Address.City)){throw new Exception("City Is missing");}
        }
        /*
        public int AddAddress(AddressListViewModel Model)
        {
            var UserId = _addressRepo.AddAddress(Model);
            return UserId;
        }
        public void DeleteAddress(int AddressId)
        {
            _addressRepo.DeleteAddress(AddressId);
        }
        public AddressListViewModel GetMyAddressBook(int Id)
        {
            var MyAddressBook = _addressRepo.GetMyAddressBook(Id);
            return MyAddressBook;
        }
        */

    }
}