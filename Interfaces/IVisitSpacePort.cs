using System;
using System.Collections.Generic;
using System.Text;

namespace Project{

    interface IVisitSpacePort : IAttributes{

        //double VisitSpacePort();
        double SellGetCost(double _sell);
        double BuyGetCost(double _buy);
        double RefillGetCost();
    }


}