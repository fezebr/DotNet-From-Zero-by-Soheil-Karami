using System;
using System.Threading.Tasks;

namespace CAS.Application.Contract
{
    public interface IDoctorService
    {
        public Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken);
        public Task<DoctorDto> GetById(Guid id, CancellationToken cancellationToken);

    }
}
