using EasyDDD.SharedKernel.Interfaces;

namespace EasyDDD.Domain.SystemVersions.Events
{
    public class CandidateReleaseVersionUpdated : IDomainEvent
    {
        public DateTime DateOcurred { get; }
        public string NewVersion { get; }

        public CandidateReleaseVersionUpdated(
            DateTime dateOcurred,
            string newVersion)
        {
            DateOcurred=dateOcurred;
            NewVersion=newVersion;
        }
    }
}
