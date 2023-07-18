using System;

namespace BackendDataService.Models.Dto
{
    public class NewUserDto
    {
        //[JsonProperty("name")]
        public string Name {  get; set; }

        //[JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}
