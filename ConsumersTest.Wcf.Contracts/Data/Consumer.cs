using System;
using System.Runtime.Serialization;

namespace ConsumersTest.Wcf.Contracts.Data
{
    [DataContract]
    public class Consumer
    {
        [DataMember]
        public int ConsumerId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}
