using EasyDDD.Domain.Spec;

namespace EasyDDD.Domain.SystemVersions.Spec
{
    public class LastSystemVersionSpec : BaseSpecification<SystemVersion>
    {
        public LastSystemVersionSpec()
        {
            ApplyOrderByDescending(x => x.Major);
            ApplyPaging(0, 1);
        }
    }
}
