using WebTestCurso.Dto;
using WebTestCurso.Services.Interfaces;

namespace WebTestCurso.Services.Implementacion
{
    public class DataBankProdubanco : IDataBankProdubanco
    {
        public async Task<Bank> GetDataBank(int id)
        {
            Bank bank = new Bank();

            bank.BankName = "Produbanco";
            bank.Description = "Banco produbanco";
            bank.Id = Guid.NewGuid().ToString();


            return (bank);
        }

        public async Task<Client> GetDataClient(int id)
        {
            throw new NotImplementedException();
        }
    }
}
