using System.Diagnostics.CodeAnalysis;

namespace Core.Monads;

public sealed record Either<TLeft, TRight>(TLeft? Left, TRight? Right)
{
    [MemberNotNullWhen(true, nameof(Left))]
    [MemberNotNullWhen(false, nameof(Right))]
    public bool IsLeft => Left is not null && EqualityComparer<TRight>.Default.Equals(Right, default);
    [MemberNotNullWhen(true, nameof(Right))]
    [MemberNotNullWhen(false, nameof(Left))]
    public bool IsRight => Right is not null && EqualityComparer<TLeft>.Default.Equals(Left, default);

    public static implicit operator Either<TLeft, TRight>(TLeft left) => new(left, default);
    public static implicit operator Either<TLeft, TRight>(TRight right) => new(default, right);
}