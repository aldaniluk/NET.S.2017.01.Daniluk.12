using System;

namespace Logic
{
    /// <summary>
    /// Class that responds to the event.
    /// </summary>
    public class TwoCustomer
    {
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public TwoCustomer() { }

        /// <summary>
        /// TwoCustomer is registered for countdown event.
        /// </summary>
        /// <param name="countdown">Event to register.</param>
        public void Register(CountdownHelper countdown) => countdown.Countdown += TwoCustomerCountdown;

        /// <summary>
        /// TwoCustomer is unregistered for countdown event.
        /// </summary>
        /// <param name="countdown">Event to unregister.</param>
        public void Unregister(CountdownHelper countdown) => countdown.Countdown -= TwoCustomerCountdown;

        /// <summary>
        /// Method responds to the event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Object, that contains data about event.</param>
        public void TwoCustomerCountdown(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"two - time: {e.Time}, message: {e.Message}");
        }
    }
}
