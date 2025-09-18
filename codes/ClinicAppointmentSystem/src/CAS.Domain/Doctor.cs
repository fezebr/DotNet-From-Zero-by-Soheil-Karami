
namespace CAS.Domain;

public class Doctor
{
    public Task<Guid> id;

    public Guid Id { get; }
    public string Name { get; }
    public string LastName   { get; }
    public string Expertise { get; }
    public string NationalCode { get; set; }
    public IReadOnlyList<int> WorkingDays { get; }

    public Doctor(string name, string lastname, string expertise, string nationalCode, List<int> workingDays)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Expertise = expertise ?? throw new ArgumentNullException(nameof(expertise));
        NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(NationalCode));   
        WorkingDays = workingDays?.AsReadOnly() ?? throw new ArgumentNullException(nameof(workingDays));
    }

   
}

