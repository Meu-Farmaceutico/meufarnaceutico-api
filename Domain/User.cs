using Customers.Api.Domain.Common;

namespace Customers.Api.Domain;

public class User
{
    public User()
    {
        Medication = new List<Medication>();
    }

   public long Id { get; set; }

   public List<Medication>? Medication { get; set; }
}
