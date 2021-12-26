using UnityEngine;

namespace Structure
{
    public class City : MonoBehaviour
    {
        private readonly string _name;
        private readonly string _index;
        private readonly double _latitude;
        private readonly double _longitude;
        private readonly string _population;

        public City(string name, string index, double latitude, double longitude, string population)
        {
            _name = name;
            _index = index;
            _latitude = latitude;
            _longitude = longitude;
            _population = population;
        }
        
        public string Name => _name;

        public string Index => _index;

        public double Latitude => _latitude;

        public double Longitude => _longitude;

        public string Population => _population;
        
    }
}
