﻿using FindoctorCore.Entities;
using FindoctorEntity.Entities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorEntity.Entities
{
    public class Patient:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
    }
}