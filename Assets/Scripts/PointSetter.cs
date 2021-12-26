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
        
        public static void GPS(List<City> cities, Transform map , List<int> way)
        {
      
      map.GetComponent<LineRenderer>().positionCount=0;
      int radius = 6371;
   

         Vector3[] lineWay = new Vector3[way.Count];
            for (int i = 0; i < way.Count; i++)
            {
        
                float templongitude = (float) cities[way[i]].Longitude * Mathf.PI / 180;
                float templatitude = (float) cities[way[i]].Latitude * Mathf.PI / 180;
                float Xpos =  (radius * Mathf.Cos(templatitude) * Mathf.Cos(templongitude))/40;
                float Ypos = (radius * Mathf.Cos(templatitude) * Mathf.Sin(templongitude))/50;
                map.GetComponent<LineRenderer>().positionCount++;
                lineWay[i] = (new Vector3(-Xpos, -Ypos , -1));
            }

            map.GetComponent<LineRenderer>().SetPositions(lineWay);
            
            map.GetComponent<LineRenderer>().material.color = Color.black;
            map.GetComponent<LineRenderer>().startWidth = 0.2f;
            map.GetComponent<LineRenderer>().endWidth = 0.2f;
        }
            
    }
}