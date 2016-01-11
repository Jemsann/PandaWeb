using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PandaWeb.Models
{
	public class Meeting
	{
		[Display(Name ="ID")]
		public int Id { get; set; }

		[Display(Name ="Mötesdatum")]
		public string MeetingDate { get; set; }
	}
}