using Ytsoob.TestsShared.XunitFramework;

[assembly: TestFramework(
    $"Ytsoob.{nameof(Ytsoob.TestsShared)}.{nameof(Ytsoob.TestsShared.XunitFramework)}.{nameof
        (CustomTestFramework)}",
    $"Ytsoob.{nameof(Ytsoob.TestsShared)}"
)]
