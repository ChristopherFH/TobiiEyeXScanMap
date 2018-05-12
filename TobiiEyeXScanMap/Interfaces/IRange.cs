using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTracking.Interfaces
{
    public interface IRange 
    {
        bool IsInRange(double x, double y); 
    }
}
