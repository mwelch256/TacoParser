namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            string [] cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("If length is less than 3 you stupid");
                return null;
            }

            double lat = double.Parse(cells[0]);
            double lon = double.Parse(cells[1]);
            string name = cells[2];


            var TB = new TacoBell();
            var Location = new Point();

            Location.Latitude = lat;
            Location.Longitude = lon;

            TB.Name = name;
            TB.Location = Location;

            return TB;
                
           

        }
    }
}