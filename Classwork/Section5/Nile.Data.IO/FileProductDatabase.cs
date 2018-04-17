using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nile.Data.IO
{
    /// <summary>Provides a file based implementation of <see cref="IProductDatabase"/>.</summary>
    public class FileProductDatabase : ProductDatabase
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="FileProductDatabase"/> class.</summary>
        /// <param name="filename">The filename.</param>
        /// <exception cref="ArgumentNullException"><paramref name="filename"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="filename"/> is empty.</exception>
        public FileProductDatabase ( string filename )
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            _filename = filename;
        }
        #endregion

        protected override Product AddCore( Product product )
        {
            EnsureInitialized();

            product.Id = _id++;
            _items.Add(product);

            SaveData();

            return product;
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            EnsureInitialized();

            return _items;
        }        

        protected override Product GetCore( int id )
        {
            EnsureInitialized();

            return _items.FirstOrDefault(i => i.Id == id);
        }
        
        protected override Product GetProductByNameCore( string name )
        {
            EnsureInitialized();

            return _items.FirstOrDefault(
                    i => String.Compare(i.Name, name, true) == 0);
        }

        protected override void RemoveCore( int id )
        {
            EnsureInitialized();

            var product = GetCore(id);
            if (product != null)
            {
                _items.Remove(product);
                SaveData();
            };
        }

        protected override Product UpdateCore( Product product )
        {
            EnsureInitialized();

            var existing = GetCore(product.Id);

            _items.Remove(existing);
            _items.Add(product);

            SaveData();

            return product;
        }

        #region Private Members

        //Ensure file is loaded
        private void EnsureInitialized()
        {
            if (_items == null)
            {
                _items = LoadData();

                if (_items.Any())
                {
                    _id = _items.Max(i => i.Id);
                    ++_id;
                };
            };
        }

        private List<Product> LoadData()
        {
            var items = new List<Product>();

            try
            {
                //Make sure the file exists
                if (!File.Exists(_filename))
                    return items;

                var lines = File.ReadAllLines(_filename);

                foreach (var line in lines)
                {
                    var fields = line.Split(',');

                    //Not checking for missing fields here
                    var product = new Product() {
                        Id = ParseInt32(fields[0]),
                        Name = fields[1],
                        Description = fields[2],
                        Price = ParseDecimal(fields[3]),
                        IsDiscontinued = ParseInt32(fields[4]) != 0
                    };
                    items.Add(product);
                };

                return items;
            } catch (Exception e)
            {
                throw new Exception("Failure loading data", e);
            };
        }

        private void SaveData()
        {
            using (var stream = File.OpenWrite(_filename))
            using (var writer = new StreamWriter(stream))
            { 
                foreach (var item in _items)
                {
                    var line = $"{item.Id},{item.Name},{item.Description}," +
                               $"{item.Price},{(item.IsDiscontinued ? 1 : 0)}";

                    writer.WriteLine(line);
                };            
            };
        }

        private void SaveDataPoorer()
        {
            Stream stream = null;
            StreamWriter writer = null;
            try
            {
                stream = File.OpenWrite(_filename);
                writer = new StreamWriter(stream);

                foreach (var item in _items)
                {
                    var line = $"{item.Id},{item.Name},{item.Description}," +
                               $"{item.Price},{(item.IsDiscontinued ? 1 : 0)}";

                    writer.WriteLine(line);
                };                
            } catch (ArgumentException e)
            {
                //Example of rethrowing an exception
                //throw e;  never right!!
                throw;
            } catch (Exception e)
            {
                //Example of wrapping an exception to hide details
                throw new Exception("Save failed", e);
            } finally
            {
                writer?.Close();
                stream?.Close();
            };
        }

        private void SaveDataNonstream ()
        {
            var lines = _items.Select(item => 
                            $"{item.Id},{item.Name},{item.Description}," +
                            $"{item.Price},{(item.IsDiscontinued ? 1 : 0)}");

            File.WriteAllLines(_filename, lines);
        }

        private decimal ParseDecimal( string value )
        {
            if (Decimal.TryParse(value, out var result))
                return result;

            return -1;
        }

        private int ParseInt32( string value )
        {
            if (Int32.TryParse(value, out var result))
                return result;

            return -1;
        }

        private readonly string _filename;
        private List<Product> _items;
        private int _id;
        #endregion
    }
}
