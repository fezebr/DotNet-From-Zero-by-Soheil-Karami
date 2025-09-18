using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;// => doc => depend on component
        }
        public async Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (await _doctorRepository.AlreadyExists(dto.CodeMeli, cancellationToken))
                throw new ArgumentOutOfRangeException();


            var doctor = new Doctor(
               name: dto.Name,
               lastname: dto.LastName,
               expertise: dto.Speciality,
               codeMeli: dto.CodeMeli,
               workingDays: new List<int>()
           );

            await _doctorRepository.Create(doctor, cancellationToken);

            return doctor.Id;
        }

        public async Task<DoctorDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetById(id, cancellationToken);
            if (doctor == null) throw new ArgumentNullException(nameof(doctor));
            
            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Speciality = doctor.Expertise,
                CodeMeli = doctor.CodeMeli,
                WorkingDays = doctor.WorkingDays.ToList()
            };
        }


    }
}
