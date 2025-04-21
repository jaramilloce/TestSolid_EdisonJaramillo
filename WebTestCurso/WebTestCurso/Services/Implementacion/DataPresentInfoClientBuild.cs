using WebTestCurso.Dto.DtoBuilder;
namespace WebTestCurso.Services.Implementacion;

//Creo una clase que divida a un DTO con las caractetisitcas que una logica pueda necesitar.
//Parte desde el DTO.
public class DataPresentInfoClientBuild
{
    /// <summary>
    /// Instacia al dto de data de cliente
    /// </summary>
    private readonly PresentacionInformacionDto _presentacionInformacion = new();

    /// <summary>
    /// Subdivicion de cada caracteristica del Dto.
    /// </summary>
    /// <param name="cuenta1"></param>
    /// <returns></returns>
    public DataPresentInfoClientBuild Cuenta1(string cuenta1) {

        //Valida que este ingresando bien.
        if (string.IsNullOrEmpty(cuenta1)) throw new Exception("valor cuenta1 es null");

        _presentacionInformacion.Cuenta1 = cuenta1;

        _presentacionInformacion.mensajeFinal += $" Cuenta 1 aplicada {cuenta1} ";
        return this;

    }

    public DataPresentInfoClientBuild Cuenta2(string cuenta2)
    {

        //Valida que este ingresando bien.
        if (string.IsNullOrEmpty(cuenta2)) throw new Exception("valor cuenta2 es null");

        //Valida cuenta
        if(_presentacionInformacion.Cuenta1 == _presentacionInformacion.Cuenta2) throw new Exception("Cuenta 1 y Cuenta 2 no pueden ser iguales");

        _presentacionInformacion.Cuenta2 = cuenta2;
        _presentacionInformacion.mensajeFinal += $" Cuenta 2 aplicada {cuenta2} ";
        return this;

    }


    /// <summary>
    /// Cuenta 3 debe tener al menos 5 caracteres
    /// </summary>
    /// <param name="Cuenta3"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public DataPresentInfoClientBuild Cuenta3(string Cuenta3)
    {

        //Valida que este ingresando bien.
        if (string.IsNullOrEmpty(Cuenta3)) throw new Exception("valor Cuenta3 es null");

        if (Cuenta3.Length < 5) throw new Exception(" Cuenta 3 debe tener al menos 5 caracteres");

        _presentacionInformacion.Cuenta3 = Cuenta3;
        _presentacionInformacion.mensajeFinal += $" Cuenta 3 aplicada {Cuenta3} ";
        return this;

    }

    public DataPresentInfoClientBuild Nombre(string Nombre)
    {

        //Valida que este ingresando bien.
        if (string.IsNullOrEmpty(Nombre)) throw new Exception("valor Nombre es null");

        _presentacionInformacion.Nombre = Nombre;
        return this;

    }


    public DataPresentInfoClientBuild Apellido(string apellido)
    {

        //Valida que este ingresando bien.
        if (string.IsNullOrEmpty(apellido)) throw new Exception("valor apellido es null");


        _presentacionInformacion.Apellido = apellido;
        return this;

    }


    public DataPresentInfoClientBuild Dni(string dni)
    {

        //Valida que este ingresando bien.
        if (string.IsNullOrEmpty(dni)) throw new Exception("valor apellido es null");

        if (dni.Length < 10) throw new Exception("Dni no puede ser menor que 10 digitos");

        if (dni.Length == 10) { _ = _presentacionInformacion.Dni == "Es una cedula"; }

        if (dni.Length == 13) { _ = _presentacionInformacion.Dni == "Es un Ruc"; }

        // _presentacionInformacion.Dni = dni;
        return this;

    }


    public PresentacionInformacionDto Build() => _presentacionInformacion;

}

