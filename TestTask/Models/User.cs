using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestTask.Models
{
    
    public enum Gender {
        [EnumMember(Value = "Male")]
        Male,
        [EnumMember(Value = "Female")]
        Female }
    public class User
    {
        public bool IsNew { get; set; }
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

    }

}