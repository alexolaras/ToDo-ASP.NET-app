using FinalWebTODO.Domain.Entities.User;
using FinalWebTODO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebTODO.Models
{
    public class TodoData
    {
        public string Subiect {  get; set; }
        public string Descriere { get; set; }
        public string Lista { get; set; }
        public DateTime TodoTime { get; set; }
    }
}