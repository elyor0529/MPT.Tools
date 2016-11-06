using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPT.Coding
{
    public static class Retry
    {
        // See: http://stackoverflow.com/questions/1563191/cleanest-way-to-write-retry-logic
        // Blanket catch statements that simply retry the same call can be dangerous if used as a general exception handling mechanism.
        // Having said that, here's a lambda-based retry wrapper that you can use with any method. 
        // I chose to factor the number of retries and the retry timeout out as parameters for a bit more flexibility:

        // You can now use this utility method to perform retry logic:
        // Retry.Do(() => SomeFunctionThatCanFail(), TimeSpan.FromSeconds(1));
        // or:
        // Retry.Do(SomeFunctionThatCanFail, TimeSpan.FromSeconds(1));
        // or:
        // int result = Retry.Do(SomeFunctionWhichReturnsInt, TimeSpan.FromSeconds(1), 4);
        // Or you could even make an async overload.


        public static void Do(
           Action action,
           TimeSpan retryInterval,
           int retryCount = 3)
        {
            Do<object>(() =>
            {
                action();
                return null;
            }, retryInterval, retryCount);
        }

        public static T Do<T>(
            Func<T> action,
            TimeSpan retryInterval,
            int retryCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    if (retry > 0)
                        Thread.Sleep(retryInterval);
                    return action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            throw new AggregateException(exceptions);
        }

        /// <summary>
        /// Retries method until method returns 'true'.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="retryCount"></param>
        public static void DoTrue(
            Func<bool> action,
            TimeSpan retryInterval,
            int retryCount = 3)
        {
            for (int retry = 0; retry < retryCount; retry++)
            {
                if (retry > 0)
                    Thread.Sleep(retryInterval);
                if (action()) { return; };
            }
        }

        /// <summary>
        /// Retries method until method returns 'false'.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="retryCount"></param>
        public static void DoFalse(
            Func<bool> action,
            TimeSpan retryInterval,
            int retryCount = 3)
        {
            for (int retry = 0; retry < retryCount; retry++)
            {
                if (retry > 0)
                    Thread.Sleep(retryInterval);
                if (!action()) { return; };
            }
        }

        public static T NotNull<T>(
            Func<T> action,
            TimeSpan retryInterval,
            int retryCount = 3)
        {
            T result = default(T);
            for (int retry = 0; retry < retryCount; retry++)
            {
                if (retry > 0)
                    Thread.Sleep(retryInterval);
                result = action();
                if (result != null) { return result; }
            }
            return result;
        }
    }
}
