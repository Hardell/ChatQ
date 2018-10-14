﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreSpa.Core.Entities
{
    public class Room : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public ChatRoomPhoto Photo { get; set; }

        public virtual ICollection<RoomEdge> AdjacentRooms { get; set; } = new List<RoomEdge>();
    }
}