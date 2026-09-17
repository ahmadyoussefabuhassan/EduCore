using System;

namespace EduCore.Domain.Certificates
{
    public sealed record CertificateUrl
    {
        public string Value { get; init; }
        public CertificateUrl(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Certificate URL cannot be empty.", nameof(value));
            if(!Uri.IsWellFormedUriString(value , UriKind.Absolute))
                throw new ArgumentException("Invalid URL format.", nameof(value));
            Value = value;

        }
    }
}
