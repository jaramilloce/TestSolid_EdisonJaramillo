using System.Text.Json;
using WebTestCurso.Dto;
using WebTestCurso.Dto.DtoBuilder;

using System;
using System.Collections.Generic;
using System.Linq;

namespace WebTestCurso.Repository;

public class RepoBankRepository : IRepoBankRepository
{

    List<DataPrestamoBankDto> lstPagoPrestamoDto;

    private readonly string _jsonDataBase = Path.Combine(Directory.GetCurrentDirectory(), "Bdd", "data.json");

    public RepoBankRepository()
    {

        if (File.Exists(_jsonDataBase))
        {
            var dataJson = File.ReadAllText(_jsonDataBase);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            lstPagoPrestamoDto = JsonSerializer.Deserialize<List<DataPrestamoBankDto>>(dataJson, options) ?? [];
        }
        else
        {
            lstPagoPrestamoDto = new List<DataPrestamoBankDto>();
        }

    }


    public async Task<List<DataPrestamoBankDto>> GetDataPrestamosBanks()
    {

        return await Task.FromResult(lstPagoPrestamoDto);    
    }

    public async Task<DataPrestamoBankDto> GetDataPrestamosBanksbyId(int codigo)
    {
        var data = lstPagoPrestamoDto.FirstOrDefault(x => x.CaprCodigo == codigo);
        
        return await Task.FromResult(data);
    }
}

