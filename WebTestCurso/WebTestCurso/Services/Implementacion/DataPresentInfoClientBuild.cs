using WebTestCurso.Dto.DtoBuilder;
namespace WebTestCurso.Services.Implementacion;

//Creo una clase que divida a un DTO con las caractetisitcas que una logica pueda necesitar.
//Parte desde el DTO.
public class DataPresentInfoClientBuild
{

    private readonly PresentacionInformacionDto _presentacionInformacion = new();

    public DataPresentInfoClientBuild Cuenta1(string cuenta1) {

        _presentacionInformacion.Cuenta1 = cuenta1;

        return this;

    }

    public PresentacionInformacionDto Build() => _presentacionInformacion;

}

