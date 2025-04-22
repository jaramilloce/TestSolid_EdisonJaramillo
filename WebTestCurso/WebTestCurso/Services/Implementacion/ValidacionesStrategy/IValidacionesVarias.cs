using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;

namespace WebTestCurso.Services.Implementacion.ValidacionesStrategy;

public interface IValidacionesVarias
{
    bool ValidaCuentaCorrecta(PagoPrestamoDto pagoPrestamoDto);

    DataPrestamoBankDto ValidaValoresCuentaCorrecta(PagoPrestamoDto pagoPrestamoDto);
}

