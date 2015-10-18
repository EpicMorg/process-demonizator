using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PD.CLI.CORE.Core {

    public interface ILogManager {

        Task<IEnumerable<string>> Show( int tailCount );

    }

    public class LogManager : ILogManager {

        private List<string> _repository;
        private IInternalSettings _settings;

        public LogManager( ISettingsFactory settings ) { _settings = settings.Get(); }

        public async Task<IEnumerable<string>> Show( int tailCount ) => _repository.AsEnumerable().Reverse().Take( tailCount ).Reverse();

    }

}