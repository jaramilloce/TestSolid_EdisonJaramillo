using WebTestCurso.Dto;

namespace WebTestCurso.Repository
{
    public interface IRepoBankRepository
    {
        Task<List<DataPrestamoBankDto>> GetDataPrestamosBanks();
        Task<DataPrestamoBankDto> GetDataPrestamosBanksbyId(int codigo);

    }
}
