using System.Text;
using System.Security.Cryptography;
using MongoDB.Bson;

public class User {
    public User(string name, string LastName, string Email, string Password) 
    {
        this.Id = Guid.NewGuid();
        this.FirstName = name;
        this.LastName = LastName;
        this.Email = Email;
        this.Password = PasswordHasher.HashPassword(Password);
    }
    public Guid Id {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public string Email { get; set; }
    public string Password { get; set;}
    
}
