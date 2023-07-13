using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IAuthServiceRepository
    {
      public  Task<AuthModel> RegisterAsync(RegisterModel model);
      //public  Task<AuthModel> GetTokenAsync(TokenRequestModel model);
      //public  Task<string> AddRoleAsync(AddRoleModel model);
    }
}
