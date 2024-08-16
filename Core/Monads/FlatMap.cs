namespace Core.Monads;

public static class FlatMapExtension
{
    public static Either<TLeft, TResult> FlatMap<TLeft, TRight, TResult>(this Either<TLeft, TRight> either,
        Func<TRight, Either<TLeft, TResult>> fn) =>
        either.IsRight ? fn(either.Right) : either.Left;
}