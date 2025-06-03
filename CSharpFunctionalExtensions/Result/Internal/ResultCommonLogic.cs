using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions.Internal;

internal static class ResultCommonLogic
{
    internal static void GetObjectDataCommon(IResult result, SerializationInfo info)
    {
        info.AddValue("IsFailure", result.IsFailure);
        info.AddValue("IsSuccess", result.IsSuccess);
    }

    internal static void GetObjectData(Result result, SerializationInfo info)
    {
        GetObjectDataCommon(result, info);
        if (result.IsFailure)
        {
            info.AddValue("Error", result.Error);
        }
    }

    internal static void GetObjectData<T>(Result<T> result, SerializationInfo info)
    {
        GetObjectDataCommon(result, info);
        if (result.IsFailure)
        {
            info.AddValue("Error", result.Error);
        }

        if (result.IsSuccess)
        {
            info.AddValue("Value", result.Value);
        }
    }

    internal static void GetObjectData<T, E>(Result<T, E> result, SerializationInfo info)
    {
        GetObjectDataCommon(result, info);
        if (result.IsFailure)
        {
            info.AddValue("Error", result.Error);
        }

        if (result.IsSuccess)
        {
            info.AddValue("Value", result.Value);
        }
    }

    internal static bool ErrorStateGuard<E>(bool isFailure, E error)
    {
        if (isFailure)
        {
            if (error == null || (error is string && error.Equals(string.Empty)))
                throw new ArgumentNullException(nameof(error), Result.Messages.ErrorObjectIsNotProvidedForFailure);
        }
        else
        {
            if (!EqualityComparer<E>.Default.Equals(error, default))
                throw new ArgumentException(Result.Messages.ErrorObjectIsProvidedForSuccess, nameof(error));
        }

        return isFailure;
    }

    internal static E GetErrorWithSuccessGuard<E>(bool isFailure, E error) =>
        isFailure ? error : throw new ResultSuccessException();

    internal static SerializationValue<IError> DeserializeError(SerializationInfo info)
        => Deserialize<IError>(info);

    internal static SerializationValue<E> Deserialize<E>(SerializationInfo info)
    {
        bool isFailure = info.GetBoolean("IsFailure");

        E error = isFailure ? (E)info.GetValue("Error", typeof(E)) : default;
        return new SerializationValue<E>(isFailure, error);
    }

    internal static E DeserializeProperty<T, E>(this T obj,
        SerializationInfo info,
        Expression<Func<T, E>> propertyExpression)
    {
        var propertyName = propertyExpression.GetPropertyName();
        return (E)info.GetValue(propertyName, typeof(E)) ?? default;
    }

    internal static string GetPropertyName<T, E>(this Expression<Func<T, E>> propertyExpression)
    {
        MemberExpression memberExpression = propertyExpression.Body as MemberExpression
            ?? (propertyExpression.Body as UnaryExpression)?.Operand as MemberExpression;

        if (memberExpression == null || !(memberExpression.Member is PropertyInfo))
        {
            throw new ArgumentException("Expression must be a property access expression.");
        }

        return memberExpression.Member.Name;
    }
}
