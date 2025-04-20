using WebTestCurso.Dto;
using WebTestCurso.Services.Interfaces;
using WebTestCurso.Services.Singleton;

namespace WebTestCurso.Services.Implementacion
{
    public class DataBanks : IDataBank
    {
        private readonly DataUnifyOptionBank _dataUnifyOptionBank;
        private readonly ILogger<DataBanks> _logger;

        public DataBanks(DataUnifyOptionBank dataUnifyOptionBank, ILogger<DataBanks> logger)
        {
            _dataUnifyOptionBank = dataUnifyOptionBank;
            _logger = logger;
        }

        public async Task<object> GetDataBanks(string bank)
        {
            _logger.LogInformation("Llamada a data de GetDataBanks  : " + bank);
            var consultOpb = _dataUnifyOptionBank.GetDataBankUnify(bank);
            var dataBank = await consultOpb.GetDataBank(bank);
            return await Task.FromResult(dataBank);
        }


    }
}
