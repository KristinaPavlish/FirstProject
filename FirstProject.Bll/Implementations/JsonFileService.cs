using FirstProject.Bll.Enums;
using FirstProject.Bll.Interfaces;
using FirstProject.Bll.Models;
using Newtonsoft.Json;

namespace FirstProject.Bll.Implementations;

public class JsonFileService : IFileService
{
    public StatusEnum Save(Company company, string fileName)
    {
        try
        {
            string json = JsonConvert.SerializeObject(company);
            File.WriteAllText(fileName, json);
            return StatusEnum.Success;
        }
        catch (Exception exception)
        {
            return StatusEnum.Error;
        }
    }
    public Company Upload(string fileName)
    {
        try
        {
            string text = File. ReadAllText(fileName);
            Company company = JsonConvert.DeserializeObject<Company>(text) ?? new Company();
            return company;
        }
        catch (Exception exception)
        {
            throw new Exception("Error while reading from file");
        }
    }
}