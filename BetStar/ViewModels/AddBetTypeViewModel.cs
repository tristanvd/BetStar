using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetStar.ViewModels
{
	public class AddBetTypeViewModel
	{
		public string BetType { get; set; }
		public List<int> BetTypeIds { get; set; }
		public int BetTypeId { get; set; }
		public string BetChoice { get; set; }
	}
}
