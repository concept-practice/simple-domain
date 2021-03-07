namespace SimpleDomain.Pages
{
    using System;
    using System.Threading.Tasks;

    public interface IDataClient
    {
        Task PostAsync<T, TK>(Uri path, T request);
    }
}
