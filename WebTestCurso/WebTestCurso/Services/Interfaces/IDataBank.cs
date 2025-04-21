using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;

namespace WebTestCurso.Services.Interfaces
{
    public interface IDataBank
    {
        Task<object> GetDataBanks(string id);

        Task<PresentacionInformacionDto> GetDataPresentInfoClientBuild(string Cuenta1, string Cuenta2, string Cuenta3, string Nombre, string Apellido, string Dni);

    }
}
