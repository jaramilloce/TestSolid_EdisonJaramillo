using WebTestCurso.Dto;

namespace WebTestCurso.Services.Interfaces
{
    public interface IDataBankUnify
    {
        Task<object> GetDataBank(string bnk);
       
    }
}
