using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    public class Movie : IValidatableObject
    {
        //Property to back the name field
        public string Name
        {
            //Using expression body
            //get { return _name ?? ""; }  // string get ()
            get => _name ?? "";

            //Using expression body
            //set { _name = value; }       // void set ( string value )
            set => _name = value;
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

        //First line is a RW field, second line is using expression
        //body getter property
        //public bool IsColor = ReleaseYear > 1940;
        public bool IsColor => ReleaseYear > 1940;
        //{
        //    //get { return ReleaseYear > 1940; }
        //    get => ReleaseYear > 1940;
        //}

        public bool IsOwned { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //Using iterator syntax instead of List<T>
            //var results = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required.",
                                new[] { nameof(Name) });

            if (ReleaseYear < 1900)
                yield return new ValidationResult("Release year must be >= 1900",
                                new[] { nameof(ReleaseYear) });

            if (RunLength < 0)
                yield return new ValidationResult("Run length must be >= 0",
                                new[] { nameof(RunLength) });
        }


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
