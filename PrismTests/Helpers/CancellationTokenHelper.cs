using System;
using System.Threading;

namespace PrismTests.Helpers
{
    public static class CancellationTokenHelper
    {
        /// <summary>
        /// Setups the cancellation token.
        /// </summary>
        /// <param name="cancellationTokenSource">The cancellation token source.</param>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds value.</param>
        public static CancellationTokenSource SetupCancellationToken(CancellationTokenSource cancellationTokenSource, int timeoutInMilliseconds = 0)
        {
            try
            {
                // Try to cancel any previous task
                cancellationTokenSource?.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // Soak it up...
            }

            // Ensure we have a valid CancellationTokenSource, if not, create a new instance
            cancellationTokenSource = new CancellationTokenSource();

            // If we provided a valid timeout in seconds value set our CancellationTokenSource with it, in milliseconds.
            if (timeoutInMilliseconds > 0) cancellationTokenSource.CancelAfter(timeoutInMilliseconds);

            // Return CancellationTokenSource
            return cancellationTokenSource;
        }

        /// <summary>
        /// Cancels and disposes the cancellation token source object.
        /// </summary>
        /// <param name="cancellationTokenSource">The cancellation token source.</param>
        /// <param name="createNewCancellationTokenSource">The create new cancellation token source.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public static bool CleanupCancellationToken(ref CancellationTokenSource cancellationTokenSource, bool createNewCancellationTokenSource = false)
        {
            try
            {
                // Validate
                if (cancellationTokenSource != null)
                {
                    // Cleanup
                    cancellationTokenSource?.Cancel();
                    cancellationTokenSource?.Dispose();

                    // Do we want to create a new CancellationTokenSource?
                    if (createNewCancellationTokenSource)
                    {
                        // Create new instance of CancellationTokenSource
                        cancellationTokenSource = new CancellationTokenSource();
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // Default
                return false;
            }

            // Default
            return true;
        }
    }
}
