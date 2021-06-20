using Project.Domain.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Commands
{
    public class CreateProjectCommand : CommandBase<ProjectDto>
    {
        public CreateProjectCommand(string name, string email, string address, int age, string phoneNumber)
        {
            Name = name;
            Email = email;
            Address = address;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        [JsonProperty("name")]
        [JsonRequired]
        [MaxLength(255)]
        public string Name { get; }
        [JsonProperty("email")]
        [JsonRequired]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; }
        [JsonProperty("address")]
        [JsonRequired]
        [MaxLength(255)]
        public string Address { get; }
        [JsonProperty("age")]
        [JsonRequired]
        public int Age { get; }
        [JsonProperty("phone_number")]
        [JsonRequired]
        [Phone]
        public string PhoneNumber { get; }
    }
}