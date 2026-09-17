namespace EduCore.Domain.Shared
{
    public sealed record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money first, Money second)
        {
            if (first.Currency != second.Currency)
                throw new InvalidOperationException("Cannot add money with different currencies.");
            return new Money(first.Amount + second.Amount, first.Currency);
        }
        public static Money operator -(Money first, Money second)
        {
            if (first.Currency != second.Currency)
                throw new InvalidOperationException("Cannot subtract money with different currencies.");
            return new Money(first.Amount - second.Amount, first.Currency);
        }
        public static bool operator >(Money first, Money second)
        {
            if (first.Currency != second.Currency) throw new InvalidOperationException("Currencies must match.");
            return first.Amount > second.Amount;
        }
        public static bool operator <(Money first, Money second)
        {
            if (first.Currency != second.Currency) throw new InvalidOperationException("Currencies must match.");
            return first.Amount < second.Amount;
        }
        public static bool operator >=(Money first, Money second)
            => first == second || first > second;
        public static bool operator <=(Money first, Money second)
            => first == second || first < second;
        public static Money Zero(Currency currency) => new Money(0, currency);
        public bool IsZero() => Amount == 0;
    }
}
