using ApiCadastros.Interface;
using ApiCadastros.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastros.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeRepository;
        public EmployeeController(IEmployee _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        [HttpGet]
      
        public async Task<ActionResult> GetEmployees()
        {
            var employee = await employeeRepository.GetAll();

            try
            {
                if (employee != null)

                    return Ok(employee);

                else

                    return NotFound("nenhum funcionario encontrado");
            }

            catch (Exception ex)
            {
                var msgErro = (ex.Message);
                throw new("nenhum funcionario encontrado");
            }
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<EmployeeModels>> GetOne (int id)
        {

            return Ok(await employeeRepository.Get(id));


        }
        [HttpPost]
        public async Task<ActionResult<EmployeeModels>> Post([FromBody] EmployeeModels employee)
        {
            try
            {
                var newEmployee = await employeeRepository.Create(employee);
                return CreatedAtAction(nameof(GetOne), new { id = newEmployee.Id }, newEmployee);
            }
            catch
            {
                return BadRequest("não foi possivel realizar este cadastro");
            }
          
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] EmployeeModels employee)
        {
            if (id!= employee.Id)
            return BadRequest("erro ao atualizar este funcinario");

            await employeeRepository.Update(employee);
            return NoContent();
        }
        [HttpDelete("{id}")]
    
        public async Task<ActionResult> Delete(int id )
        {
            try
            {
                await employeeRepository.Delete(id);

                return Ok("funcionario deletado com sucesso!");
            }
            catch(Exception ex)

            {
                var msgErro = ex.Message;
              
                var employeeToDelete = await employeeRepository.Get(id);

                if (employeeToDelete == null)
                {
                    return NotFound("funcionario não encontrado na base de dados.");
                }
            }
              throw new("funcionario nao encontrado na base de dados");


        }
    }
}
