using System.Collections.Specialized;

namespace UrlTouch.WebAccess
{
	public sealed class UrlInfo
	{
		public UrlInfo( string url, NameValueCollection args )
		{
			this.Url = url;
			this.Args = args;
		}

		/// <summary>
		/// Gets or sets the URL to touch.
		/// </summary>
		/// <value>The URL to touch.</value>
		public string Url{ get; private set; }

		/// <summary>
		/// Gets or sets the args for GET or POST message.
		/// </summary>
		/// <value>The args.</value>
		public NameValueCollection Args{ get; private set; }
	}
}