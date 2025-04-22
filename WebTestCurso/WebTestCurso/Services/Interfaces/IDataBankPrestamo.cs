using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;

namespace WebTestCurso.Services.Interfaces
{
    public interface IDataBankPrestamo
    {
        Task<PagoPrestamoDto> SetValoresPrestamos(PagoPrestamoDto pagoPrestamoDto);

    }
}
