using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PD.Api.Client {

    internal static class MethodsHelper {

        internal static async Task<string> PostClientKey( this HttpClient client, int id, string key, string action ) {
            var content = new FormUrlEncodedContent( new[] { new KeyValuePair<string, string>( "key", key ) } );
            var resp = await client.PostAsync( $"{id}/{action}", content ).ConfigureAwait( false );
            ThrowOnNonSuccess( resp );
            var ret = await resp.Content.ReadAsStringAsync().ConfigureAwait( false );
            return ret;
        }

        internal static void ThrowOnNonSuccess( HttpResponseMessage resp ) {
            if ( !resp.IsSuccessStatusCode )
                throw new Exception( $"Bad server response status code({resp.StatusCode})" );
        }

        internal static HttpClient CreateClient( string server, string path ) {
            var v = new HttpClient( new HttpClientHandler() ) { BaseAddress = new Uri( new Uri(server), path ) };
            v.DefaultRequestHeaders.Accept.Clear();
            v.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
            return v;
        }

    }

}