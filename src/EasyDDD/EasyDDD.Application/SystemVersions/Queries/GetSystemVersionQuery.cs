using EasyDDD.Application.SystemVersions.Queries.ViewModels;
using EasyDDD.Domain.SystemVersions;
using EasyDDD.Domain.SystemVersions.Spec;
using EasyDDD.SharedKernel.Interfaces;
using MediatR;

namespace EasyDDD.Application.SystemVersions.Queries
{
    public class GetSystemVersionQuery : IRequest<SystemVersionViewModel>
    {
        internal sealed class GetSystemVersionHandler : IRequestHandler<GetSystemVersionQuery, SystemVersionViewModel>
        {
            private readonly IReadRepositoryBase<SystemVersion> _repository;

            public GetSystemVersionHandler(IReadRepositoryBase<SystemVersion> repository)
            {
                _repository=repository;
            }

            public async Task<SystemVersionViewModel> Handle(GetSystemVersionQuery request, CancellationToken cancellationToken)
            {
                var spec = new LastSystemVersionSpec();
                var version = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
                if (version is null)
                {
                    return await Task.FromResult(new SystemVersionViewModel());
                }

                return await Task.FromResult(new SystemVersionViewModel(version.Number()));
            }
        }
    }
}
