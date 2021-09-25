using System.Net;

namespace BinanceNFT.Helpers
{
	public static class CookiesHandler
	{
		public static bool TryAddCookie(this WebRequest webRequest, Cookie cookie)
		{
			HttpWebRequest httpRequest = webRequest as HttpWebRequest;
			if (httpRequest == null)
			{
				return false;
			}
			if (httpRequest.CookieContainer == null)
			{
				httpRequest.CookieContainer = new CookieContainer();
			}
			httpRequest.CookieContainer.Add(cookie);
			return true;
		}
	}
}
