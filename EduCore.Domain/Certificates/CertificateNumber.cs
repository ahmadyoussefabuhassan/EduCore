namespace EduCore.Domain.Certificates
{
    public sealed record CertificateNumber
    {
        public string Value { get; private set; }
        private CertificateNumber(string value)
            => Value = value;
        public static CertificateNumber Generate()
        {
            var year = DateTime.UtcNow.Year;
            var uniqueCode = DateTime.UtcNow.Ticks.ToString();
            uniqueCode = uniqueCode.Substring(uniqueCode.Length - 8);

            return new CertificateNumber($"CERT-{year}-{uniqueCode}");
        }
    }
}
