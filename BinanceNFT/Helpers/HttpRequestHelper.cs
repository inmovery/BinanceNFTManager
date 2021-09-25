﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BinanceNFT.Helpers
{
	public class HttpRequestHelper
	{
		public static string HttpPost(string Url, string postDataStr, ref bool isSuccess)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
				request.Method = "POST";
				request.ContentType = "application/json";
				request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
				//request.CookieContainer = cookie;
				Stream myRequestStream = request.GetRequestStream();
				StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
				myStreamWriter.Write(postDataStr);
				myStreamWriter.Close();

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				//response.Cookies = cookie.GetCookies(response.ResponseUri);
				Stream myResponseStream = response.GetResponseStream();
				StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
				string retString = myStreamReader.ReadToEnd();
				myStreamReader.Close();
				myResponseStream.Close();

				return retString;
			}
			catch (Exception e)
			{
				isSuccess = false;
				Console.Write(e.Message);
				return e.Message;
			}
		}

		public string HttpGet(string Url, string postDataStr)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
			request.Method = "GET";
			request.ContentType = "application/json";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream myResponseStream = response.GetResponseStream();
			StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
			string retString = myStreamReader.ReadToEnd();
			myStreamReader.Close();
			myResponseStream.Close();

			return retString;
		}

		/// <summary>  
		// Create a GET method of the HTTP request  
		/// </summary>  
		//public static HttpWebResponse CreateGetHttpResponse(string url, int timeout, string userAgent, CookieCollection cookies)
		public static HttpWebResponse CreateGetHttpResponse(string url)
		{
			HttpWebRequest request = null;
			if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				// for server certificate validity check (non-third-party certificate issued by the authority, as one of his generation, not be verified, return true here)
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request = WebRequest.Create(url) as HttpWebRequest;
				request.ProtocolVersion = HttpVersion.Version10; // http version, the default is 1.1, this is set to 1.0
			}
			else
			{
				request = WebRequest.Create(url) as HttpWebRequest;
			}
			request.Method = "GET";

			// set the proxy UserAgent and overtime
			//request.UserAgent = userAgent;
			//request.Timeout = timeout;
			//if (cookies != null)
			//{
			//    request.CookieContainer = new CookieContainer();
			//    request.CookieContainer.Add(cookies);
			//}
			return request.GetResponse() as HttpWebResponse;
		}

		/// <summary>  
		// create a POST HTTP request  
		/// </summary>  
		//public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int timeout, string userAgent, CookieCollection cookies)
		public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters)
		{
			HttpWebRequest request = null;
			// If it sends an HTTPS request  
			if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				//ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request = WebRequest.Create(url) as HttpWebRequest;
				//request.ProtocolVersion = HttpVersion.Version10;
			}
			else
			{
				request = WebRequest.Create(url) as HttpWebRequest;
			}
			request.Method = "POST";
			request.ContentType = "application/json";

			// set the proxy UserAgent and overtime
			//request.UserAgent = userAgent;
			//request.Timeout = timeout; 

			//if (cookies != null)
			//{
			//    request.CookieContainer = new CookieContainer();
			//    request.CookieContainer.Add(cookies);
			//}
			// send POST data  
			if (!(parameters == null || parameters.Count == 0))
			{
				StringBuilder buffer = new StringBuilder();
				int i = 0;
				foreach (string key in parameters.Keys)
				{
					if (i > 0)
					{
						buffer.AppendFormat("&{0}={1}", key, parameters[key]);
					}
					else
					{
						buffer.AppendFormat("{0}={1}", key, parameters[key]);
						i++;
					}
				}
				byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
				using (Stream stream = request.GetRequestStream())
				{
					stream.Write(data, 0, data.Length);
				}
			}
			string[] values = request.Headers.GetValues("Content-Type");
			return request.GetResponse() as HttpWebResponse;
		}

		/// <summary>
		/// Get Data request
		/// </summary>
		public static string GetResponseString(HttpWebResponse webresponse)
		{
			using (Stream s = webresponse.GetResponseStream())
			{
				StreamReader reader = new StreamReader(s, Encoding.UTF8);
				return reader.ReadToEnd();

			}
		}

		/// <summary>
		/// verification certificate
		/// </summary>
		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			if (errors == SslPolicyErrors.None)
				return true;
			return false;
		}
	}
}
