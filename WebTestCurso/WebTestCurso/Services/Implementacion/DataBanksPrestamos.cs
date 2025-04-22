using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;
using WebTestCurso.Repository;
using WebTestCurso.Services.Implementacion.ValidacionesStrategy;
using WebTestCurso.Services.Interfaces;
using WebTestCurso.Services.Singleton;

namespace WebTestCurso.Services.Implementacion
{
    public class DataBanksPrestamos : IDataBankPrestamo
    {
        private readonly ILogger<DataBanks> _logger;
        private readonly IRepoBankRepository _bankRepository;
        private IValidacionesVarias _validacionesVarias;

        public DataBanksPrestamos(ILogger<DataBanks> logger, 
            IRepoBankRepository bankRepository, 
            IValidacionesVarias validacionesVarias
            )
        {
            _logger = logger;
            _bankRepository = bankRepository;
            _validacionesVarias = validacionesVarias;
        }

        public async Task<PagoPrestamoDto> SetValoresPrestamos(PagoPrestamoDto pagoPrestamoDto)
        {

            var resultado = new PagoPrestamoBuild(_bankRepository, _validacionesVarias)
               .Cuenta1(pagoPrestamoDto)
               .CuentaSaldoCorrectos(pagoPrestamoDto)
               .ControlesDni(pagoPrestamoDto)
               .Build();

            if (resultado.mensajeFinal == null) {
                pagoPrestamoDto.mensajeFinal = "Saldado con éxito";
                return Task.FromResult(pagoPrestamoDto).Result;
            } 

            return Task.FromResult(resultado).Result;
            
        }
    }
}
