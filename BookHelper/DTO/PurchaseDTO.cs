namespace BookAPI.DTO
{
    public class PurchaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BookID { get; set; }
        public int? ElectronicID { get; set; }
        public string Email { get; set; }
        public int? PurchaseNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
