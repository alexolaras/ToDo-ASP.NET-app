using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalWebTODO.Domain.Enums;

namespace FinalWebTODO.Domain.Entities.User
{
    public class TodoDbTable
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Subiect")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Maxim 50 cuvinte.")]
        public string Subiect { get; set; }

        [Required]
        [Display(Name = "Descriere")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Maxim 200 cuvinte.")]
        public string Descriere { get; set; }

        [Required]
        [Display(Name = "Lista")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Lista max 40, min 3")]
        public string Lista { get; set; }
       
        public TodoRole Role { get; set; }
        
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
    }
}
