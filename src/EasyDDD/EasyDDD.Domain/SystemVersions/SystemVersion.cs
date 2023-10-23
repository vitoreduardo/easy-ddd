using EasyDDD.Domain.SystemVersions.Events;
using EasyDDD.SharedKernel.Interfaces;
using EasyDDD.SharedKernel.Model;

namespace EasyDDD.Domain.SystemVersions
{
    public class SystemVersion : Entity<Guid>, IAggregateRoot
    {
        public SystemVersion()
        {
            Major++;
            Minor++;
            Patch++;
            PreRelease = string.Empty;
        }

        public SystemVersion(SystemVersion version, string preRelease)
        {
            Major = version.Major;
            Minor = version.Minor;
            Patch = version.Patch;
            PreRelease = preRelease;

            PublishEvent(new CandidateReleaseVersionUpdated(DateTime.Now, this.Number()));
        }

        public int Major { get; set; }

        public int Minor { get; set; }

        public int Patch { get; set; }

        public string PreRelease { get; private set; }

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
