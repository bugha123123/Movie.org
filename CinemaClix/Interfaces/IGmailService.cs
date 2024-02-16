namespace CinemaClix.Interfaces
{
    public interface IGmailService
    {
        void SendPasswordResetEmail( string resetToken);
    }
}
