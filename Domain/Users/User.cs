using SharedKernel;

namespace Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, Email email, Name name, bool hasPublicProfile) : base(id)
        {
            Email = email;
            Name = name;
            HasPublicProfile = hasPublicProfile;
        }
        public bool HasPublicProfile { get; internal set; }
        public Email Email { get; set; }
        public Name Name { get; set; }

        public static User Create(Email email, Name name, bool hasPublicProfile)
        {
            var user = new User(Guid.NewGuid(), email, name, hasPublicProfile);
            user.Raise(new UserCreatedDomainEvent(user.Id));
            return user;
        }


    }
}
