using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorViewModel.Entities.DoctorReviewCombined
{
    public class DoctorReviewVM
    {
        public Doctor Doctor { get; set; }
        public CreateReviewVM CreateReviewVM { get; set; }
    }
}
