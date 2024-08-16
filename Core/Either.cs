namespace Core;

public sealed record Either<TLeft, TRight>(TLeft? Left, TRight? Right)
{
    public bool IsLeft => Left is not null;
    public bool IsRight => Right is not null;

    public static implicit operator Either<TLeft, TRight>(TLeft left) => new(left, default);
    public static implicit operator Either<TLeft, TRight>(TRight right) => new(default, right);
}