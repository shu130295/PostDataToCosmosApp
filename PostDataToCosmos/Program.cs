using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDataToCosmos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DocumentDBRepository<Location>.Initialize();
            string filePath = @"C:\Users\shubh\Documents\SampleCsvToPostToCosmos.csv";

            if (File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        var values = s.Split(',');
                        Location loc = new Location()
                        {
                            latitude = Convert.ToDouble(values[0]),
                            longitude = Convert.ToDouble(values[1]),
                            locality = values[2],
                            sublocality = values[3]
                        };

                        await DocumentDBRepository<Location>.CreateItemAsync(loc);
                    }
                }
            }
           
            

        }
    }

    class Location
    {
        public string locality;
        public string sublocality;
        public double latitude;
        public double longitude;
    }
}
