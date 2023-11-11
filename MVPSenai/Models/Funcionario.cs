using System.ComponentModel.DataAnnotations;

namespace MVPSenai.Models
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]  
        public bool Equipamentos { get; set; }
        public virtual Setor? setor { get; set; }
        public int IdSetor { get; set; }
    }
}
