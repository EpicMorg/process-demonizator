using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PD.CLI.CORE.Core {

    public interface ILogManager {

        Task<IEnumerable<string>> Show( int tailCount );

        void Log( string s );

    }

    public class LogManager : ILogManager {

        private Stack<string> _repository;
        private IInternalSettings _settings;

        public LogManager( ISettingsFactory settings ) {
            _settings = settings.Get();
            _repository = new Stack<string>();
        }

        public async Task<IEnumerable<string>> Show( int tailCount ) => _repository.AsEnumerable().Reverse().Take( tailCount ).Reverse();

        public void Log( string s ) {
            _repository.Push( s );
            Console.Error.WriteLine( $"{DateTime.Now.ToString("G")}: {s}");
        }
    }

}