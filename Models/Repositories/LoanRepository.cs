using bankApi.Models;

namespace bankApi.Repositories
{
  public static class LoanRepository
  {
    private static List<User> users = new List<User>()
    {
      new User { Id=1, FirstName="Alfred", LastName="Hitchcock", Income=100000 },
          new User { Id=2, FirstName="Steven", LastName="Spielberg", Income=200000 },
          new User { Id=3, FirstName="Martin", LastName="Scorsese", Income=300000 },
          new User { Id=4, FirstName="Quentin", LastName="Tarantino", Income=400000 }
    };

    private static List<LoanApplication> loanApplications = new List<LoanApplication>()
    {
      new LoanApplication { LoanId=1, Date=DateTime.Now, LoanStatus="Denied", UserId=1 },
          new LoanApplication { LoanId=2, Date=DateTime.Now, LoanStatus="Denied", UserId=2 },
          new LoanApplication { LoanId=3, Date=DateTime.Now, LoanStatus="Approved", UserId=3 },
          new LoanApplication { LoanId=4, Date=DateTime.Now, LoanStatus="Approved", UserId=4 }
    };


    public static bool UserExists(int id)
    {
      return users.Any(u => u.Id == id);
    }

    public static bool LoanExists(int loanId)
    {
      return loanApplications.Any(l => l.LoanId == loanId);
    }


    //List of all loan applications
    public static List<LoanApplication> GetAllLoanApplications()
    {
      var loanApplicationsWithUsers = loanApplications.Select(loan =>
          {
          var user = users.FirstOrDefault(u => u.Id == loan.UserId);
          loan.User = user;
          return loan;
          }).ToList();

      return loanApplicationsWithUsers;
    }


    //get loan applications by user id
    public static List<LoanApplication> GetLoanApplicationsByUserId(int userId)
    {
      var borrowerLoanApplications = loanApplications
        .Where(l => l.UserId == userId)
        .Select(loan =>
            {
            loan.User = users.FirstOrDefault(u => u.Id == loan.UserId);
            return loan;
            }).ToList();

      return borrowerLoanApplications;
    }

    // Create loan application
    public static LoanApplication CreateLoanApplication(LoanApplication loanApplication)
    {
      loanApplication.LoanId = loanApplications.Max(l => l.LoanId) + 1;
      loanApplication.Date = DateTime.Now;
      loanApplication.LoanStatus = "Pending";

      loanApplications.Add(loanApplication);

      return loanApplication;
    }


    //Update loan application
    public static LoanApplication UpdateLoanApplication(int loanId, LoanApplication updatedLoanApplication)
    {
      if (!LoanExists(loanId))
      {
        return null;
      }

      var existingLoanApplication = GetLoanApplicationById(loanId);

      if (existingLoanApplication == null)
      {
        return null;
      }

      existingLoanApplication.LoanStatus = updatedLoanApplication.LoanStatus;

      return existingLoanApplication;
    }

    //Delete loan application
    public static bool DeleteLoanApplication(int loanId)
    {
      if (!LoanExists(loanId))
      {
        return false;
      }

      var loanToRemove = loanApplications.FirstOrDefault(l => l.LoanId == loanId);
      loanApplications.Remove(loanToRemove);

      return true;
    }

    // Get loan applications by status
    public static List<LoanApplication> GetLoanApplicationsByStatus(string status)
    {
      var filteredLoanApplications = loanApplications
        .Where(l => l.LoanStatus.Equals(status, StringComparison.OrdinalIgnoreCase))
        .Select(loan =>
            {
            var user = users.FirstOrDefault(u => u.Id == loan.UserId);
            if (user != null)
            {
            loan.User = user;
            }
            return loan;
            }).ToList();

      return filteredLoanApplications;
    }
    //Get loan application by loanid
    public static LoanApplication GetLoanApplicationById(int id)
    {
      var loanApplication = loanApplications.FirstOrDefault(l => l.LoanId == id);

      if (loanApplication != null)
      {
        var user = users.FirstOrDefault(u => u.Id == loanApplication.UserId);
        loanApplication.User = user;
      }

      return loanApplication;
    }
  }
}
