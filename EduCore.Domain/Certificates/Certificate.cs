using EduCore.Domain.Abstractions;
using EduCore.Domain.Certificates.Events;
using EduCore.Domain.Enrollments;

namespace EduCore.Domain.Certificates
{
    public sealed class Certificate : Entity
    {
        private Certificate(Guid Id, CertificateNumber certificateNumber, CertificateUrl certificateUrl, Guid enrollmentId) : base(Id)
        {
            CertificateNumber = certificateNumber;
            IssueDate = DateTime.UtcNow;
            CertificateUrl = certificateUrl;
            EnrollmentId = enrollmentId;
        }
        public CertificateNumber CertificateNumber { get; private set; }
        public DateTime IssueDate { get; private set; }
        public CertificateUrl CertificateUrl { get; private set; }
        public Guid EnrollmentId { get; private set; }
        public Enrollment Enrollment { get; private set; } = null!;
        public static Certificate Create(CertificateNumber certificateNumber, CertificateUrl certificateUrl, Guid enrollmentId)
        {
            var certificate = new Certificate(Guid.NewGuid(), certificateNumber, certificateUrl, enrollmentId);
            certificate.RaiseDomainEvent(new CertificateCreatedDomainEvent(certificate.Id));
            return certificate;
        }

    }
}
