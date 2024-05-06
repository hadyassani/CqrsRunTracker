using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SharedKernel
{
    public static class Ensure
    {
        public static void NotNulOrEmpty(
            [NotNull] string? value,
            [CallerArgumentExpression("value")] string? paramName = default)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }
    }
}
