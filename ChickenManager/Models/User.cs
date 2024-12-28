namespace ChickenManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatorName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
