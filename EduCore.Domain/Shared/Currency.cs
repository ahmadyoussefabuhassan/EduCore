namespace EduCore.Domain.Shared
{
    public sealed record Currency
    {
        public string Code { get; init; }
        private Currency(string code) => Code = code;
        public static readonly Currency NONE = new Currency("");
        public static readonly Currency USD = new Currency("USD");
        public static readonly Currency SYR = new Currency("SYR");
        public static readonly Currency EUR = new Currency("EUR");
        public readonly static IReadOnlyCollection<Currency> _currencies = new List<Currency>
        {
            USD,
            SYR,
            EUR
        };
        public static Currency FromCode(string code)
        {
            var currency = _currencies.FirstOrDefault(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
            if (currency == null)
                throw new ArgumentException($"Currency code '{code}' is not supported.");
            return currency;
        }



    }
}
