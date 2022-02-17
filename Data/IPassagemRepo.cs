using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecdetTeste.Models;

namespace TecdetTeste.Data
{
    interface IPassagemRepo
    {
        bool saveChanges();

        void createPassagem(Passagem passagem);

        Passagem getPassagemById(int id);
    }
}
