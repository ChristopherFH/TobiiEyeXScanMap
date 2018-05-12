using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using EyeTracking.Models.Shape;

namespace EyeTracking.Utils.Csv
{
    public sealed class ConnectionLineClassMap : ClassMap<ConnectionLine>
    {
        public ConnectionLineClassMap()
        {
            Map(m => m.X).Index(0).Name("X1");
            Map(m => m.Y).Index(1).Name("Y1");
            Map(m => m.X2).Index(2).Name("X2");
            Map(m => m.Y2).Index(3).Name("Y2");
            Map(m => m.Distance).Index(4).Name("Distance");
            Map(m => m.Color.A).Index(5).Name("Color A");
            Map(m => m.Color.R).Index(6).Name("Color R");
            Map(m => m.Color.G).Index(7).Name("Color G");
            Map(m => m.Color.B).Index(8).Name("Color B");

            Map(m => m.Color.ScA).Ignore();
            Map(m => m.Color.ScB).Ignore();
            Map(m => m.Color.ScG).Ignore();
            Map(m => m.Color.ScR).Ignore();
        }
    }
}
