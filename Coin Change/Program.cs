using System;

namespace Coin_Change
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] coins = new int[] { 1, 3, 4, 5 }; // 1, 3, 4, 5 // 1, 2,  // 2
      int amount = 7; // 11 // 3
      Program p = new Program();
      int result = p.CoinChange(coins, amount);
      Console.WriteLine(result);
    }

    public int CoinChange(int[] coins, int amount)
    {
      if (amount <= 0) return 0;
      // we need to create an array and for each index starting from 1 to the amount, we will be calculating the min no of coins req to get the amount
      long[] dp = new long[amount + 1];
      // To get 0 amount we need 0 coins
      dp[0] = 0;

      // Set all except 0 to infinity
      for (int a = 1; a < amount + 1; a++)
      {
        dp[a] = int.MaxValue;
      }

      // now loop through for each coins
      for (int a = 1; a < amount + 1; a++)
      {
        // will be comparing agaist the input coins to make the amount
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
