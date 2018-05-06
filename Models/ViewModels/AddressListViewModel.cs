using System.Collections.Generic;
using BookCave.Models.InputModels;

namespace BookCave.Models.ViewModels
{
    public class AddressListViewModel
    {
        public List<AddressViewModel> AddressBook { get; set; }
        public AddressInputModel NewAddress { get; set; }
    }
}