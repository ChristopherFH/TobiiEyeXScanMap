using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using EyeTracking.Models;
using EyeTracking.Models.Shape;

namespace EyeTracking.Utils.Csv
{
    public static class CsvWriter
    {
        public static void WriteCollectionToCsv(IEnumerable records, Type classtype, string filename, ClassMap classMap)
        {
            using (var sw = new StreamWriter(filename))
            {
                var csvHelper = new CsvHelper.CsvWriter(sw);
                csvHelper.Configuration.RegisterClassMap(classMap);

                csvHelper.WriteHeader(classtype);
                csvHelper.NextRecord();

                csvHelper.WriteRecords(records);
                sw.Flush();
                csvHelper.Flush();
            }
        }

        public static void WriteCollectionToCsv(IEnumerable records, Type classtype, string filename)
        {
            using (var sw = new StreamWriter(filename))
            {
                var csvHelper = new CsvHelper.CsvWriter(sw);
                csvHelper.WriteHeader(classtype);
                csvHelper.NextRecord();

                csvHelper.WriteRecords(records);
                sw.Flush();
                csvHelper.Flush();
            }
        }

        public static void WriteObjectToCsv(Metrics metrics, Type classtype, string filename)
        {
            using (var sw = new StreamWriter(filename))
            {
                var csvHelper = new CsvHelper.CsvWriter(sw);
                csvHelper.WriteHeader(classtype);
                csvHelper.NextRecord();

                csvHelper.WriteField(metrics.Distance);
                csvHelper.WriteField(metrics.Number);
                sw.Flush();
                csvHelper.Flush();
            }
        }
    }
}