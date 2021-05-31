using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
	struct ExchangeSum
	{
		public double Sum;
		public string CurrencyId;

		bool ValidCurrencyId(string CurrencyId) {
			return (CurrencyId == "RUB" || CurrencyId == "USD" || CurrencyId == "EUR");
		}

		public bool TryParse(string sumString) {
			string[] split = sumString.Split(new char[] { ' ' });
			if (split.Length != 2
				|| !double.TryParse(split[0],
					System.Globalization.NumberStyles.Any,
					new System.Globalization.CultureInfo("en-US"), out Sum)
				|| Sum < 0
				|| !ValidCurrencyId(split[1]))
				return false;
			CurrencyId = split[1];
			return true;
		}

		public override string ToString() {
			return String.Format(new System.Globalization.CultureInfo("en-US"), $"{Sum:N2} {CurrencyId}");
		}
	}
}
