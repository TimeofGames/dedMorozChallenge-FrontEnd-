using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Structure;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace Scripts
{
    public class PointSetter : MonoBehaviour
    {
        
        public static void GPS(List<City> cities, Transform map)
        {
            int radius = 6371;
            Vector3[] way = new Vector3[cities.Count];
            for (int i = 0; i < cities.Count; i++)
            {
                float templongitude = (float) cities[i].Longitude * Mathf.PI / 180;
                float templatitude = (float) cities[i].Latitude * Mathf.PI / 180;
                int Xpos = (int) (radius * Mathf.Cos(templatitude) * Mathf.Cos(templongitude));
                int Ypos = (int) (radius * Mathf.Cos(templatitude) * Mathf.Sin(templongitude));
                map.GetComponent<LineRenderer>().positionCount++;
                way[i] = (new Vector3(Xpos / 100, Ypos / 100, -1));
            }

            map.GetComponent<LineRenderer>().SetPositions(way);
            map.GetComponent<LineRenderer>().startWidth = 0.2f;
            map.GetComponent<LineRenderer>().endWidth = 0.2f;
        }
            
    }
}