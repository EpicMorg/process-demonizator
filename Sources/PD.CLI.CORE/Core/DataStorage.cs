using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PD.CLI.CORE.Core
{
    public interface IDataStorage<T> {

        Task SaveAsync( string path, T value );

        Task<T> LoadAsync(string path);

        void Save(string path, T value);

        T Load(string path);
    }

    public class DataStorage<T> : IDataStorage<T> {

        private readonly string _root;

        private static readonly XmlSerializer _Serializer = new XmlSerializer(typeof(T));

        public DataStorage( string root ) {
            _root = root;
        }

        public async Task SaveAsync( string path, T value ) => Save( path, value );

        public async Task<T> LoadAsync( string path ) => Load( path );

        public void Save( string path, T value ) {
            using ( var f = File.Open( Resolve( path ), FileMode.OpenOrCreate, FileAccess.ReadWrite ) ) {
                f.SetLength( 0 );
                _Serializer.Serialize( f, value );
            }
        }

        public T Load( string path ) {
            using ( var f = File.OpenRead( Resolve( path ) ) )
                return (T) _Serializer.Deserialize( f );
        }


        private string Resolve(string path) { return Path.Combine(_root, path); }

    }

    public interface IDataStorageFactory<T> : IFactory<DataStorage<T>> {

    }

    public class DataStorageFactory<T> : IDataStorageFactory<T> {

        public DataStorage<T> Get() { throw new NotImplementedException(); }

    }

}
