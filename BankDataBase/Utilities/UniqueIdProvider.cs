namespace BankDataBase.Utilities
{
	public static class UniqueIdProvider
	{
		public static uint GetNewUintId(List<uint> numbers)
		{
			if (numbers.Count == 0)
				return 1;

			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] != i + 1)
					return numbers[i] + 1;
			}

			return numbers.Last() + 1;
		}
	}
}