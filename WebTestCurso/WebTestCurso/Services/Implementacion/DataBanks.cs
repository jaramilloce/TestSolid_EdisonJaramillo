using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;
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

        /// <summary>
        /// llamada de los parametros por servicios
        /// </summary>
        /// <param name="Cuenta1"></param>
        /// <param name="Cuenta2"></param>
        /// <param name="Cuenta3"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Dni"></param>
        /// <returns></returns>
        public async Task<PresentacionInformacionDto> GetDataPresentInfoClientBuild(string Cuenta1, string Cuenta2, string Cuenta3, string Nombre, string Apellido, string Dni)
        {

            var dato = new DataPresentInfoClientBuild().Dni(Dni)
                .Cuenta1(Cuenta1)
                .Cuenta2(Cuenta2)
                .Cuenta3(Cuenta3)
                .Apellido(Apellido)
                .Nombre(Nombre)
                .Dni(Dni)
                .Build();
            

            return await Task.FromResult(dato);
        }
    }
}
