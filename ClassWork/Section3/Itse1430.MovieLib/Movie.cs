using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    public class Movie
    {
        //Property to back the name field
        public string Name
        {
            get { return _name ?? ""; }  // string get ()
            set { _name = value; }       // void set ( string value )
        }

        //Backing field for name
        private string _name = "";
               
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }        

        private string _description;

        //Using auto property with field initializer
        public int ReleaseYear { get; set; } = 1900;
        
        //Using auto property
        public int RunLength { get; set; }
        
        //Using mixed accessibility
        public int Id { get; private set; }

        //Using calculated property with no setter
        public bool IsColor
        {
            get { return ReleaseYear > 1940; }
        }

        public bool IsOwned { get; set; }

        #region Unused Code

        //Don't make fields public
        //public System.String Name;

        //public string GetName ()
        //{
        //    return _name ?? "";
        //}
        //public void SetName ( string value )
        //{
        //    _name = value;
        //}

        //public string GetDescription ()
        //{
        //    return _description ?? "";
        //}

        //public void SetDescription ( Movie this, string value )
        //public void SetDescription ( string value )
        //{
        //    //this._description = value;
        //    //this.
        //    _description = value;
        //}

        //{
        //    get { return _releaseYear; }
        //    set {
        //        if (value >= 1900)
        //            _releaseYear = value;
        //    }
        //}

        //public int GetReleaseYear()
        //{
        //    return _releaseYear;
        //}
        //public void SetReleaseYear ( int value )
        //{
        //    if (value >= 1900)
        //        _releaseYear = value;
        //}
        //private int _releaseYear = 1900;

        //Auto property syntax

        //public int GetRunLength()
        //{
        //    return _runLength;
        //}
        //public void SetRunLength( int value )
        //{
        //    if (value >= 0)
        //        _runLength = value;
        //}
        //private int _runLength;

        //int someValue;
        //private int someValue2;

        //void Foo ()
        //{
        //    var x = RunLength;

        //    var isLong = x > 100;

        //    var y = someValue;

        //}
        #endregion
    }
}
