using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorViewModel.Entities.ClinicVm
{
    public class UpdateClinicVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime StoptWorkTime { get; set; }

        public int CategoryId { get; set; }
    }
}
