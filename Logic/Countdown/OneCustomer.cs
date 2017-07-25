using System;

namespace Logic
{
    /// <summary>
    /// Class that responds to the event.
    /// </summary>
    public class OneCustomer
    {
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public OneCustomer() { }

        /// <summary>
        /// OneCustomer is registered for countdown event.
        /// </summary>
        /// <param name="countdown">Event to register.</param>
        public void Register(CountdownHelper countdown) => countdown.Countdown += OneCustomerCountdown;

        /// <summary>
        /// OneCustomer is unregistered for countdown event.
        /// </summary>
        /// <param name="countdown">Event to unregister.</param>
        public void Unregister(CountdownHelper countdown) => countdown.Countdown -= OneCustomerCountdown;

        /// <summary>
        /// Method responds to the event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Object, that contains data about event.</param>
        public void OneCustomerCountdown(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"one - time: {e.Time}, message: {e.Message}");
        }
    }
}
