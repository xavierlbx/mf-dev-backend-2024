using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2024.Models
{
    [Table ("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a placa!")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Ano de Fabricação!")]
        public int AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Ano de modelo!")]
        public int AnoModelo { get; set; }
    }
}
