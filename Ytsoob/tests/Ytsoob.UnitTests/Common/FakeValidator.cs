using FluentValidation;

namespace Ytsoob.UnitTests.Common;

public class FakeValidator<T> : AbstractValidator<T>
    where T : class
{
}
