using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreSpa.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            this.TimeAccumulated = new DateTime(0);
        }

        public bool IsEnabled { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [Phone]
        public string Mobile { get; set; }

        public ApplicationUserPhoto ProfilePhoto { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TimeAccumulated;

        [NotMapped]
        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

    }
}
