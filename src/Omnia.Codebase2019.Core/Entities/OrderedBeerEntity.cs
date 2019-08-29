using Omnia.Codebase2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Omnia.Codebase2019.Core.Entities
{
    internal class OrderedBeerEntity
    {
        [Key, Column(Order = 1)]
        public Guid UserId { get; set; }

        public BasicBeer Beer { get; set; }
    }
}
