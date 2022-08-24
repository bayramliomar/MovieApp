using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp_.Entities
{
    public class Movie
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Film başlığı alanı boş geçilemez")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Başlık 5-50 karakter uzunluğunda olmalıdır")]
        [DisplayName("Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Film açıklaması alanı boş geçilemez")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }



        [Required(ErrorMessage = "Resim alanı boş geçilemez")]
        [DisplayName("Resim")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Tür bilgisi boş geçilemez")]
        [DisplayName("Tür")]

        public Genre Genre { get; set; }  //navigation property
        public int GenreID { get; set; }
    }
}
