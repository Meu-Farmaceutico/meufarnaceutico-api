using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace MeufarmaceuticoApi.Domain.Common;

public class Medication
{
     public int MedicationId { get; set; }

     public string NameMedication { get; set; }

     public string Description { get; set; }
}
