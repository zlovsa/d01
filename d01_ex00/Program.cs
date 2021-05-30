using System;
using System.Collections.Generic;
using d01_ex00;

if (args.Length != 2) {
	Console.WriteLine("Usage: d01_ex00 '<sum> <currency>' '<rates dir>'");
	return;
}

var sum = new ExchangeSum();

if (!sum.TryParse(args[0])) {
	Console.WriteLine("Incorrect sum!");
	return;
}

var exchanger = new Exchanger();

if (!exchanger.ReadRatesFromDirectory(args[1])) {
	Console.WriteLine("Something wrong with rates!");
	return;
}

Console.WriteLine($"Сумма в исходной валюте: {sum}");
foreach (var exchange in exchanger.Exchange(sum))
	Console.WriteLine($"Сумма в {exchange.CurrencyId}: {exchange}");
