using System;
using System.Runtime.Serialization;

namespace UrlTouch.CommandLineParsing
{
	[ Serializable ]
	public class InvalidCommandLineArgumentsException : Exception
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public InvalidCommandLineArgumentsException()
		{
		}

		public InvalidCommandLineArgumentsException( string message )
			: base( message )
		{
		}

		public InvalidCommandLineArgumentsException( string message, Exception inner )
			: base( message, inner )
		{
		}

		protected InvalidCommandLineArgumentsException(
			SerializationInfo info,
			StreamingContext context )
			: base( info, context )
		{
		}
	}
}