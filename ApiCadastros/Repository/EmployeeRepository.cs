using ApiCadastros.Interface;
using ApiCadastros.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCadastros.Repository
{
    
    public class EmployeeRepository : IEmployee

    {
    public readonly EmployeeContext _context;
    public EmployeeRepository(EmployeeContext context)
    {
        _context = context;
    }

    public async Task<EmployeeModels> Create(EmployeeModels employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<EmployeeModels> Get(int Id)
    {
            return await _context.Employees.FindAsync(Id);

    }

    public async Task<IEnumerable<EmployeeModels>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task Update(EmployeeModels employee)
    {
        _context.Entry(employee).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int Id)
    {
        var employeeToDelete = await _context.Employees.FindAsync(Id);
        _context.Employees.Remove(employeeToDelete);
        await _context.SaveChangesAsync();
    }
}
}
