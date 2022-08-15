using CaseItauWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.DAL.Interface
{
    public interface IAuthDAL
    {
        Token GetToken(Users users);
    }
}
