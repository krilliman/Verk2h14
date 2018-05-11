using BookCave.Models.InputModels;

namespace BookCave.Services
{
    public interface IAddressService
    {
        void ProccessAddress(AddressInputModel Address);
    }
}