using System.ComponentModel.DataAnnotations;

namespace MVPSenai.Models
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O E-mail não pode ser nulo")]
        [MaxLength(50, ErrorMessage = "Não pode passar de 50 caractes")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha não pode ser nula")]
        [MaxLength(15, ErrorMessage = "Não pode passar de 15 caractes")]
        public string Senha { get; set; }
        [Required]  
        public bool Equipamentos { get; set; }
        public int? SetorId { get; set; }
        public virtual Setor? Setor { get; set; }

        public ICollection<Logs> Logs { get; } = new List<Logs>();
    }
}
