using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace derrickcodingexercise.Models
{
	[XmlRoot("Poll"), XmlType("Poll")]
	public class Poll
	{
		public int Male { get; set; }
		public int Female { get; set; }

		public Poll()
		{
			Male = 0;
			Female = 0;
		}
	}
}