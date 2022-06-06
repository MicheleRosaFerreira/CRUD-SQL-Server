using ApiCadastros.Models;

namespace ApiCadastros.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<EmployeeModels>> GetAll();
        Task<EmployeeModels> Get(int Id);
        Task<EmployeeModels> Create (EmployeeModels employee);
        Task Update (EmployeeModels employee);
        Task Delete (int Id);   
    }
}
