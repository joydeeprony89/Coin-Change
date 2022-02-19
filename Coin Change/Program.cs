using System;

namespace Coin_Change
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] coins = new int[] { 2  }; // 1, 3, 4, 5 // 1, 2, 5
      int amount = 3; // 7 // 11
      Program p = new Program();
      int result = p.CoinChange(coins, amount);
      Console.WriteLine(result);
    }

    public int CoinChange(int[] coins, int amount)
    {
      if (amount <= 0) return 0;
      long[] dp = new long[amount + 1];
      dp[0] = 0;

      for (int a = 1; a < amount + 1; a++)
      {
        dp[a] = int.MaxValue;
      }

      for (int a = 1; a < amount + 1; a++)
      {
        foreach (int c in coins)
        {
          int diff = a - c;
          if (diff >= 0)
          {
            dp[a] = Math.Min(dp[a], 1 + dp[diff]);
          }
        }
      }

      if (dp[amount] == int.MaxValue) return -1;
      else return (int)dp[amount];
    }
  }
}
