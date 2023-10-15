using EasyDDD.Application.SystemVersions.Queries.ViewModels;
using EasyDDD.Domain.SystemVersions;
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
                var version = await _repository.ListAsync(cancellationToken);

                return await Task.FromResult(new SystemVersionViewModel(version.FirstOrDefault().Number()));
            }
        }
    }
}
