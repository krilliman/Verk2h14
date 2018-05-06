namespace BookCave.Models.EntityModels
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Description { get; set; }
    }
}