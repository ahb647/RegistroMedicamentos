using System.ComponentModel.DataAnnotations;


namespace RegistroMedicamentos.Models
{
    public class Medicamentos
    {   
        [Key]
        public int MedicamentoId { get; set; }

       [Required(ErrorMessage ="Nombre del medicamento obligatorio")]
        [MaxLength(200, ErrorMessage = "El nombre del medicamento no puede exceder los 200 caracteres")]

        public string MedicamentoNombre { get; set;}


        [Required(ErrorMessage ="Cantidad obligatoria")]
        public int Cantidad {  get; set; }  

        [Required(ErrorMessage ="Tipo de medicamento obligatiorio")]
        [MaxLength(50, ErrorMessage = "El tipo de medicamento no puede exceder los 50 caracteres")]

        public string Tipo { get; set; }    

        public DateTime Fecha { get; set; } = DateTime.Now; 


    }
}
