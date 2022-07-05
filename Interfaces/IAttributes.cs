using System;
using System.Collections.Generic;
using System.Text;

namespace Project{

    interface IAttributes{

        double Volume { get; set; } 
        double Weight { get; set; }

        double GetVolume();
        double GetWeight();
        void SetVolume(double _volume);
        void SetWeight(double _weight);

    }


}