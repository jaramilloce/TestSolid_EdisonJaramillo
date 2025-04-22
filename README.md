# TestSolid_EdisonJaramillo
TestSolid_EdisonJaramillo
Trabajo Final Solid

Edison Jaramillo 

Profesor: Ing. Erick Velasco 

Servicio 1: servicios data de banco produbanco, desarrollado con base en interfaces y metodos asincronicos
http://localhost:5120/DataBank/GetDataBankProdubanco

Servicio 2: servicios data de banco Solidario, desarrollado con base en interfaces y metodos asincronicos
http://localhost:5120/DataBank/GetDataBankSolidario

# Diferencia: Servicio 1 y 2, se seperan
# Diferencia: En el servicio 3 se juntan los dos, en un solo método.

Servicio 3: Servicio de 
- Patron Singleton  
- Patron Build 
Para el descarte de data segun de parametro de entrada (bnks), se requiere la diferenciación de datos segun paramtro get.
http://localhost:5120/DataBank/GetDataBanks?bnks=sol

Servcio 4: Métodos de patron Build, con validaciones de un Dto inicial, cada campo de objeto tiene un representación segun el caso de cada campo, método POST.
http://localhost:5120/DataBank/GetDataPresentInfoClientBuild

body:
{
	"Cuenta1": "abc1235",
	"Cuenta2": "cunt4585",
	"Cuenta3": "prdn468",
	"Nombre": "Maria Paz",
	"Apellido": "Jaramillo",
	"Dni": "25"
}

Servicio 5: Una mezcla entre los patrones Build y Strategy:
Concepto: Ingreso de datos de prestamo, cuando ingresen se validaran campos especificos segun la información ingresada, no se tiene un BDD, como base se tiene un JSON sobre el proyecto, método POST.
http://localhost:5120/DataBank/SetValoresPrestamos

{
	"Cuenta1": "12",
	"Cuenta2": "1654",
	"ValorPago": "5",
	"Dni": "1717550923"
}

 
