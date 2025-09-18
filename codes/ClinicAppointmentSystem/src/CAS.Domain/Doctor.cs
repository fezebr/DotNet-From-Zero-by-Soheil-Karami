
namespace CAS.Domain;

public class Doctor
{
    public Task<Guid> id;

    public Guid Id { get; }
    public string Name { get; }
    public string LastName   { get; }
    public string Expertise { get; }
    public string CodeMeli { get; set; }
    public IReadOnlyList<int> WorkingDays { get; }

    public Doctor(string name, string lastname, string expertise, string codeMeli, List<int> workingDays)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Expertise = expertise ?? throw new ArgumentNullException(nameof(expertise));
        CodeMeli = codeMeli ?? throw new ArgumentNullException(nameof(CodeMeli));   
        WorkingDays = workingDays?.AsReadOnly() ?? throw new ArgumentNullException(nameof(workingDays));
    }

   
}

