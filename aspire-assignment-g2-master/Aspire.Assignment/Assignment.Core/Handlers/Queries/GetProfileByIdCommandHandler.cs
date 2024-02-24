using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Providers.Handlers.Queries;
public class GetProfile : IRequest<UserProfile>{
    public string Username{get;}
    public GetProfile(string username)
    {
        Username=username;
    }
}
public class GetProfileQueryHandler : IRequestHandler<GetProfile, UserProfile>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetProfileQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork=unitOfWork;
        _mapper=mapper;
    }

    async Task<UserProfile> IRequestHandler<GetProfile, UserProfile>.Handle(GetProfile request, CancellationToken cancellationToken)
    {
        var profile= await Task.FromResult(_unitOfWork.UserProfiles.Get(request.Username));
            
            if (profile == null)
            {
                throw new EntityNotFoundException($"User with ID {request.Username} not found");
            }
             return profile;
    }
}