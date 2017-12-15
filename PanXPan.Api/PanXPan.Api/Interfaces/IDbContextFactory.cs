namespace PanXPan.Api.Interfaces
{
    public interface IDbContextFactory<out T>
    {
        T GetContext();
    }
}
