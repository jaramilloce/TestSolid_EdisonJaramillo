using WebTestCurso.Dto;

namespace WebTestCurso.Services.Interfaces
{
    public interface IDataBank
    {
        Task<object> GetDataBanks(string id);
        
    }
}
