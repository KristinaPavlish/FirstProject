using FirstProject.Bll.Enums;
using FirstProject.Bll.Models;
namespace FirstProject.Bll.Interfaces;

public interface IFileService
{
    StatusEnum Save(Company company, string fileName);

    Company Upload(string fileName);
}