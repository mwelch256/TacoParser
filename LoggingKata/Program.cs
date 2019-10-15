using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable taco1 = null;
            ITrackable taco2 = null;

            double distance = 0;

            TacoBell newLocation = new TacoBell() { };

            var LocA = new GeoCoordinate();
            var LocB = new GeoCoordinate();
            
            

           

            for(int i = 0; i < locations.Length; i++)

            {
                LocA.Latitude = locations[i].Location.Latitude;
                LocA.Longitude = locations[i].Location.Longitude;

                for(int j = 0; j < locations.Length; j++)

                {
                    LocB.Latitude = locations[j].Location.Latitude;
                    LocB.Longitude = locations[j].Location.Longitude;

                   
                    var newDistance = LocA.GetDistanceTo(LocB);
              
                   if (newDistance > distance)
                    {
                        taco1 = locations[i];
                        taco2 = locations[j];
                        distance = newDistance;
                    }


                }

            }

            Console.WriteLine($"The two taco bells the futherest from each other are { taco1.Name} && {taco2.Name} ");
            



            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}