using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Email{ get; set; }
        public long?  Birthday{ get; set; }
        public int?  Gender{ get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int Status{ get; set; }

        public Guid? ReferenceId { get; set; }
        public User Reference { get; set; }
        public string Bio{ get; set; }
        public bool CanReserve{ get; set; }

        
        public string Salt { get; set; }

        public Guid? ProfileImageId { get; set; }
        public Document ProfileImage { get; set; }

        public List<Device> Device{ get; set; }
        public List<Notification> Notification { get; set; }
        public List<UserRole> UserRole { get; set; }
        public List<WorkTime> WorkTime { get; set; }
        public virtual List<BarginUsers> BarginUsers { get; set; }
        public List<GroupGameUsers> GroupGameUsers { get; set; }
        public List<EventUsers> EventUsers { get; set; }
        public List<Transaction> Transaction { get; set; }
        public List<UserTransactionList> Partner{ get; set; }
        public List<Transaction> OtherTransaction { get; set; }
        public List<UserTransactionList> UserTransactionList { get; set; }
        public List<Team> MyTeam { get; set; }
        public List<TeamMember> JoindTeam { get; set; }
        public List<Message> MyMessage { get; set; }
        public List<Message> OtherMessage { get; set; }
        public List<TableReserve> TableReserve { get; set; }
        public List<ProductRate> ProductRate { get; set; }
        public List<Bill> Bill { get; set; }
        public List<Bill> Promoted { get; set; }
        public List<RegisteredWorkTime> RegisteredWorkTime { get; set; }
        public List<UserDiscount> Discount { get; set; }
        public List<LastDiscount> LastDiscount { get; set; }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter) =>
            Password.Equals(encrypter.GetHash(password, Salt));
    }
}
