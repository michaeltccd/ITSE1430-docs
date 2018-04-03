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

        public FileProductDatabase ( string filename )
        {
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

            //LoadData();
            return _items;
        }        

        protected override Product GetCore( int id )
        {
            EnsureInitialized();

            //Use Enumerable.FirstOrDefault
            return _items.FirstOrDefault(i => i.Id == id);
            //foreach (var item in _items)
            //{
            //    if (item.Id == id)
            //        return item;
            //};

            //return null;
        }
        
        //Compiler converts previous lambda into a private type with
        //this method, effectively
        //private bool IsId ( Product product )
        //{
        //    return product.Id == id;
        //}

        protected override Product GetProductByNameCore( string name )
        {
            EnsureInitialized();

            //Use Enumerable.FirstOrDefault
            return _items.FirstOrDefault(
                    i => String.Compare(i.Name, name, true) == 0);

            //foreach (var item in _items)
            //{
            //    if (String.Compare(item.Name, name, true) == 0)
            //        return item;
            //};

            //return null;
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

                //_id = 0;
                //foreach (var item in _items)
                //{
                //    if (item.Id > _id)
                //        _id = item.Id;
                //};
                //Using Enumerable.Any
                if (_items.Any())
                {
                    //Using Enumerable.Max
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

                //Could do with Enumerable.Select
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
                //Example of wrapping an exception to hide the details
                throw new Exception("Failure loading data", e);
            };
        }

        private void SaveData()
        {
            using (var stream = File.OpenWrite(_filename))
            using (var writer = new StreamWriter(stream))
            { 
                //Not easily doable with Enumerable, stick with foreach
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
                //Never right!!!
                //throw e;
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
            //Using Enumerable.Select
            var lines = _items.Select(item => 
                            $"{item.Id},{item.Name},{item.Description}," +
                            $"{item.Price},{(item.IsDiscontinued ? 1 : 0)}");

            //var lines = new List<string>();

            //foreach (var item in _items)
            //{
            //    var line = $"{item.Id},{item.Name},{item.Description}," +
            //               $"{item.Price},{(item.IsDiscontinued ? 1 : 0)}";
            //    lines.Add(line);
            //};

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
