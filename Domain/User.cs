using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Domain;

public class User 
{
    [Key]
    public long UserId { get; set; }

    public User()
    {
        Treatment = new List<Treatment>();
    }

    public long TreatmentId { get; set; }

    public List<Treatment> Treatment { get; set; } 
}