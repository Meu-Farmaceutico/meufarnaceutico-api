using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace MeufarmaceuticoApi.Domain.Common;

public class Treatment
{
     public long TreatmentId { get; set; }

     public string Name { get; set; }

     public DateTime InitialDate { get; set; }

     public DateTime FinalDate { get; set; }
}