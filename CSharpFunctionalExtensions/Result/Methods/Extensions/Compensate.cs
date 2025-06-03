using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Result Compensate(this Result result, Func<string, Result> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Result Compensate<T>(this Result<T> result, Func<string, Result> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Result<T> Compensate<T>(this Result<T> result, Func<string, Result<T>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Result<T, E> Compensate<T, E>(this Result<T> result, Func<string, Result<T, E>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value);
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Result Compensate<T, E>(this Result<T, E> result, Func<E, Result> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Result<T, E2> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Result<T, E2>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value);
            }

            return func(result.Error);
        }
    }
}