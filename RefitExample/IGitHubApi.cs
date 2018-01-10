using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefitExample
{
    public interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<User> GetUser(string user);
    }
}
