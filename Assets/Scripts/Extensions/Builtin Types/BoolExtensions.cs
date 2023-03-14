using System.Collections.Generic;
using System.Linq;

namespace Dynamic
{
	public static class BoolExtensions
	{
		public static bool IsAllTrue(this IEnumerable<bool> bools) => bools.All(x => x == true);
	}
}