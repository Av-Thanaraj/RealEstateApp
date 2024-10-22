using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public partial class Property
    {
        public int Id { get; set; }

        public int? Type { get; set; }

        public string? Description { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
