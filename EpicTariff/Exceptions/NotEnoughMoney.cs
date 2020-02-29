using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff.Sexception
{
    [Serializable]
    class NotEnoughMoney : Exception
    {
        public NotEnoughMoney()
        { }
    }
}
