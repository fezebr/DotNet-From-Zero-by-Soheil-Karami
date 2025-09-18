using System;

namespace CAS.Application.Contract
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string CodeMeli { get; set; }
        public List<int> WorkingDays { get; set; }
    }
}