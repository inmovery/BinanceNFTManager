using System.Collections.Generic;
using Newtonsoft.Json;

namespace BinanceNFT.Models
{
	public class Boxes
	{
		public string Code { get; set; }
		public object Message { get; set; }
		public object MessageDetail { get; set; }
		public IList<Box> Data { get; set; }
		public int Total { get; set; }
		public bool Success { get; set; }
	}
}
