
namespace bankApi.Models
{

  public class LoanApplication
  {
    public int? LoanId { get; set; }
    public DateTime? Date { get; set; }
    public string? LoanStatus { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
  }
}
