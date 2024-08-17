namespace Core.Monads;

public static class SelectExtension
{
    public static Either<TLeft, TResult> Select<TLeft, TRight, TResult>(
        this Either<TLeft, TRight> either,
        Func<TRight, TResult> selector)
    {
        return either.Map(selector);
    }
}