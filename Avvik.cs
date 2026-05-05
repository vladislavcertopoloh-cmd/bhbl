using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Avvik
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите заголовок")]
        [Display(Name = "Заголовок")]
        public string Tittel { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string Beskrivelse { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите место")]
        [Display(Name = "Место")]
        public string Sted { get; set; } = string.Empty;

        [Display(Name = "Статус")]
        public string Status { get; set; } = "Новый";

        [Display(Name = "Дата создания")]
        public DateTime DatoOpprettettet { get; set; } = DateTime.Now;
    }
}