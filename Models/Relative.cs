﻿using OldHouse.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldHouse.Models
{
    public class Relative
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Maximum length for first name is {1}")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(256, ErrorMessage = "Maximum length for phone number is {1}")]
        public string Phone { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Maximum length for relative relation number is {1}")]
        public string Relation { get; set; }

		[Range(0, 1000000000)]
		public int PatientId { get; set; }

		[ForeignKey("PatientId")]
		public Patient Patient { get; set; }
	}
}
