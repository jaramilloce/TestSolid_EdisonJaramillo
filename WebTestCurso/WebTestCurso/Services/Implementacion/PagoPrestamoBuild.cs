using WebTestCurso.Dto.DtoBuilder;
using WebTestCurso.Repository;
using WebTestCurso.Services.Implementacion.ValidacionesStrategy;
namespace WebTestCurso.Services.Implementacion;


//Creo una clase que divida a un DTO con las caractetisitcas que una logica pueda necesitar.
//Parte desde el DTO.
public class PagoPrestamoBuild
{
    /// <summary>
    /// Instacia al dto de data de cliente
    /// </summary>
    private readonly PagoPrestamoDto _pagoPrestamoDto = new();
    private readonly IRepoBankRepository _bankRepository;
    private IValidacionesVarias _validacionesVarias;

    public PagoPrestamoBuild(IRepoBankRepository bankRepository, IValidacionesVarias validacionesVarias )
    {
        _bankRepository = bankRepository;
        _validacionesVarias = validacionesVarias;
    }

    public PagoPrestamoBuild Cuenta1(PagoPrestamoDto pago)
    {
        var context = new ValidacionPagoPrestamoContexto(new ValidacionPagoPrestamo(_bankRepository));
        var resultadoVal = context.Validar(pago);

        if (!resultadoVal)
        {
            this._pagoPrestamoDto.mensajeFinal += $"Cuenta {pago.Cuenta1} no existe, ";
        }


        return this;

    }

    public PagoPrestamoBuild CuentaSaldoCorrectos(PagoPrestamoDto pago)
    {
        var context = new ValidacionPagoPrestamoContexto(new ValidacionValoresCorrestos(_bankRepository));

        var resultadoValCir = context.Validar(pago);

        if (!resultadoValCir) {
            this._pagoPrestamoDto.mensajeFinal += "Verifique que los valores sean los correctos, ";
        }
        
        return this;

    }

    public PagoPrestamoBuild ControlesDni(PagoPrestamoDto pago)
    {
        var context = new ValidacionPagoPrestamoContexto(new ValidacionDni(_bankRepository));

        var resultadoValCir = context.Validar(pago);

        if (!resultadoValCir)
        {
            this._pagoPrestamoDto.mensajeFinal += " Dni no existe, ";
        }

        return this;

    }

    public PagoPrestamoDto Build() => _pagoPrestamoDto;

}

