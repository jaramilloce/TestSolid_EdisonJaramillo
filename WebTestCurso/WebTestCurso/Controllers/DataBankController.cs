using Microsoft.AspNetCore.Mvc;
using WebTestCurso.Dto;
using WebTestCurso.Services.Implementacion;
using WebTestCurso.Services.Interfaces;

namespace WebTestCurso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBankController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        
        private readonly IDataBankProdubanco _dataBankProdubanco;
        private readonly IDataBank _dataBank;

        public DataBankController(IDataBankProdubanco dataBankProdubanco, 
            IDataBank dataBank)
        {
            _dataBankProdubanco = dataBankProdubanco;
            _dataBank = dataBank;
        }

       

        [HttpGet("GetDataBankProdubanco")]
        public async Task<IActionResult> GetDataBankProdubanco()
        {
            var reult = await _dataBankProdubanco.GetDataBank(1);
            return Ok(reult);
        }

        [HttpGet("GetDataBanks")]
        public async Task<IActionResult> GetDataBanks(string bnks)
        {
            var reult = await _dataBank.GetDataBanks(bnks);
            return Ok(reult);
        }
    }
}
