using System;

namespace ConsumersTest.Services.DTO
{
    public class ConsumerDTO
    {
        public int ConsumerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
