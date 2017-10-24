using PrizeDraw;
using PrizeDraw.Abstracts;
using PrizeDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoTest
{
	class Program
	{
		static public List<string> ReadSalesData()
		{
			List<string> salesData = new List<string>();

			System.Diagnostics.Process cmd = new System.Diagnostics.Process();

			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;

			cmd.Start();
			cmd.StandardInput.Flush();


			cmd.StandardInput.WriteLine("echo 5 > input.txt");
			cmd.StandardInput.WriteLine("echo 3 1 2 3 >> input.txt");
			cmd.StandardInput.WriteLine("echo 2 1 1 >> input.txt");
			cmd.StandardInput.WriteLine("echo 4 10 5 5 1 >> input.txt");
			cmd.StandardInput.WriteLine("echo 0 >> input.txt");
			cmd.StandardInput.WriteLine("echo 1 2 >> input.txt");
			//cmd.StandardInput.WriteLine("PrizeDraw < input.txt");
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			string line;
			int i = 0;

			do
			{
				line = cmd.StandardOutput.ReadLine();
				i++;
				if (line != null)
				{
					if (line.IndexOf("echo") >= 0)
					{
						int readLineFrom = line.IndexOf("echo") + 5;
						int readLineLength = line.IndexOf("> input.txt") - readLineFrom - 1;
						salesData.Add(line.Substring(readLineFrom, readLineLength));

						Console.WriteLine(line);

					}
					else if (line.IndexOf("PrizeDraw < input.txt") > 0)
					{
						Console.WriteLine(line);

						break;
					}
					//Console.WriteLine(line);
					//Console.WriteLine("Line " + i.ToString() + " -- " + line);
				}
			} while (line != null);
			Console.WriteLine("PrizeDraw < input.txt");
			return salesData;
		}

		static void Main(string[] args)
		{
			//ReadSalesData();
			var salesLines = ReadSalesData();
			var salesData = SalesCampaign.PrepareSalesData(salesLines.Select(t => t.ToString()).ToArray());

			var salesCampaing = new SalesCampaign(salesData);

			Console.WriteLine("{0}", salesCampaing.GetTotalPrizeMoney());
			Console.ReadKey();

			//Console.ReadLine();
		}
	}
}
