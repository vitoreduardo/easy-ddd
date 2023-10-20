using EasyDDD.Application.SystemVersions.Notifications;
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
            private readonly IMediator _mediator;

            public GetSystemVersionHandler(
                IReadRepositoryBase<SystemVersion> repository,
                IMediator mediator)
            {
                _repository=repository;
                _mediator=mediator;
            }

            public async Task<SystemVersionViewModel> Handle(GetSystemVersionQuery request, CancellationToken cancellationToken)
            {
                var spec = new LastSystemVersionSpec();
                var version = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
                if (version is null)
                {
                    return await Task.FromResult(new SystemVersionViewModel());
                }

                await _mediator.Publish(new SystemVersionNotification(1, "Message"));

                return await Task.FromResult(new SystemVersionViewModel(version.Number()));
            }
        }
    }
}
