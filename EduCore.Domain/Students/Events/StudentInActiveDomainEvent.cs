using EduCore.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Students.Events
{
    public sealed record StudentInActiveDomainEvent(Guid Id, StudentStatus Status) : IDomainEvent;
}
