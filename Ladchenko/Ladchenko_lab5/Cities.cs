//////////////////////////////////////////////////////////////////////////////////////////////////
// File Name: Cities.cs
//      Date: 06/01/2006
// Copyright (c) 2006 Michael LaLena. All rights reserved.  (www.lalena.com)
// Permission to use, copy, modify, and distribute this Program and its documentation,
//  if any, for any purpose and without fee is hereby granted, provided that:
//   (i) you not charge any fee for the Program, and the Program not be incorporated
//       by you in any software or code for which compensation is expected or received;
//   (ii) the copyright notice listed above appears in all copies;
//   (iii) both the copyright notice and this Agreement appear in all supporting documentation; and
//   (iv) the name of Michael LaLena or lalena.com not be used in advertising or publicity
//          pertaining to distribution of the Program without specific, written prior permission. 
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Globalization;

namespace Tsp
{
    
    public class Cities : List<City>
    {
        
        public void CalculateCityDistances( int numberOfCloseCities )
        {
            foreach (City city in this)
            {
                city.Distances.Clear();

                for (int i = 0; i < Count; i++)
                {
                    city.Distances.Add(Math.Sqrt(Math.Pow((double)(city.Location.X - this[i].Location.X), 2D) +
                                       Math.Pow((double)(city.Location.Y - this[i].Location.Y), 2D)));
                }
            }

            foreach (City city in this)
            {
                city.FindClosestCities(numberOfCloseCities);
            }
        }

        
        public void OpenCityList(string fileName)
        {
            DataSet cityDS = new DataSet();

            try
            {
                this.Clear();

                cityDS.ReadXml(fileName);

                DataRowCollection cities = cityDS.Tables[0].Rows;

                foreach (DataRow city in cities)
                {
                    this.Add(new City(Convert.ToInt32(city["X"], CultureInfo.CurrentCulture), Convert.ToInt32(city["Y"], CultureInfo.CurrentCulture)));
                }
            }
            finally
            {
                cityDS.Dispose();
            }
        }
    }
}
