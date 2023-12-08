using BusinessLayer.Exceptions;

namespace BusinessLayer.Model
{
    public class Contact
    {
        public Contact(string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            {
                throw new ContactException("Not an Email adress");
            }
            if (string.IsNullOrWhiteSpace(phone) && !phone.All(char.IsDigit))
            {
                throw new ContactException("Not a valid phone");
            }
            Phone = phone;
            Email = email;
        }

        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
