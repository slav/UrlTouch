using System.Collections.Specialized;
using Netco.Network;

namespace UrlTouch.WebAccess
{
	public class UrlTouchService
	{
		/// <summary>
		/// 	Touches the specified URL.
		/// </summary>
		/// <returns>The result of accessing specified URL.</returns>
		public string TouchUrl( UrlInfo urlInfo )
		{
			var poster = new PostSubmitter( urlInfo.Url ) { Type = PostSubmitter.PostTypeEnum.Get, PostItems = urlInfo.Args };
			var results = poster.Post();
			return results;
		}
	}
}