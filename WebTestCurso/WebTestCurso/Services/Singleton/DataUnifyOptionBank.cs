
using WebTestCurso.Dto;
using WebTestCurso.Services.Interfaces;

//De donde debo llamarlo
namespace WebTestCurso.Services.Singleton;

public class DataUnifyOptionBank
{

    public IDataBankUnify GetDataBankUnify(string bnk) {

        switch (bnk)
        {
            case "sol":
                return new BankSolidario(bnk);
                break;
            case "pdb":
                return new BankProdubanco(bnk);
                break;
            default:
                return new BankNull(bnk);
                break;
        }
                
    }
}

public class BankProdubanco(string bnk)  : IDataBankUnify
{
    public async Task<object> GetDataBank(string bnk)
    {
        //Bank bank = new Bank();
        dynamic bank = new System.Dynamic.ExpandoObject();
        bank.Produ_Name = "Produbanco";
        bank.Produ_Description = "Banco produbanco";
        bank.Produ_Direccion = "Av Amazonas";
        bank.Produ_Ubicacion = "Parque la Carolina";
        bank.Produ_Id = Guid.NewGuid().ToString();

        return bank;
    }
}

public class BankSolidario(string bnk) : IDataBankUnify
{
    public async Task<object> GetDataBank(string bnk)
    {
        dynamic bank = new System.Dynamic.ExpandoObject();
        bank.Solidario_BankName = "Solidario";
        bank.Solidario_Description = "Banco Solidario";
        bank.Solidartio_Id = Guid.NewGuid().ToString();
        return bank;
    }
}

public class BankNull(string bnk) : IDataBankUnify
{
    public async Task<object> GetDataBank(string bnk)
    {
        dynamic bank = new System.Dynamic.ExpandoObject();
        bank.Mensaje = "Código enviado no existe";
        bank.Id = Guid.NewGuid().ToString();
        return bank;
    }
}

