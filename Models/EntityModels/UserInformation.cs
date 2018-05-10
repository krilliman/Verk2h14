namespace BookCave.Models.EntityModels
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Description { get; set; }
        public string FavBook { get; set; }
    }
}