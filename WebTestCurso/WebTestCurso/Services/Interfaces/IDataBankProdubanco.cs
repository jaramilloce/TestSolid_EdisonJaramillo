using WebTestCurso.Dto;

namespace WebTestCurso.Services.Interfaces
{
    public interface IDataBankProdubanco
    {
        Task<Bank> GetDataBank(int id);
        Task<Client> GetDataClient(int id);
    }
}
