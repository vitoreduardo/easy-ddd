using Ardalis.GuardClauses;
using EasyDDD.SharedKernel.Interfaces;
using EasyDDD.SharedKernel.Model;

namespace EasyDDD.Domain.SystemVersions
{
    public class SystemVersion : Entity<Guid>, IAggregateRoot
    {
        public SystemVersion()
        {
            this.Id = Guid.NewGuid();
            Major++;
            Minor++;
            Patch++;
            PreRelease = string.Empty;
        }

        public int Major { get; set; }

        public int Minor { get; set; }

        public int Patch { get; set; }

        public string PreRelease { get; private set; }

        public void SetPreRelease(string preRelease)
        {
            Guard.Against.NullOrEmpty(preRelease);

            PreRelease = preRelease;
        }

        public string Number()
        {
            return $"{Major}.{Minor}.{Patch}{GetPreRelease()}";
        }

        private string GetPreRelease()
        {
            if (!String.IsNullOrEmpty(PreRelease))
                return $".{PreRelease}";

            return string.Empty;
        }
    }
}
