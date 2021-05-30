namespace d01_ex00
{
	struct ExchangeRate
	{
		public string CurrencyIdFrom;
		public string CurrencyIdTo;
		public double Rate;

		bool ValidCurrencyId(string CurrencyId) {
			return (CurrencyId == "RUB" || CurrencyId == "USD" || CurrencyId == "EUR");
		}

		public bool TryParse(string CurrencyIdFrom, string CurrencyIdToColonRate) {
			if (!ValidCurrencyId(CurrencyIdFrom))
				return false;
			string[] split = CurrencyIdToColonRate.Split(new char[] { ':' });
			if (split.Length != 2
				|| !ValidCurrencyId(split[0])
				|| !double.TryParse(split[1], out Rate)
				|| Rate <= 0)
				return false;
			this.CurrencyIdFrom = CurrencyIdFrom;
			CurrencyIdTo = split[0];
			if (CurrencyIdFrom == CurrencyIdTo && Rate != 1)
				return false;
			return true;
		}

	}
}
