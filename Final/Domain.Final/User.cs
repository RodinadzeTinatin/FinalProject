using System.Collections.Generic;

namespace Domain.Final
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Monthlyincome { get; set; }
        public string Email { get; set; }
        public ICollection<Loan> Loans { get; set; }
        
    }
}
