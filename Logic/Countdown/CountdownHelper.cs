using System;
using System.Threading;

namespace Logic
{
    /// <summary>
    /// Class handles the countdown event.
    /// </summary>
    public class CountdownHelper
    {
        /// <summary>
        /// Countdown event.
        /// </summary>
        public event EventHandler<CountdownEventArgs> Countdown = delegate { };

        /// <summary>
        /// Creates new countdown with given time and message.
        /// </summary>
        /// <param name="time">Waiting time.</param>
        /// <param name="message">Some info.</param>
        public void CreateNewCountdown(int time, string message)
        {
            OnCountdown(new CountdownEventArgs(time, message));
        }

        /// <summary>
        /// Notifies registered objects about the event.
        /// </summary>
        /// <param name="countdownEvent">Object, that contains data about event.</param>
        private void OnCountdown(CountdownEventArgs countdownEvent)
        {
            if (!ReferenceEquals(Countdown, null))
            {
                Thread.Sleep(countdownEvent.Time);
                Countdown.Invoke(this, countdownEvent);
            }
        }
    }

    /// <summary>
    /// Class contains data about countdown event.
    /// </summary>
    public class CountdownEventArgs : EventArgs
    {
        #region private fields
        private int time;
        private string message;
        #endregion

        #region properties
        /// <summary>
        /// Time in milliseconds.
        /// </summary>
        public int Time { get => time; }

        /// <summary>
        /// Some info about event.
        /// </summary>
        public string Message { get => message; }
        #endregion

        #region ctors
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="time">Time in milliseconds.</param>
        /// <param name="message">Some info about event.</param>
        public CountdownEventArgs(int time, string message)
        {
            if (CheckTime(time)) this.time = time;
            if (CheckMessage(message)) this.message = message;
        }
        #endregion

        #region private methods
        private bool CheckTime(int time)
        {
            if(time < 0) throw new ArgumentException($"{nameof(time)} is unsuitable.");
            return true;
        }
        private bool CheckMessage(string message)
        {
            if (ReferenceEquals(message, null)) throw new ArgumentNullException($"{nameof(message)} is null.");
            if (message.Length == 0) throw new ArgumentNullException($"{nameof(message)} is empty.");
            return true;
        }
        #endregion
    }
}
