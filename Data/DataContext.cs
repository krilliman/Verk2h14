using BookCave.Models.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace BookCave.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Address> AddressTable { get; set; }
        public DbSet<Author> AuthorTable { get; set;}
        public DbSet<Book> BookTable { get; set; }
        public DbSet<CardInformation> CardInformationTable { get; set;}
        public DbSet<CartItem> CartItemTable { get; set;}
        public DbSet<Category> CategoryTable  { get; set;}   
        public DbSet<OrderItem> OrderItemTable { get; set; }
        public DbSet<Publisher> PublisherTable { get; set;} 
        public DbSet<Rating> RatingTable { get; set;}   
        public DbSet<SubCategory> SubCategoryTable { get; set; }
        public DbSet<UserInformation> UserInformationTable { get; set; }
        public DbSet<WishListItem> WishListItemTable { get; set;}
        public DbSet<Order> OrderTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H14;Persist Security Info=False;User ID=VLN2_2018_H14_usr;Password=lushFl@g59;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
    }
}