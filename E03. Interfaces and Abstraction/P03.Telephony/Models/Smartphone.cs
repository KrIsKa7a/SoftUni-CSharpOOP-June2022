namespace Telephony.Models
{
    using Interfaces;

    public class Smartphone : ICallable, IBrowseable
    {
        public string BrowseURL(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
