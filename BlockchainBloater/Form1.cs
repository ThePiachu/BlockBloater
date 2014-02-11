using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bitnet;
using Newtonsoft.Json.Linq;
using System.Net;


namespace BlockchainBloater
{
	public partial class Form1 : Form
	{
		string BlockBloaterAccount = "BlockBloater";
		public Form1()
		{
			InitializeComponent();
		}

		private void Run_Click(object sender, EventArgs e)
		{
			string username = RPCUsername.Text;
			string password = RPCPassword.Text;
			string port = RPCPort.Text;
			int iterations = int.Parse(Iterations.Value.ToString());
			decimal amount = Amount.Value;
			string walletPassword = WalletPassword.Text;

			BitnetClient.Setup("http://127.0.0.1:"+port+"/");
			BitnetClient.Credentials = new NetworkCredential(username, password);

			string address = (string)BitnetClient.GetNewAddress(BlockBloaterAccount)["result"];
			string address2 = (string)BitnetClient.GetNewAddress(BlockBloaterAccount)["result"];

			Printout.Text = "Running...";
			this.Refresh();

			if (!walletPassword.Equals(""))
				BitnetClient.WalletPassphrase(walletPassword, 10000);

			for (int i = 0; i < iterations; i++)
			{
				Printout.Text = "Running - "+(i+1).ToString()+"/"+iterations.ToString();
				this.Refresh();
				
				BloatOnce(address, address2, amount);
			}

			Printout.Text = "Done!";
			this.Refresh();

			if (!walletPassword.Equals(""))
				BitnetClient.WalletLock();

		}

		//We sort the array to use the oldest transactions first
		public JArray SortInputsByConfirmations(JArray inputs)
		{
			List<JObject> ins = new List<JObject>();

			for (int i = 0; i < inputs.Count; i++)
			{
				ins.Add((JObject)inputs[i]);
			}

			ins = ins.OrderBy(t => -(decimal)t["confirmations"]).ToList();

			JArray answer = new JArray();
			for (int i = 0; i < ins.Count; i++)
			{
				answer.Add(ins[i]);
			}

			return answer;
		}

		public void BloatOnce(string destinationAddress, string changeAddress, decimal amount)
		{
			JArray unspent = (JArray)BitnetClient.ListUnspent(0)["result"];
			unspent = SortInputsByConfirmations(unspent);
			List<JObject> inTxs = new List<JObject>();
			decimal runningAmount = 0;
			for (int i = 0; i < unspent.Count; i++)
			{
				inTxs.Add((JObject)unspent[i]);
				runningAmount += (decimal)unspent[i]["amount"];
				if (runningAmount > amount)
					break;
			}

			JObject outs = new JObject();
			outs.Add(destinationAddress, amount);
			outs.Add(changeAddress, runningAmount-amount);

			JArray ins = new JArray();

			for (int i=0;i<inTxs.Count;i++)
			{
				JObject in1 = new JObject();
				in1.Add("vout", (int)inTxs[i]["vout"]);
				in1.Add("txid", inTxs[i]["txid"]);
				ins.Add(in1);
			}

			Console.WriteLine("ins - "+ins.ToString());
			Console.WriteLine("outs - " + outs.ToString());

			string raw = BitnetClient.CreateRawTransaction(ins, outs)["result"].ToString();
			Console.WriteLine("raw - " + raw);
			/*JObject raw2 = BitnetClient.DecodeRawTransaction(raw);
			Console.WriteLine("raw2 - " + raw2);*/


			JObject raw3 = BitnetClient.SignRawTransaction(raw);
			Console.WriteLine("raw3 - " + raw3.ToString());
			raw = (string)raw3["result"]["hex"];
			/*raw2 = BitnetClient.DecodeRawTransaction(raw);
			Console.WriteLine("raw2 - " + raw2);*/
			JObject response = BitnetClient.SendRawTransaction(raw);
			Console.WriteLine("response - " + response.ToString());
		}

	}
}
