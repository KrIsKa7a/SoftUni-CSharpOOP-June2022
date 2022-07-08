namespace Telephony.Models.Interfaces
{
    //This can be implemented by smartphone, tablet, laptop, pc
    public interface IBrowseable
    {
        string BrowseURL(string url);
    }
}
