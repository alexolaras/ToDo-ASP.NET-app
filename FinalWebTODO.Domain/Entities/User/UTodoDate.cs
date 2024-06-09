using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.Domain.Entities.User
{
    public class UTodoDate
    {
        public int UserId { get; set; }
        public string Subiect {  get; set; }
        public string Descriere { get; set; }
        public string Lista { get; set; }
        public DateTime TodoTime { get; set; }
    }
}
