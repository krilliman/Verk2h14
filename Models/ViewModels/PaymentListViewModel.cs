namespace BookCave.Models.ViewModels
{
    public class PaymentListViewModel
    {
        public string Id { get; set; }
        public PaymentInfoViewModel Address1 {get; set;}
        public PaymentInfoViewModel Address2 {get; set;}
        public PaymentInfoViewModel Address3 {get; set;}
    }
}