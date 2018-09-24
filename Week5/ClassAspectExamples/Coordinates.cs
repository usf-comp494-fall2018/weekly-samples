using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAspectExamples
{
    public class Coordinates
    {
        /**********************************************************************
           Constructors
        **********************************************************************/
        public Coordinates()
        {
            X = default(int);
            Y = default(int);
            Z = default(int);
        }

        public Coordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /**********************************************************************
           Methods
        **********************************************************************/
        public string BuildOutput()
        {
            return $"({X},{Y},{Z})";
        }

        /**********************************************************************
           Fields (Properties)
        **********************************************************************/
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
