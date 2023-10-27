namespace SocialNetwork.Core.Utilities.EmailHelper
{
    public interface IMailHelper
    {
        bool SendEmail(string mailAddress, string token, bool bodyHtml);
    }
}
