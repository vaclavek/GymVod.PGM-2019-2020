using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Čtverec : Obdelnik
    {
        public Čtverec(int strana) : base(strana, strana)
        {
        }

        public override string VratInformace()
        {
            return "Ahoj, já jsem čtverec o straně " + stranaA;
        }

        
    }
}
