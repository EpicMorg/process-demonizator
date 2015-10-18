using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PD.Api.DataTypes;

namespace PD.CLI.CORE.Api {

    public interface IProcessManager {

        Task<IInternalDemonizedProcess> Get( int id );

        Task<IEnumerable<IDemonizedProcessBase>> List();

        Task<IEnumerable<IInternalDemonizedProcess>> ListFull();

        Task<int> Create( IPasswordedDemonizedProcess model );

        Task Delete( int id );

    }
    public class ProcessManager: IProcessManager {

        private Dictionary<int, IInternalDemonizedProcess> _processes;//stub

        private int i = 0;

        private async Task<int> NextId() => i++;//todo: actual id

        public async Task<IInternalDemonizedProcess> Get( int id ) => _processes[ id ];

        public async Task<IEnumerable<IDemonizedProcessBase>> List() {
            return _processes.Values.OfType<IDemonizedProcessBase>();//todo: actual data
        }

        public async Task<IEnumerable<IInternalDemonizedProcess>> ListFull() {
            return _processes.Values;//todo: data updating
        }

        public async Task<int> Create( IPasswordedDemonizedProcess model ) {
            var insert = (IInternalDemonizedProcess)model;//todo: actual mapping
            insert.Id = await NextId().ConfigureAwait( false );
            _processes.Add( insert.Id, insert );
            return insert.Id;
        }

        public async Task Delete( int id ) => _processes.Remove( id );

    }

}