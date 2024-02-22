namespace bankApi.Models
{

    public class User

  {
    public int Id { get; set; }
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public int Income {get; set;}


    public ICollection<LoanApplication> LoanApplications {get; set;}
  }
}
