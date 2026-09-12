using EduCore.Domain.Abstractions;
using EduCore.Domain.Roles;
using EduCore.Domain.Users.Events;

namespace EduCore.Domain.Users
{
    public class User : Entity
    {
        private User() : base(Guid.Empty) 
        {
        }
        private User(Guid Id, FirstName firstName, LastName lastName, Email email, PasswordHash passwordHash,PhoneNumber phoneNumber, Genders gender, Address address, ImageUrl? imageUrl, Guid roleId) : base(Id)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = new FullName(firstName, lastName);
            Email = email;
            PasswordHash = passwordHash;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Address = address;
            ImageUrl = imageUrl;
            CreatedAt = DateTime.UtcNow;
            RoleId = roleId;
        }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public FullName FullName { get; private set; }
        public Email Email { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Genders Gender { get; private set; }
        public Address Address { get; private set; }
        public ImageUrl? ImageUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; } = null!;
        public static User Create(FirstName firstName, LastName lastName,
            Email email , PasswordHash passwordHash , PhoneNumber phoneNumber ,
            Genders gender ,Address address, 
            ImageUrl? imageUrl , Guid roleId)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email, passwordHash,phoneNumber, gender, address, imageUrl , roleId);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id, user.FullName, user.Email, user.PhoneNumber));
            return user;
        }
        public void UpdateUser(FirstName firstName , LastName lastName 
            ,Email email ,PhoneNumber phoneNumber,Genders gender ,
            Address address , ImageUrl? imageUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = new FullName(firstName, lastName);
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Address = address;
            ImageUrl = imageUrl;
            RaiseDomainEvent(new UserUpdatedDomainEvent(Id, FullName, Email, PhoneNumber));
        }
        public void UpdatePasswords(PasswordHash newpasswordHash)
        {
            if(PasswordHash == newpasswordHash)
                return;
            PasswordHash = newpasswordHash;
            RaiseDomainEvent(new UserUpdatedPasswordDomainEvent(Id, FullName, Email, PhoneNumber));

        }
        


    }
}
