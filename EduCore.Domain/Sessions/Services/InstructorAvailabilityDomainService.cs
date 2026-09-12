using EduCore.Domain.Instructors;

namespace EduCore.Domain.Sessions.Services
{
    public sealed class InstructorAvailabilityDomainService
    {
        public bool ValidateInstructorAvailability(Session Newsession , IEnumerable<Session> sessions)
        {
            foreach(var session in sessions)
            {
                if(session.Date.Date == Newsession.Date.Date)
                {
                    bool Overlap = Newsession.TimeRange.StartTime < session.TimeRange.EndTime
                        && Newsession.TimeRange.EndTime > session.TimeRange.StartTime;
                    if (Overlap)
                        return false;

                }
            }
            return true;
        }
    }
}
