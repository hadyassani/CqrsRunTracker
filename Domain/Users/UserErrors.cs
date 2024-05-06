using SharedKernel;

namespace Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound(Guid userId) =>
            new("Users.NotFound", $"The user with the id '{userId}' was not found");
    }
}
