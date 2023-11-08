using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger42915.DTO
{
    public class FoodCollectionRequestDTO
    {
        public int RequestID { get; set; }

        [Required(ErrorMessage = "Restaurant Name is required")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Max Preservation Time is required")]
        [DataType(DataType.DateTime)]
        public DateTime MaxPreservationTime { get; set; }

        public bool IsAssigned { get; set; }
        public bool IsCompleted { get; set; }
    }
}