namespace Core.Monads;

public static class SelectManyExtension
{
    public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TProjection, TResult>(
        this Either<TLeft, TRight> either, Func<TRight, Either<TLeft, TProjection>> bind,
        Func<TRight, TProjection, TResult> project)
    {
        return either.FlatMap(bind).Map(projected => project(either.Right, projected));
    }
}