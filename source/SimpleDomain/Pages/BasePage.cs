using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimpleDomain.Pages
{
    public interface IDataClient
    {
        Task PostAsync<T, TK>(Uri path, T request);
    }

    public abstract class BasePage<TMapper> : PageModel
    {
        protected BasePage(TMapper mapper, IDataClient dataClient)
        {
            Mapper = mapper;
            DataClient = dataClient;
        }

        public TMapper Mapper { get; }

        public IDataClient DataClient { get; }

        protected IActionResult ValidateSelectLists(params (IEnumerable<SelectListItem>, string)[] selectListItems)
        {
            var redirectPath = selectListItems
                .FirstOrDefault(tuple => !tuple.Item1.Any())
                .Item2;

            if (!string.IsNullOrEmpty(redirectPath))
            {
                return RedirectToPage(redirectPath);
            }

            return Page();
        }

        protected async Task<IActionResult> ValidateAndSend<TRequest, TResponse>(TRequest request, string path, Uri postPath)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await DataClient.PostAsync<TRequest, TResponse>(postPath, request);

            return RedirectToPage(path);
        }
    }
}
