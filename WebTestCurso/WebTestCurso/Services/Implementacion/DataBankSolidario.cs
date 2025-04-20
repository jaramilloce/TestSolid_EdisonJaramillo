using WebTestCurso.Dto;
using WebTestCurso.Services.Interfaces;

namespace WebTestCurso.Services.Implementacion
{
    public class DataBankSolidario : IDataBankSolidario
    {
        public async Task<Bank> GetDataBank(int id)
        {

            Bank bank = new Bank();

            bank.BankName = "Solidario";
            bank.Description = "Banco Solidario";
            bank.Id = Guid.NewGuid().ToString();

            return (bank);
        }

        public Task<Client> GetDataClient(int id)
        {
            throw new NotImplementedException();
        }
    }
}
