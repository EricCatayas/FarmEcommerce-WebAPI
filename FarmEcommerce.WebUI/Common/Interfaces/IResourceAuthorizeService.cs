namespace FarmEcommerce.WebUI.Common.Interfaces
{
    public interface IResourceAuthorizeService<T>
    {
        Task<bool> IsAuthorized(T input);
    }
}
