using System.ComponentModel.DataAnnotations;
using WebTestCurso.Dto.DtoBuilder;
using WebTestCurso.Services.Implementacion.ValidacionesStrategy;
namespace WebTestCurso.Services.Implementacion.ValidacionesStrategy;

public class ValidacionPagoPrestamoContexto
{
    private IValidacionesVarias _validacionesVarias;


    public ValidacionPagoPrestamoContexto(IValidacionesVarias validacionesVarias)
    {
        _validacionesVarias = validacionesVarias;
    }

    public void EstablecerValidador(IValidacionesVarias validador)
    {
        _validacionesVarias = validador;
    }

    public bool Validar(PagoPrestamoDto pagoPrestamoDto)
    {
        return _validacionesVarias.ValidaCuentaCorrecta(pagoPrestamoDto);
    }

}

