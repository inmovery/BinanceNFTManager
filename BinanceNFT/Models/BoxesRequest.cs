using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BinanceNFT.Models
{
	public class BoxesRequest
	{
		public BoxesRequest(int page, int size, BoxesRequestParams paramsValue)
		{
			Page = page;
			Size = size;
			Params = paramsValue;
		}

		[JsonProperty]
		public int Page { get; set; }

		[JsonProperty]
		public int Size { get; set; }

		[JsonProperty]
		public BoxesRequestParams Params { get; set; }
	}
}
