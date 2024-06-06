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
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Sorry, no longer than 30 characters.")]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password can`t be shorter than 8 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(30)]
        public string Email { get; set; }

        [DataType(DataType.Date)]   
        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LastIp {  get; set; }

        public URole level { get; set; }
    }
}
