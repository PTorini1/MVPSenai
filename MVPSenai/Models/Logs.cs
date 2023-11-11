using System.ComponentModel.DataAnnotations;

namespace MVPSenai.Models
{
    public class Logs
    {
        [Key]
        public int IdLogs { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario funcionario { get; set; }
        public DateTime Data { get; set; }
        public int HorasTrabalhadas { get; set; }
    }
}
