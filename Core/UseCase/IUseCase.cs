namespace Core.UseCase;

public interface IUseCase<in TInput, out TOutput>
{
    TOutput Execute(TInput input);
}