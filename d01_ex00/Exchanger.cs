using System;
using System.Collections.Generic;
using System.IO;

namespace d01_ex00
{
	class Exchanger
	{
		List<ExchangeRate> rates = new List<ExchangeRate>();

		bool ValidCurrencyId(string CurrencyId) {
			return (CurrencyId == "RUB" || CurrencyId == "USD" || CurrencyId == "EUR");
		}

		public bool ReadRatesFromDirectory(string ratesDir) {
			string[] rateFiles;
			
			try {
				rateFiles = Directory.GetFiles(ratesDir);
			} catch {
				return false;
			}

			foreach (var rateFile in rateFiles)
				if (!ReadRatesFromFile(rateFile))
					return false;

			return true;
		}

		bool ReadRatesFromFile(string rateFile) {
			var CurrencyIdFrom = Path.GetFileNameWithoutExtension(rateFile);
			
			if (!ValidCurrencyId(CurrencyIdFrom) || Path.GetExtension(rateFile) != ".txt")
				return false;

			string[] lines = File.ReadAllLines(rateFile);
			foreach (var line in lines)
				if (!ReadRateFromString(CurrencyIdFrom, line))
					return false;

			return true;
		}

		bool ReadRateFromString(string CurrencyIdFrom, string line) {
			var exchangeRate=new ExchangeRate();

			if (!exchangeRate.TryParse(CurrencyIdFrom, line))
				return false;

			if (exchangeRate.CurrencyIdFrom == exchangeRate.CurrencyIdTo)
				return true;

			foreach (var rate in rates)
				if (rate.CurrencyIdFrom == exchangeRate.CurrencyIdFrom
					&& rate.CurrencyIdTo == exchangeRate.CurrencyIdTo)
					return rate.Rate == exchangeRate.Rate;

			rates.Add(exchangeRate);
			return true;
		}

		public IEnumerable<ExchangeSum> Exchange(ExchangeSum exchangeSum) {
			foreach (var rate in rates)
				if (rate.CurrencyIdFrom == exchangeSum.CurrencyId) {
					var result = new ExchangeSum();
					result.CurrencyId = rate.CurrencyIdTo;
					result.Sum = exchangeSum.Sum * rate.Rate;
					yield return result;
				}
		}
	}
}
