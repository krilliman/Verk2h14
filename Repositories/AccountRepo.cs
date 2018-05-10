using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AccountRepo
    {
        private DataContext _db;

        public AccountRepo()
        {
            _db = new DataContext();
        }

        public int AddUserToTable(RegisterViewModel Model)
        {
            /*
            Here I fetch the id of the last registerd user and create a Id for the Lists in our
            new UserInformation table, so it has the same id as our new user.
             */
            var LastUserInInfoTable = _db.UserInformationTable.LastOrDefault();
            int NextId;
            if(LastUserInInfoTable == null)
            {
                NextId = 1;
            }
            else
            {
                NextId = LastUserInInfoTable.Id+1;
            }
            var UserInfo = new UserInformation()
            {
                Username = Model.Email,
                ProfileImage = Model.Image,
                Name = Model.Name
            };
            _db.UserInformationTable.Add(UserInfo);
            _db.SaveChanges();
            return NextId;
        }
    }
}