using System.ComponentModel.DataAnnotations;


namespace Ticketing.TicketModel
{
    public class FileUpload
    {
        [Required]
        [Display(Name="Title")]
        [StringLength(60,MinimumLength =3)]
        public string Title { get; set; }

        [Required]
        [Display(Name ="File")]
        public string UploadFile { get; set; }
    }
}