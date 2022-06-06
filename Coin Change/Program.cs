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
      int newLength = amount + 1;
      long[] dp = new long[newLength];

      dp[0] = 0;
      // we are assigning max values to each element to calculat the min no of coins
      for (int i = 1; i < newLength; i++)
      {
        dp[i] = int.MaxValue;
      }

      // for each , from 1 to amount, we will be calculating the no of coins required to make that amount
      // outer loop for each amount
      // inner loop for each coins given to us
      // will take the amount from outer loop and for each amount will consider all the given coins.
      // when we select a coin and after using that coin if we could not get the amount we will not consider that coin
      // if the selected coin can make the amount, e.g - amount 1, and we have coins[1,2]
      // aviously to make 1 we need 1 rupee coin only using 2 rs coin we can not get amount 1.
      // now to make amount 1 using 1 rs coin, we need min coins ? 1 + coins need to make amount 0 = 1+dp[0], where 0 we are getting by substracting amount value from coin, diff = 1 - 1
      for (int i = 1; i < newLength; i++)
      {
        foreach (int coin in coins)
        {
          int diff = i - coin;
          if (diff >= 0)
          {
            dp[i] = Math.Min(dp[i], 1 + dp[diff]);
          }
        }
      }

      return dp[amount] == int.MaxValue ? -1 : (int)dp[amount];
    }
  }
}
