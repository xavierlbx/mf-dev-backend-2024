using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2024.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome do veículo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a placa do veículo")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o ano de fabricação do veículo")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o ano do veículo")]
        [Display(Name = "Ano do Modelo")]
        public int AnoModelo { get; set; }
    }
}


