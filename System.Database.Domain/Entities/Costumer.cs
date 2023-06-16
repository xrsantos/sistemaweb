using System;
using System.Collections.Generic;
using System.Database.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace System.Database.Domain.Entities
{
    public class Costumer : BaseEntity
    {
        public string? Name { get; set; }
        public bool FlgEnable { get; set; }
    }
}