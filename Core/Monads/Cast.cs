namespace Core.Monads;

public static class CastExtension
{
    public static Either<TCasted, TRight> Cast<TLeft, TRight, TCasted>(this Either<TLeft, TRight> either,
        Func<TLeft, TCasted> fn) => either.IsLeft ? fn(either.Left) : either.Right;
}