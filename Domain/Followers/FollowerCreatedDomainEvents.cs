using SharedKernel;

namespace Domain.Followers
{
    public sealed record FollowerCreatedDomainEvents(Guid UserId, Guid FollowedId) : IDomainEvent;
}
