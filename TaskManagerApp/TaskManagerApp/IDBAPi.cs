using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace TaskManagerApp
{
    public interface IDBAPi
    {
        [Get("/api/v1/products.json?brand=maybelline")]
        Task<string> GetMakeUps();
    }
}
