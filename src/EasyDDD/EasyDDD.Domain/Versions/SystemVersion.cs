using Ardalis.GuardClauses;
using EasyDDD.SharedKernel.Model;

namespace EasyDDD.Domain.Versions
{
    public class SystemVersion : Entity<Guid>
    {
        public SystemVersion()
        {
            this.Id = Guid.NewGuid();
            Major++;
            Minor++;
            Patch++;
            PreRelease = string.Empty;
        }

        public int Major { get; }

        public int Minor { get; }

        public int Patch { get; }

        public string PreRelease { get; private set; }

        public void SetPreRelease(string preRelease)
        {
            Guard.Against.NullOrEmpty(preRelease);

            PreRelease = preRelease;
        }
    }
}
