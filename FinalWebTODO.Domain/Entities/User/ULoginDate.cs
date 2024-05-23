using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.Domain.Entities.User
{
    public class ULoginDate
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime {  get; set; }
    }
}
