using System;
using System.Collections.Specialized;
using UrlTouch.CommandLineParsing;
using NLog;
using UrlTouch.WebAccess;
using System.Linq;

namespace UrlTouch
{
	internal class Program
	{
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private static int Main( string[] args )
		{
			try
			{
				var urlInfo = ParseArguments( args );
				var urlTouchService = new UrlTouchService();

				_logger.Debug( "About to touch '{0}'", urlInfo.Url );
				
				var results = urlTouchService.TouchUrl( urlInfo );
				
				_logger.Info( "Touched '{0}'.", urlInfo.Url );
				_logger.Trace( "Results of last touch at '{0}':\n{1}", urlInfo.Url, results );
				return 0;
			}
			catch( InvalidCommandLineArgumentsException exc )
			{
				LogHelpWarning( exc.Message );
				return -1;
			}
			catch( Exception exc )
			{
				_logger.ErrorException( string.Format( "Error encountered" ), exc );
				return -1;
			}
		}

		private static UrlInfo ParseArguments( string[] args )
		{
			if( args.Length == 0 )
			{
				throw new InvalidCommandLineArgumentsException( "No arguments supplied" );
			}

			var url = args[ 0 ];
			var touchArgs = CommandLineDictionary.FromArguments( args.Skip( 1 ), '-', '=' );
			
			var postArgs = new NameValueCollection();
			foreach( var touchArg in touchArgs )
			{
				postArgs.Add( touchArg.Key, touchArg.Value ); 
			}

			return new UrlInfo( url, postArgs ); 
		}

		private static void LogHelpWarning( string message )
		{
			_logger.Warn( "Could not launch UrlTouch: {0}.\nUsage: UrlTouch http://url [-getArg1=value -getArg2=value].", message );
		}
	}
}