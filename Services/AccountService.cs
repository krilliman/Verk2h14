using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AccountService
    {

        private AccountRepo _accountRepo;

        public AccountService()
        {
            _accountRepo = new AccountRepo();
        }

        public void AddUserToTable(RegisterViewModel Model)
        {
            _accountRepo.AddUserToTable(Model);
        }
        
    }
}