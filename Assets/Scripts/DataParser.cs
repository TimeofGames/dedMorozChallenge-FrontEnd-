using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Structure;
using UnityEngine;


namespace Scripts
{
    public class DataParser : MonoBehaviour
    {
        private List<City> _cities = new List<City>();

        public List<City> Cities => _cities;
   

        void Start()
        {
            StreamReader sr = new StreamReader("Assets/Data/Data/Cities.csv");
            string line = sr.ReadLine();
            string[] lineAfterSplit = new string[5];
            while ((line = sr.ReadLine()) != null)
            {
                lineAfterSplit = line.Split(',');
                lineAfterSplit[2] = lineAfterSplit[2].Replace('.', ',');
                lineAfterSplit[3] = lineAfterSplit[3].Replace('.', ',');
                _cities = _cities.Append(new City(lineAfterSplit[0],lineAfterSplit[1],double.Parse(lineAfterSplit[2]),double.Parse(lineAfterSplit[3]),lineAfterSplit[4])).ToList();
            }
     
        }
    }
}
