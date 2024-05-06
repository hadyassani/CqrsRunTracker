using SharedKernel;

namespace Domain.Users
{
    public sealed record Name
    {
        public Name(string? value)
        {
            Ensure.NotNulOrEmpty(value);

            Value = value;
        }

        public string Value { get; }
    }
}
