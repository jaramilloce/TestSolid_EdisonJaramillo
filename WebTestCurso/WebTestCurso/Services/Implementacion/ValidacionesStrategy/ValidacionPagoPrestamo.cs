using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;
using WebTestCurso.Repository;

namespace WebTestCurso.Services.Implementacion.ValidacionesStrategy;

/// <summary>
/// Metodo de validación de una cuenta correcta
/// </summary>
public class ValidacionPagoPrestamo : IValidacionesVarias
{

    private readonly IRepoBankRepository _bankRepository;

    public ValidacionPagoPrestamo(IRepoBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public bool ValidaCuentaCorrecta(PagoPrestamoDto pagoPrestamoDto)
    {
        //return false;
        var resultado = _bankRepository.GetDataPrestamosBanks().Result;

        //Valida que la cuenta existe correctamente.
        var dataFiltrada = resultado.FirstOrDefault(x => x.CaprCodigo == Convert.ToInt32(pagoPrestamoDto.Cuenta1));

        if (dataFiltrada != null)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
    
}

/// <summary>
/// Metodo de validación de valores correctos de cuenta por valores
/// </summary>
public class ValidacionValoresCorrestos : IValidacionesVarias
{

    private readonly IRepoBankRepository _bankRepository;

    public ValidacionValoresCorrestos(IRepoBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public bool ValidaCuentaCorrecta(PagoPrestamoDto pagoPrestamoDto)
    {
        var resultado = _bankRepository.GetDataPrestamosBanks().Result;

        //Valida si existe la cuenta y valida que el prestamo este aun con saldo
        var dataFiltrada = resultado.FirstOrDefault(
            x => 
            x.CaprCodigo == Convert.ToInt32(pagoPrestamoDto.Cuenta1) &&
            x.CaprSaldo > pagoPrestamoDto.ValorPago
            );

        if (dataFiltrada != null)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}

