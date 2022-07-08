namespace Telephony.Models
{
    using Interfaces;

    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
