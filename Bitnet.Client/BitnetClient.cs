// COPYRIGHT 2013 by Piotr "ThePiachu" Piasecki
// Based on code by Konstantin Ineshin, Irkutsk, Russia.

// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Net.Security;
using System.Collections;

namespace Bitnet
{
	public static class BitnetClient
	{
		static BitnetClient() {}

		public static void Setup(string sUri)
		{
			Url = new Uri(sUri);
		}

		public static Uri Url;

		public static ICredentials Credentials;

		public static JObject InvokeMethod(string sMethod, params object[] parameters)
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
			webRequest.Credentials = Credentials;

			webRequest.ContentType = "application/json-rpc";
			webRequest.Method = "POST";

			JObject joe = new JObject();
			joe["jsonrpc"] = "1.0";
			joe["id"] = "1";
			joe["method"] = sMethod;

			if (parameters != null)
			{
				if (parameters.Length > 0)
				{
					JArray props = new JArray();
					foreach (var p in parameters)
					{
						if (p.GetType().IsGenericType && p is IEnumerable)
						{
							JArray l = new JArray();
							foreach (var i in (IEnumerable) p)
							{
								l.Add(i);
							}
							props.Add(l);
						}
						else
						{
							props.Add(p);
						}
					}
					joe.Add(new JProperty("params", props));
				}
			}

			string s = JsonConvert.SerializeObject(joe);
			// serialize json for the request
			byte[] byteArray = Encoding.UTF8.GetBytes(s);
			webRequest.ContentLength = byteArray.Length;
			ServicePointManager.ServerCertificateValidationCallback = new
				RemoteCertificateValidationCallback
				(
					delegate { return true; }
				);

			using (Stream dataStream = webRequest.GetRequestStream()) {
			dataStream.Write(byteArray, 0, byteArray.Length);
			}
			try
			{
				using (WebResponse webResponse = webRequest.GetResponse())
				{
					using (Stream str = webResponse.GetResponseStream())
					{
						using (StreamReader sr = new StreamReader(str))
						{
							return JsonConvert.DeserializeObject<JObject>(sr.ReadToEnd());
						}
					}
				}
			}
			catch (WebException e)
			{
				Console.WriteLine();

				Console.WriteLine(e.ToString());

				var resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();

				JObject obj = JsonConvert.DeserializeObject<JObject>(resp);
				//var messageFromServer = obj.error.message;

				Console.WriteLine(obj.ToString());
				Console.WriteLine();

				return obj;
			}
			return null;
		}

		public static JObject AddMultisigAddress(int required, JArray keys)
		{
			return InvokeMethod("addmultisigaddress", required, keys);
		}

		public static JObject AddMultisigAddress(int required, JArray keys, string account)
		{
			return InvokeMethod("addmultisigaddress", required, keys, account);
		}
		public static JObject CreateMultisig(int required, JArray keys)
		{
			return InvokeMethod("createmultisig", required, keys);
		}
		
		public static void BackupWallet(string destination)
		{
			InvokeMethod("backupwallet", destination);
		}

		public static JObject CreateRawTransaction(JArray ins, JObject outs)
		{
			return InvokeMethod("createrawtransaction", ins, outs);
		}

		/*public static JObject CreateRawTransaction(JArray ins, JArray outs)
		{
			return InvokeMethod("createrawtransaction", ins, outs);
		}*/

		public static JObject DecodeRawTransaction(string tx)
		{
			return InvokeMethod("decoderawtransaction", tx);
		}

		public static JObject GetAccount(string address)
		{
			return InvokeMethod("getaccount", address);
		}

		public static JObject GetAccountAddress(string account)
		{
			return InvokeMethod("getaccountaddress", account);
		}

		public static JObject GetAddressesByAccount(string account)
		{
			return InvokeMethod("getaddressesbyaccount", account);
		}

		public static JObject GetBalance(string account = null, int minconf = 1)
		{
			if (account == null)
			{
				return InvokeMethod("getbalance");
			}
			return InvokeMethod("getbalance", account, minconf);
		}

		public static JObject GetBlockByCount(int height)
		{
			return InvokeMethod("getblockbycount", height);
		}

		public static JObject GetBlockCount()
		{
			return InvokeMethod("getblockcount");
		}

