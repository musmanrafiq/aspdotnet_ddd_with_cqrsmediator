using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Project.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Queries
{
    public class GetProjectQuery : QueryBase<ProjectDto>
    {
        public GetProjectQuery()
        {
        }

        [JsonConstructor]
        public GetProjectQuery(Guid projectId)
        {
            ProjectId = projectId;
        }

        [JsonProperty("id")]
        [Required]
        public Guid ProjectId { get; set; }
    }
}