Jag lägger till denna readme för att jag inte kunde redigera den befintliga då tiden gick ut i fredags.

Följande funktioner finns i mitt API:
(Alla är exempel, byt ut local host port mot din egna)

GetAllLoanApplications: Listar alla låneansökningar som finns hårdkodade. 
För att nå endpoint: GET https://localhost:7032/api/loan/

GetLoanApplicationsById:
Hämta lån baserat på användarid.
För att nå endpoint:GET https://localhost:7032/api/loan/userId/2

CreateLoanApplication:
Skapar ny låneansökan. här behöver body ha info att skapa en ny ansökan efter tex:

{
    "Date": "2024-01-27T22:07:36.5193686+01:00",
    "LoanStatus": "Pending",
    "UserId": 4
}
För att nå endpoint: POST https://localhost:7032/api/loan/

UpdateLoanApplication:
Hämtar befintlig ansökan efter låneid för att uppdater
För att nå endpoint: PUT https://localhost:7032/api/loan/update/3

DeleteLoanApplication:
Hämtar och tar bort lån baserat på låneid
För att nå endpoint:DELETE https://localhost:7032/api/loan/delete/1

GetLoanApplicationsByStatus:
Hämtar lån baserat på status, "Approved" eller "Denied"

För att nå endpoint:https://localhost:7032/api/loan/status/Denied

GetLoanApplicationByLoanId:

Hämtar ansökan efter låneid.
För att nå endpoint:https://localhost:7032/api/loan/1

--Alfred

