using CaseItauWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.DAL.Interface
{
    public interface IFundoDAL
    {
        List<FundoModel> GetAllFundos();
        FundoModel GetFundo(string codigo);
        bool RegisterFundo(FundoModel fundo);
        bool UpdateFundo(string codigo, FundoModel fundo);
        bool RemoveFundo(string codigo);
        bool MovePatrimony(string codigo, FundoModel value);
    }
}
