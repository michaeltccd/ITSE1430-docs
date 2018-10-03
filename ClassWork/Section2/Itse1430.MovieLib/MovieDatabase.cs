using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    public class MovieDatabase
    {
        public void Add ( Movie movie )
        {
            var index = FindNextFreeIndex();
            if (index >= 0)
                _movies[index] = movie;
        }

        private int FindNextFreeIndex ()
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index] == null)
                    return index;
            };

            return -1;
        }

        private Movie[] _movies = new Movie[100];

        public Movie[] GetAll()
        {
            //How many movies do we have
            var count = 0;
            foreach (var movie in _movies)
            {
                if (movie != null)
                    ++count;
            };
            
            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _movies)
            {
                if (movie != null)
                    temp[index++] = movie;
            };

            return temp;
        }
    }
}
