using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAspectExamples
{
    public enum ShapeColors { Red, Yellow, Blue, Orange, Green, Purple }

    public class Shape
    {
        /**********************************************************************
           Class Variables
        **********************************************************************/
        protected static Coordinates _centerOfMyWorld;
        protected Coordinates _myCoordinates;
        protected const ShapeColors _defaultColor = ShapeColors.Yellow;
        protected readonly string _shapeName;
        protected ShapeColors _myColor;

        /**********************************************************************
           Constructors
        **********************************************************************/
        public Shape(string shapeName)
        {
            _shapeName = shapeName;
            _centerOfMyWorld = new Coordinates();
            _myCoordinates = new Coordinates();
            _myColor = _defaultColor;
        }

        public Shape(string shapeName, ShapeColors myColor, Coordinates myCoordinates)
        {
            _shapeName = shapeName;
            _myColor = myColor;
            _myCoordinates = myCoordinates;
        }

        /**********************************************************************
           Methods
        **********************************************************************/
        public string BuildOutput()
        {
            string strRc = string.Empty;
            strRc = $"A {MyColor} {ShapeName} located at {MyCoordinates.BuildOutput()}";
            return strRc;
        }

        public string GetCenterOfMyWorld()
        {
            return _centerOfMyWorld.BuildOutput();
        }

        /**********************************************************************
           Fields (Properties)
        **********************************************************************/
        public string ShapeName
        {
            get
            {
                return _shapeName;
            }
            private set {; }
        }

        public Coordinates MyCoordinates
        {
            get
            {
                return _myCoordinates;
            }
            set
            {
                _myCoordinates = value;
            }
        }

        public ShapeColors MyColor
        {
            get
            {
                return _myColor;
            }
            set
            {
                _myColor = value;
            }
        }

        public Coordinates CenterOfMyWorld
        {
            get
            {
                return _centerOfMyWorld;
            }
            set
            {
                _centerOfMyWorld = value;
            }
        }
    }
}
