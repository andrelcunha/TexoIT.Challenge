using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using System.Globalization;
using TEXOit.Core.Extensions;
using TEXOit.Core.Models;

namespace TEXOit.Services
{
    public class CsvService
    {
        private readonly string _CvsFile;
        public List<MovieDTO> records = new List<MovieDTO>();

        public CsvService(IOptions<AppSettings> settings)
        {

            _CvsFile = settings.Value.CsvFile;

            StreamReader reader;
            CsvReader csv;
            GetCsvData(out reader, out csv);
        }

        private void GetCsvData(out StreamReader reader, out CsvReader csv)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
            //List<MovieRead> records = new List<MovieRead>();

            var path = GetPath(_CvsFile);
            reader = new StreamReader(path);
            csv = new CsvReader(reader, config);
            records = csv.GetRecords<MovieDTO>().ToList();
        }

        private static string GetPath(string file)
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(exePath);
            string filePeth = Path.Combine(path, file);

            return filePeth;
        }

        //public static void LoadData(out List<string> listX, out List<string> listY)
        //{
        //    string path = GetPath();
        //    using (var reader = new StreamReader(path))
        //    {
        //        //List<string> listA = new List<string>();
        //        //List<string> listB = new List<string>();
        //        listX = new List<string>();
        //        listY = new List<string>();

        //        while (!reader.EndOfStream)
        //        {
        //            string line = reader.ReadLine();
        //            string[] values = line.Split(",");

        //            listX.Add(values[0]);
        //            listY.Add(values[1]);
        //        }
        //    }
        //}
    }
}
