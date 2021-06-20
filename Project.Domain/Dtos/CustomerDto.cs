using System;
using Newtonsoft.Json;

namespace Project.Domain.Dtos
{
    public class ProjectDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}