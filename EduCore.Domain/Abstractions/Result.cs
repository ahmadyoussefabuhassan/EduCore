using System.Diagnostics.CodeAnalysis;

namespace EduCore.Domain.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public Error Error { get; }
        public static Result Success() => new Result(true, Error.None);
        public static Result Failure(Error error) => new Result(false, error);
        public static Result<T> Success<T>(T value) => new Result<T>(value, true, Error.None);
        public static Result<T> Failure<T>(Error error) => new Result<T>(default!, false, error);
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
                throw new InvalidOperationException("A successful result cannot have an error.");
            if (!isSuccess && error == Error.None)
                throw new InvalidOperationException("A failure result must have an error.");
            IsSuccess = isSuccess;
            Error = error;
        }
        public static Result<T> Create<T>(T value) =>
            value is not null ? Success(value) : Failure<T>(Error.NullValue);

    }
    public class Result<T> : Result
    {
        public T? _value;
        protected internal Result(T value, bool isSuccess, Error error)
            : base(isSuccess, error) 
            => _value = value;
        [NotNull]
        public T Value => IsSuccess ? _value! :
            throw new InvalidOperationException("Cannot access the value of a failed result.");
        public static implicit operator Result<T>(T value) => Create(value);
    }
}