		public static JObject GetBlockNumber()
		{
			return InvokeMethod("getblocknumber");
		}

		public static JObject GetConnectionCount()
		{
			return InvokeMethod("getconnectioncount");
		}

		public static JObject GetDifficulty()
		{
			return InvokeMethod("getdifficulty");
		}

		public static JObject GetGenerate()
		{
			return InvokeMethod("getgenerate");
		}

		public static JObject GetHashesPerSec()
		{
			return InvokeMethod("gethashespersec");
		}

		public static JObject GetInfo()
		{
			return InvokeMethod("getinfo");
		}

		public static JObject GetNewAddress(string account)
		{
			return InvokeMethod("getnewaddress", account);
		}

		public static JObject GetRawTransaction(string txid)
		{
			return InvokeMethod("getrawtransaction", txid);
		}

		public static JObject GetReceivedByAccount(string account, int minconf = 1)
		{
			return InvokeMethod("getreceivedbyaccount", account, minconf);
		}

		public static JObject GetReceivedByAddress(string address, int minconf = 1)
		{
			return InvokeMethod("getreceivedbyaddress", address, minconf);
		}

		public static JObject GetTransaction(string txid)
		{
			return InvokeMethod("gettransaction", txid);
		}

		public static JObject GetWork()
		{
			return InvokeMethod("getwork");
		}

		public static JObject GetWork(string data)
		{
			return InvokeMethod("getwork", data);
		}

		public static JObject Help(string command = "")
		{
			return InvokeMethod("help", command);
		}

		public static JObject ListAccounts(int minconf = 1)
		{
			return InvokeMethod("listaccounts", minconf);
		}

		public static JObject ListReceivedByAccount(int minconf = 1, bool includeEmpty = false)
		{
			return InvokeMethod("listreceivedbyaccount", minconf, includeEmpty);
		}

		public static JObject ListReceivedByAddress(int minconf = 1, bool includeEmpty = false)
		{
			return InvokeMethod("listreceivedbyaddress", minconf, includeEmpty);
		}

		public static JObject ListTransactions(string account, int count = 10)
		{
			return InvokeMethod("listtransactions", account, count);
		}
		public static JObject ListUnspent(int minconf = 1, int maxconf = 999999)
		{
			return InvokeMethod("listunspent", minconf, maxconf);
		}
		public static JObject ListUnspent(int minconf, int maxconf, List<string> addresses)
		{
			return InvokeMethod("listunspent", minconf, maxconf, addresses);
		}
		

		public static JObject Move(
			string fromAccount, 
			string toAccount, 
			decimal amount, 
			int minconf = 1, 
			string comment = ""
		)
		{
			return InvokeMethod(
			"move", 
			fromAccount, 
			toAccount, 
			amount, 
			minconf, 
			comment
			);
		}

		public static JObject SendFrom(
			string fromAccount, 
			string toAddress, 
			decimal amount, 
			int minconf = 1, 
			string comment = "", 
			string commentTo = ""
		)
		{
			return InvokeMethod(
			"sendfrom", 
			fromAccount, 
			toAddress, 
			amount, 
			minconf, 
			comment, 
			commentTo
			);
		}


		public static JObject SendRawTransaction(string hexstring)
		{
			return InvokeMethod("sendrawtransaction", hexstring);
		}

		public static JObject SendToAddress(string address, decimal amount, string comment, string commentTo)
		{
			return InvokeMethod("sendtoaddress", address, amount, comment, commentTo);
		}

		public static void SetAccount(string address, string account)
		{
			InvokeMethod("setaccount", address, account);
		}

		public static void SetGenerate(bool generate, int genproclimit = 1)
		{
			InvokeMethod("setgenerate", generate, genproclimit);
		}

		public static JObject SignRawTransaction(string hexstring)
		{
			return InvokeMethod("signrawtransaction", hexstring);
		}

		public static void Stop()
		{
			InvokeMethod("stop");
		}

		public static JObject ValidateAddress(string address)
		{
			return InvokeMethod("validateaddress", address);
		}

		public static JObject WalletPassphrase(string passphrase, int timeout)
		{
			return InvokeMethod("walletpassphrase", passphrase, timeout);
		}

		public static JObject WalletLock()
		{
			return InvokeMethod("walletlock");
		}
	}
}
