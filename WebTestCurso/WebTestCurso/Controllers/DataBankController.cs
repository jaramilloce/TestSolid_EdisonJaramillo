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

        public DataBankController(IDataBankProdubanco dataBankProdubanco,
            IDataBank dataBank)
        {
            _dataBankProdubanco = dataBankProdubanco;
            _dataBank = dataBank;
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
            var reult = await _dataBank.GetDataPresentInfoClientBuild
                (presentacionInformacionDto.Cuenta1,
                presentacionInformacionDto.Cuenta2,
                presentacionInformacionDto.Cuenta3,
                presentacionInformacionDto.Nombre,
                presentacionInformacionDto.Apellido,
                presentacionInformacionDto.Dni);

            
            return Ok(reult.mensajeFinal);
        }
    }
}
