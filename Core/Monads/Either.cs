namespace Core.Monads;

public sealed record Either<TLeft, TRight>(TLeft? Left, TRight? Right)
{
    public bool IsLeft => Left is not null && Right is null;
    public bool IsRight => Right is not null && Left is null;

    public static implicit operator Either<TLeft, TRight>(TLeft left) => new(left, default);
    public static implicit operator Either<TLeft, TRight>(TRight right) => new(default, right);
}