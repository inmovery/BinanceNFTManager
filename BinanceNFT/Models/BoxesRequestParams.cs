using System.Collections.Generic;

namespace BinanceNFT.Models
{
	public class BoxesRequestParams
	{
		public BoxesRequestParams(string keyword, int nftType, string orderBy, int orderType, List<string> serialNo, int tradeType)
		{
			Keyword = keyword;
			NftType = nftType;
			OrderBy = orderBy;
			OrderType = orderType;
			SerialNo = serialNo;
			TradeType = tradeType;
		}

		public string Keyword { get; set; }

		public int NftType { get; set; }

		public string OrderBy { get; set; }

		public int OrderType { get; set; }

		public IList<string> SerialNo { get; set; }

		public int TradeType { get; set; }
	}
}
