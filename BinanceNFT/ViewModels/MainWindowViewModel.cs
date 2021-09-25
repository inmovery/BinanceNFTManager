using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using BinanceNFT.Commands;
using BinanceNFT.Helpers;
using BinanceNFT.Models;
using BinanceNFT.ViewModels.Base;
using Newtonsoft.Json;

namespace BinanceNFT.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private List<Box> _boxes;

		public MainWindowViewModel()
		{
			Boxes = new List<Box>();
			SendRequestCommand = new RelayCommand(SendRequest);
		}

		public ICommand SendRequestCommand { get; }

		public List<Box> Boxes
		{
			get => _boxes;
			set
			{
				_boxes = value;
				RaisePropertyChanged();
			}
		}

		private void SendRequest()
		{
			var url = "https://www.binance.com/bapi/nft/v1/public/nft/market-mystery/mystery-list";
			var isSuccess = false;
			var cookie = "cid=zZY9LDFM; _ga=GA1.2.650005555.1630705298; bnc-uuid=4ef27fb7-b68f-4c8d-875a-198a6f803512; campaign=yabs.yandex.ru; source=organic; home-ui-ab=A; nft-init-compliance=true; rskxRunCookie=0; rCookie=zwmspv7epzso27gleabtkt67f0wr; __ssid=4c960819fda9cf63518727e3788e5d2; theme=dark; defaultMarketTab=spot; next-expire-time=1631876995615; fiat-prefer-currency=RUB; sensorsdata2015jssdkcross={\"distinct_id\":\"37495744\",\"first_id\":\"17bad9c2ed617 - 08b999df965b32 - 37631644 - 2073600 - 17bad9c2ed7e1a\",\"props\":{\"$latest_traffic_source_type\":\"直接流量\",\"$latest_search_keyword\":\"未取到值_直接打开\",\"$latest_referrer\":\"\"},\"$device_id\":\"17bad9c2ed617 - 08b999df965b32 - 37631644 - 2073600 - 17bad9c2ed7e1a\"}; userPreferredCurrency=USD_USD; lastRskxRun=1631890701926; BNC_FV_KEY=31ebd395450ea677b2e4eee38ee937fe9d57a63c; BNC_FV_KEY_EXPIRE=1632394874533; _gid=GA1.2.497429244.1632309462; s9r1=792453DA6BCC341B0260D5D1A336A2B1; lang=en; cr00=28A4D968EBE6F5D8D81C146DF002F24F; d1og=web.37495744.E8D97EFD807AF9E701B8641FCECF2F5B; r2o1=web.37495744.543C60AF08739B1D2EE9604E919BEF95; f30l=web.37495744.D73E55D6F570DB63A5E1431F05484C8E; logined=y; isAccountsLoggedIn=y; __BINANCE_USER_DEVICE_ID__={\"5ffdc2ada1b666985a044395448b0e1e\":{\"date\":1632319772178,\"value\":\"1632319772211t6S890yn2jM24LU9Y6S\"}}; p20t=web.37495744.9BE5094FFA644ABFB0BE01FB8F25BB06";

			byte[] bytes = Encoding.Default.GetBytes(cookie);
			cookie = Encoding.UTF8.GetString(bytes);

			var postDataStr = "{'page': 1,'size': 16,'params': {'keyword': '','nftType': 2,'orderBy': 'amount_sort','orderType': 1,'serialNo': ['134200991506621440'],'tradeType': 0}}";

			var boxesRequestParams = new BoxesRequestParams("", 2, "amount_sort", 1, new List<string>() { "134200991506621440" }, 0);
			var boxesRequest = new BoxesRequest(1, 16, boxesRequestParams);

			var boxesRequestData = Newtonsoft.Json.JsonConvert.SerializeObject(boxesRequest);

			// HttpRequestHelper.HttpPost(url, boxesRequestData, cookie, ref isSuccess);

			var boxesRequestUrl = "https://www.binance.com/bapi/nft/v1/public/nft/mystery-box/list?page=1&size=100";
			var boxesResponse = HttpRequestHelper.HttpGet(boxesRequestUrl);

			Clipboard.SetText(boxesResponse);

			var boxes = JsonConvert.DeserializeObject<Boxes>(boxesResponse);
			if (boxes != null) 
				Boxes = new List<Box>(boxes.Data);
		}
	}
}
