using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PD.Api;
using PD.Api.DataTypes;

namespace PD.CLI.CORE.Api {

    public class AdminApi : IAdminApi {

        public IAdminProcessMethods Process { get; }
        public ISettingsMethods Settings { get; }
        public ILogMethods Log { get; }

    }

    public class AdminProcessMethods : IAdminProcessMethods {

        private IProcessManager _processRepository;

        public async Task<IEnumerable<IDemonizedProcessBase>> List() => (await _processRepository.List().ConfigureAwait(false));

        public async Task<IEnumerable<IRunningDemonizedProcess>> ListFull() => (await _processRepository.ListFull().ConfigureAwait( false ));

        public async Task Edit( IPasswordedDemonizedProcess model ) {
            if ( model == null ) {
                throw new ArgumentNullException(nameof( model ));
            }
            var existing = await _processRepository.Get( model.Id ).ConfigureAwait( false );
            //todo: update model
        }

        public async Task<int> Create( IPasswordedDemonizedProcess model ) => await _processRepository.Create(model).ConfigureAwait(false);

        public async Task<IRunningDemonizedProcess> Get( int id ) => await _processRepository.Get( id ).ConfigureAwait( false ) ;

        public async Task Start( int id ) => await(await _processRepository.Get(id).ConfigureAwait(false)).Start().ConfigureAwait(false);

        public async Task Stop( int id ) => await(await _processRepository.Get(id).ConfigureAwait(false)).Stop().ConfigureAwait(false);

        public async Task Restart( int id ) => await(await _processRepository.Get(id).ConfigureAwait(false)).Restart().ConfigureAwait(false);

        public async Task Delete( int id ) => await _processRepository.Delete( id ).ConfigureAwait( false );

        public async Task Show( int id ) => await(await _processRepository.Get(id).ConfigureAwait(false)).Show().ConfigureAwait(false);

        public async Task Hide( int id ) => await ( await _processRepository.Get( id ).ConfigureAwait( false ) ).Hide().ConfigureAwait( false );

    }

    public class SettingsMethods : ISettingsMethods {

        public Task<ISettings> GetSettins { get; }

        public Task SetSettins( ISettings settings ) { throw new NotImplementedException(); }

        public Task SetKey( string key ) { throw new NotImplementedException(); }

    }

    public class Log : ILogMethods {

        public Task<ICollection<string>> Show( int tailCount ) { throw new NotImplementedException(); }

    }

}