using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using EyeTracking.Models.Shape;

namespace EyeTracking.Utils.Csv
{
    public sealed class FixationClassMap : ClassMap<FixationCircle>
    {
        public FixationClassMap()
        {
            Map(m => m.Number).Index(0).Name("Number");
            Map(m => m.FixationTime).Index(1).Name("Fixation Time");
            Map(m => m.X).Index(2).Name("Center X");
            Map(m => m.Y).Index(3).Name("Center Y");
            Map(m => m.Height).Index(4).Name("Height");
            Map(m => m.Width).Index(5).Name("Width");
            Map(m => m.Origin.X).Index(6).Name("Origin X");
            Map(m => m.Origin.Y).Index(7).Name("Origin Y");
            Map(m => m.Color.A).Index(8).Name("Color A");
            Map(m => m.Color.R).Index(9).Name("Color R");
            Map(m => m.Color.G).Index(10).Name("Color G");
            Map(m => m.Color.B).Index(11).Name("Color B");

            Map(m => m.Color.ScA).Ignore();
            Map(m => m.Color.ScB).Ignore();
            Map(m => m.Color.ScG).Ignore();
            Map(m => m.Color.ScR).Ignore();
        }
    }
}