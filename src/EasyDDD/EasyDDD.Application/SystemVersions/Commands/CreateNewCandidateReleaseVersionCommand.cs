using EasyDDD.Application.SystemVersions.Queries.ViewModels;
using EasyDDD.Domain.SystemVersions;
using EasyDDD.Domain.SystemVersions.Spec;
using EasyDDD.SharedKernel.Interfaces;
using MediatR;

namespace EasyDDD.Application.SystemVersions.Commands
{
    public class CreateNewCandidateReleaseVersionCommand : IRequest<SystemVersionViewModel>
    {
        internal sealed class CreateNewCandidateReleaseHandler : IRequestHandler<CreateNewCandidateReleaseVersionCommand, SystemVersionViewModel>
        {
            private readonly IReadRepositoryBase<SystemVersion> _readRepository;
            private readonly IRepositoryBase<SystemVersion> _repository;

            public CreateNewCandidateReleaseHandler(
                IReadRepositoryBase<SystemVersion> readRepository,
                IRepositoryBase<SystemVersion> repository)
            {
                _readRepository=readRepository;
                _repository=repository;
            }

            public async Task<SystemVersionViewModel> Handle(CreateNewCandidateReleaseVersionCommand request, CancellationToken cancellationToken)
            {
                var spec = new LastSystemVersionSpec();
                var version = await _readRepository.FirstOrDefaultAsync(spec, cancellationToken);
                if (version is null)
                {
                    return await Task.FromResult(new SystemVersionViewModel());
                }

                var rc = int.Parse(version.PreRelease.Substring(3)) + 1;
                var newVersion = new SystemVersion(version, $"rc.{rc}")
                {
                    Id = Guid.NewGuid()
                };


                await _repository.AddAsync(newVersion);
                await _repository.SaveChangesAsync(cancellationToken);

                return new SystemVersionViewModel();
            }
        }
    }
}
