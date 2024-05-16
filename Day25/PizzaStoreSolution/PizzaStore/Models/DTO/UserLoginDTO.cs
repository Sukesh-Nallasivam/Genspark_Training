namespace PizzaStore.Models.DTO
{
    public class UserLoginDTO
    {
        public Customer? CustomerEmail { get; set; }
        public UserAccount? Password { get; set; }
    }
}
