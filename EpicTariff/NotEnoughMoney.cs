using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    [Serializable]
    class NotEnoughMoney : Exception
    {
        public NotEnoughMoney()
        { }
    }
}
