using Omnia.Codebase2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Omnia.Codebase2019.Core.Entities
{
    internal class OrderedBikeEntity
    {
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }

        public Guid UserId { get; set; }

        public BasicBike Bike { get; set; }
    }
}
