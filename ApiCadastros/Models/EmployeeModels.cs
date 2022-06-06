using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCadastros.Models
{
      [Table("[REGISTRATION_OF_EMPLOYEES]")]
        public class EmployeeModels { 

        [Column (TypeName = "int")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "o campo nome é obrigatorio"),MaxLength(100)]
       
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Cidade { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Endereco { get; set; }

    }
}
