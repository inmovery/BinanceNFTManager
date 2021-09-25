namespace BinanceNFT.Models
{
	public class Box
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string ProductId { get; set; }

		public string Image { get; set; }

		public long StartTime { get; set; }

		public long EndTime { get; set; }

		public double Price { get; set; }

		public string Currency { get; set; }

		public int Status { get; set; }

		public string Duration { get; set; }

		public string SubTitle { get; set; }

		public int MappingStatus { get; set; }

		public int Store { get; set; }

		public bool IsGray { get; set; }

		public string SerialsNo { get; set; }

		public int SecondMarketSellingDelay { get; set; }
	}
}
