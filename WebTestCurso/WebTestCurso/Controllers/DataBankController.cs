using Microsoft.AspNetCore.Mvc;
using WebTestCurso.Dto;
using WebTestCurso.Services.Implementacion;
using WebTestCurso.Services.Interfaces;
using WebTestCurso.Dto.DtoBuilder;

namespace WebTestCurso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBankController : ControllerBase
    {
        
        private readonly IDataBankProdubanco _dataBankProdubanco;
        private readonly IDataBank _dataBank;
        private readonly IDataBankPrestamo _dataBankPrestamo;

        public DataBankController(IDataBankProdubanco dataBankProdubanco,
            IDataBank dataBank,
            IDataBankPrestamo dataBankPrestamo)
        {
            _dataBankProdubanco = dataBankProdubanco;
            _dataBank = dataBank;
            _dataBankPrestamo = dataBankPrestamo;
        }


        /// <summary>
        /// Data de Produbanco
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDataBankProdubanco")]
        public async Task<IActionResult> GetDataBankProdubanco()
        {
            var reult = await _dataBankProdubanco.GetDataBank(1);
            return Ok(reult);
        }

        /// <summary>
        /// Data unificada
        /// </summary>
        /// <param name="bnks"></param>
        /// <returns></returns>
        [HttpGet("GetDataBanks")]
        public async Task<IActionResult> GetDataBanks(string bnks)
        {
            var reult = await _dataBank.GetDataBanks(bnks);
            return Ok(reult);
        }


        [HttpPost("GetDataPresentInfoClientBuild")]
        public async Task<IActionResult> GetDataPresentInfoClientBuild([FromBody] PresentacionInformacionDto presentacionInformacionDto)
        {
            try {

                var reult = await _dataBank.GetDataPresentInfoClientBuild
                (presentacionInformacionDto.Cuenta1,
                presentacionInformacionDto.Cuenta2,
                presentacionInformacionDto.Cuenta3,
                presentacionInformacionDto.Nombre,
                presentacionInformacionDto.Apellido,
                presentacionInformacionDto.Dni);

                return Ok(reult.mensajeFinal);
            }
            catch (Exception ex) {

                return Ok(ex.Message);
            }
            
        }

        [HttpPost("SetValoresPrestamos")]
        public async Task<IActionResult> SetValoresPrestamos([FromBody] PagoPrestamoDto pagoPrestamoDto)
        {
            try
            {
                var data = await _dataBankPrestamo.SetValoresPrestamos(pagoPrestamoDto);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }

        }
    }
}
