namespace Core.Monads;

public static class MapExtension
{
    public static Either<TLeft, TResult> Map<TLeft, TRight, TResult>(this Either<TLeft, TRight> either,
        Func<TRight, TResult> fn) =>
        either.IsRight ? fn(either.Right) : either.Left;
}