using System.ComponentModel.DataAnnotations;

namespace MVPSenai.Models
{
    public class Logs
    {
        [Key]
        public int IdLogs { get; set; }
        public int? FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
        public DateTime Data { get; set; }
        public int HorasTrabalhadas { get; set; }
    }
}
