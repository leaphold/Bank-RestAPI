using bankApi.Filters;
using bankApi.Models;
using bankApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.Controller
{

  [ApiController]
  [Route("api/[controller]")]
  public class LoanController:ControllerBase
  {

    //GET ALL LOAN APPLICATIONS
    [HttpGet]
    public IActionResult GetAllLoanApplications()
    {
      var loanApplications = LoanRepository.GetAllLoanApplications();
      return Ok(loanApplications);
    }

    //GET LOAN APPLICATION BY USER ID
    [HttpGet("{id}")]
    [ValidateUserIdFilter]
    public IActionResult GetLoanApplicationsById(int id)
    {
      return Ok(LoanRepository.GetLoanApplicationById(id));
    }


    // CREATE LOAN APPLICATION
    [HttpPost]
    public IActionResult CreateLoanApplication([FromBody] LoanApplication newLoanApplication)
    {
      if (newLoanApplication == null)
      {
        return BadRequest("Invalid request body.");
      }

      var createdLoanApplication = LoanRepository.CreateLoanApplication(newLoanApplication);

      if (createdLoanApplication == null)
      {
        return BadRequest("Failed to create the loan application.");
      }

      return CreatedAtAction("GetLoanApplicationByLoanId", new { loanId = createdLoanApplication.LoanId }, createdLoanApplication);
    }


    //UPDATE LOAN APPLICATION
    [HttpPut("update/{loanId}")]
    public IActionResult UpdateLoanApplication(int loanId, [FromBody] LoanApplication updatedLoanApplication)
    {
      if (updatedLoanApplication == null)
      {
        return BadRequest("Invalid request body.");
      }

      var result = LoanRepository.UpdateLoanApplication(loanId, updatedLoanApplication);

      if (result == null)
      {
        return NotFound($"Loan application with ID {loanId} not found.");
      }

      return Ok(result);
    }

    //DELETE LOAN APPLICATION
    [HttpDelete("delete/{loanId}")]
    public IActionResult DeleteLoanApplication(int loanId)
    {
      var result = LoanRepository.DeleteLoanApplication(loanId);

      if (!result)
      {
        return NotFound($"Loan application with ID {loanId} not found.");
      }

      return Ok($"Loan application with ID {loanId} has been deleted.");
    }

    //GET LOAN APPLICATIONS BY STATUS
    [HttpGet("status/{status}")]
    public IActionResult GetLoanApplicationsByStatus(string status)
    {
      var loanApplications = LoanRepository.GetLoanApplicationsByStatus(status);

      if (loanApplications == null)
      {
        return NotFound($"Loan application with status {status} not found.");
      }
      return Ok(loanApplications);
    }

    //GET LOAN APPLICATION BY LOAN ID
    [HttpGet("loanId/{loanId}")]
    public IActionResult GetLoanApplicationByLoanId(int loanId)
    {
      var loanApplication = LoanRepository.GetLoanApplicationById(loanId);

      if (loanApplication == null)
      {
        return NotFound($"Loan application with ID {loanId} not found.");
      }

      return Ok(loanApplication);
    }
  }
}
