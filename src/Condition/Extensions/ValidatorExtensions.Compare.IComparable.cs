﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Verbess.Utils.Conditions
{
    // Fallback checks for all IComparable types that don't have an explicit overload
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsInRange<T>(this Validator<T> validator, T minValue, T maxValue) where T : IComparable
        {
            return IsInRange<T>(validator, minValue, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsInRange<T>(this Validator<T> validator, T minValue, T maxValue, string conditionDescription) where T : IComparable
        {
            Comparer<T> defaultComparer = DefaultComparer<T>.Default;
            T value = validator.Value;

            bool valueIsValid = (defaultComparer.Compare(value, minValue) >= 0) &&
                                (defaultComparer.Compare(value, maxValue) <= 0);

            if (!valueIsValid)
            {
                Throw.ValueShouldBeBetween<T>(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsInRange<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, Nullable<T> maxValue) where T : struct
        {
            return IsInRange<T>(validator, minValue, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsInRange<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, Nullable<T> maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> defaultComparer = DefaultComparer<Nullable<T>>.Default;
            Nullable<T> value = validator.Value;

            bool valueIsValid = (defaultComparer.Compare(value, minValue) >= 0) &&
                                (defaultComparer.Compare(value, maxValue) <= 0);

            if (!valueIsValid)
            {
                Throw.ValueShouldBeBetween<Nullable<T>>(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsInRange<T>(this Validator<Nullable<T>> validator, T minValue, T maxValue) where T : struct
        {
            return IsInRange<T>(validator, minValue, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsInRange<T>(this Validator<Nullable<T>> validator, T minValue, T maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> defaultComparer = DefaultComparer<Nullable<T>>.Default;
            Nullable<T> value = validator.Value;

            bool valueIsValid = (defaultComparer.Compare(value, minValue) >= 0) &&
                                (defaultComparer.Compare(value, maxValue) <= 0);

            if (!valueIsValid)
            {
                Throw.ValueShouldBeBetween<Nullable<T>>(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotInRange<T>(this Validator<T> validator, T minValue, T maxValue) where T : IComparable
        {
            return IsNotInRange<T>(validator, minValue, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotInRange<T>(this Validator<T> validator, T minValue, T maxValue, string conditionDescription) where T : IComparable
        {
            Comparer<T> defaultComparer = DefaultComparer<T>.Default;
            T value = validator.Value;

            bool valueIsInvalid = (defaultComparer.Compare(value, minValue) >= 0) &&
                                  (defaultComparer.Compare(value, maxValue) <= 0);

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeBetween<T>(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotInRange<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, Nullable<T> maxValue) where T : struct
        {
            return IsNotInRange<T>(validator, minValue, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotInRange<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, Nullable<T> maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> defaultComparer = DefaultComparer<Nullable<T>>.Default;
            Nullable<T> value = validator.Value;

            bool valueIsInvalid = (defaultComparer.Compare(value, minValue) >= 0) &&
                                  (defaultComparer.Compare(value, maxValue) <= 0);

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeBetween<Nullable<T>>(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotInRange<T>(this Validator<Nullable<T>> validator, T minValue, T maxValue) where T : struct
        {
            return IsNotInRange<T>(validator, minValue, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range and a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotInRange<T>(this Validator<Nullable<T>> validator, T minValue, T maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> defaultComparer = DefaultComparer<Nullable<T>>.Default;
            Nullable<T> value = validator.Value;

            bool valueIsInvalid = (defaultComparer.Compare(value, minValue) >= 0) &&
                                  (defaultComparer.Compare(value, maxValue) <= 0);

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeBetween<Nullable<T>>(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsGreaterThan<T>(this Validator<T> validator, T minValue) where T : IComparable
        {
            return IsGreaterThan<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsGreaterThan<T>(this Validator<T> validator, T minValue, string conditionDescription) where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, minValue) > 0))
            {
                Throw.ValueShouldBeGreaterThan<T>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterThan<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue) where T : struct
        {
            return IsGreaterThan<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterThan<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, string conditionDescription) where T : struct
        {
            if (!(DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, minValue) > 0))
            {
                Throw.ValueShouldBeGreaterThan<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterThan<T>(this Validator<Nullable<T>> validator, T minValue) where T : struct
        {
            return IsGreaterThan<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterThan<T>(this Validator<Nullable<T>> validator, T minValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsValid = comparer.Compare(validator.Value, minValue) > 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeGreaterThan<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotGreaterThan<T>(this Validator<T> validator, T maxValue) where T : IComparable
        {
            return IsNotGreaterThan<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception> 
        public static Validator<T> IsNotGreaterThan<T>(this Validator<T> validator, T maxValue, string conditionDescription) where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, maxValue) > 0)
            {
                Throw.ValueShouldNotBeGreaterThan<T>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterThan<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue) where T : struct
        {
            return IsNotGreaterThan<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception> 
        public static Validator<Nullable<T>> IsNotGreaterThan<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue, string conditionDescription) where T : struct
        {
            if (DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, maxValue) > 0)
            {
                Throw.ValueShouldNotBeGreaterThan<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterThan<T>(this Validator<Nullable<T>> validator, T maxValue) where T : struct
        {
            return IsNotGreaterThan<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterThan<T>(this Validator<Nullable<T>> validator, T maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsInvalid = comparer.Compare(validator.Value, maxValue) > 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeGreaterThan<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsGreaterOrEqual<T>(this Validator<T> validator, T minValue) where T : IComparable
        {
            return IsGreaterOrEqual<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsGreaterOrEqual<T>(this Validator<T> validator, T minValue, string conditionDescription) where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, minValue) >= 0))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo<T>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue) where T : struct
        {
            return IsGreaterOrEqual<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, string conditionDescription) where T : struct
        {
            if (!(DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, minValue) >= 0))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterOrEqual<T>(this Validator<Nullable<T>> validator, T minValue) where T : struct
        {
            return IsGreaterOrEqual<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsGreaterOrEqual<T>(this Validator<Nullable<T>> validator, T minValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsValid = comparer.Compare(validator.Value, minValue) >= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotGreaterOrEqual<T>(this Validator<T> validator, T maxValue) where T : IComparable
        {
            return IsNotGreaterOrEqual<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/> and is an <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotGreaterOrEqual<T>(this Validator<T> validator, T maxValue, string conditionDescription) where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, maxValue) >= 0)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo<T>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue) where T : struct
        {
            return IsNotGreaterOrEqual<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue, string conditionDescription) where T : struct
        {
            if (DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, maxValue) >= 0)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterOrEqual<T>(this Validator<Nullable<T>> validator, T maxValue) where T : struct
        {
            return IsNotGreaterOrEqual<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotGreaterOrEqual<T>(this Validator<Nullable<T>> validator, T maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsInvalid = comparer.Compare(validator.Value, maxValue) >= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsLessThan<T>(this Validator<T> validator, T maxValue) where T : IComparable
        {
            return IsLessThan<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsLessThan<T>(this Validator<T> validator, T maxValue, string conditionDescription) where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, maxValue) < 0))
            {
                Throw.ValueShouldBeSmallerThan<T>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessThan<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue) where T : struct
        {
            return IsLessThan<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessThan<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue, string conditionDescription) where T : struct
        {
            if (!(DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, maxValue) < 0))
            {
                Throw.ValueShouldBeSmallerThan<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessThan<T>(this Validator<Nullable<T>> validator, T maxValue) where T : struct
        {
            return IsLessThan<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessThan<T>(this Validator<Nullable<T>> validator, T maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsValid = comparer.Compare(validator.Value, maxValue) < 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeSmallerThan<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotLessThan<T>(this Validator<T> validator, T minValue) where T : IComparable
        {
            return IsNotLessThan<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotLessThan<T>(this Validator<T> validator, T minValue, string conditionDescription) where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, minValue) < 0)
            {
                Throw.ValueShouldNotBeSmallerThan<T>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessThan<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue) where T : struct
        {
            return IsNotLessThan<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessThan<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, string conditionDescription) where T : struct
        {
            if (DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, minValue) < 0)
            {
                Throw.ValueShouldNotBeSmallerThan<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessThan<T>(this Validator<Nullable<T>> validator, T minValue) where T : struct
        {
            return IsNotLessThan<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessThan<T>(this Validator<Nullable<T>> validator, T minValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsInvalid = comparer.Compare(validator.Value, minValue) < 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeSmallerThan<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsLessOrEqual<T>(this Validator<T> validator, T maxValue) where T : IComparable
        {
            return IsLessOrEqual<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsLessOrEqual<T>(this Validator<T> validator, T maxValue, string conditionDescription) where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, maxValue) <= 0))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo<T>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue) where T : struct
        {
            return IsLessOrEqual<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> maxValue, string conditionDescription) where T : struct
        {
            if (!(DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, maxValue) <= 0))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessOrEqual<T>(this Validator<Nullable<T>> validator, T maxValue) where T : struct
        {
            return IsLessOrEqual<T>(validator, maxValue, null);
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsLessOrEqual<T>(this Validator<Nullable<T>> validator, T maxValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsValid = comparer.Compare(validator.Value, maxValue) <= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo<Nullable<T>>(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotLessOrEqual<T>(this Validator<T> validator, T minValue) where T : IComparable
        {
            return IsNotLessOrEqual<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotLessOrEqual<T>(this Validator<T> validator, T minValue, string conditionDescription) where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, minValue) <= 0)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo<T>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue) where T : struct
        {
            return IsNotLessOrEqual<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessOrEqual<T>(this Validator<Nullable<T>> validator, Nullable<T> minValue, string conditionDescription) where T : struct
        {
            if (DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, minValue) <= 0)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessOrEqual<T>(this Validator<Nullable<T>> validator, T minValue) where T : struct
        {
            return IsNotLessOrEqual<T>(validator, minValue, null);
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotLessOrEqual<T>(this Validator<Nullable<T>> validator, T minValue, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsInvalid = comparer.Compare(validator.Value, minValue) <= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo<Nullable<T>>(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and <paramref name="value"/> is not a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsEqualTo<T>(this Validator<T> validator, T value) where T : IComparable
        {
            return IsEqualTo<T>(validator, value, null);
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and <paramref name="value"/> is not a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum">Enum</see> type and not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsEqualTo<T>(this Validator<T> validator, T value, string conditionDescription) where T : IComparable
        {
            Comparer<T> defaultComparer = DefaultComparer<T>.Default;

            if (!(defaultComparer.Compare(validator.Value, value) == 0))
            {
                Throw.ValueShouldBeEqualTo<T>(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and <paramref name="value"/> is not a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct
        {
            return IsEqualTo<T>(validator, value, null);
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and <paramref name="value"/> is not a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> defaultComparer = DefaultComparer<Nullable<T>>.Default;

            if (!(defaultComparer.Compare(validator.Value, value) == 0))
            {
                Throw.ValueShouldBeEqualTo<Nullable<T>>(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and <paramref name="value"/> is not a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsEqualTo<T>(this Validator<Nullable<T>> validator, T value) where T : struct
        {
            return IsEqualTo<T>(validator, value, null);
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and <paramref name="value"/> is not a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsEqualTo<T>(this Validator<Nullable<T>> validator, T value, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> defaultComparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsValid = defaultComparer.Compare(validator.Value, value) == 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeEqualTo<Nullable<T>>(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> and the <paramref name="value"/> are both null references, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/> and are of type <see cref="System.Enum">Enum</see>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>   
        public static Validator<T> IsNotEqualTo<T>(this Validator<T> validator, T value) where T : IComparable
        {
            return IsNotEqualTo<T>(validator, value, null);
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> and the <paramref name="value"/> are both null references, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/> and are of type <see cref="System.Enum">Enum</see>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>   
        public static Validator<T> IsNotEqualTo<T>(this Validator<T> validator, T value, string conditionDescription) where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, value) == 0)
            {
                Throw.ValueShouldBeUnequalTo<T>(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> and the <paramref name="value"/> are both null references, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value) where T : struct
        {
            return IsNotEqualTo<T>(validator, value, null);
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> and the <paramref name="value"/> are both null references, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotEqualTo<T>(this Validator<Nullable<T>> validator, Nullable<T> value, string conditionDescription) where T : struct
        {
            if (DefaultComparer<Nullable<T>>.Default.Compare(validator.Value, value) == 0)
            {
                Throw.ValueShouldBeUnequalTo<Nullable<T>>(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotEqualTo<T>(this Validator<Nullable<T>> validator, T value) where T : struct
        {
            return IsNotEqualTo<T>(validator, value, null);
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotEqualTo<T>(this Validator<Nullable<T>> validator, T value, string conditionDescription) where T : struct
        {
            Comparer<Nullable<T>> comparer = DefaultComparer<Nullable<T>>.Default;

            bool valueIsInvalid = comparer.Compare(validator.Value, value) == 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldBeUnequalTo<Nullable<T>>(validator, value, conditionDescription);
            }

            return validator;
        }
    }
}