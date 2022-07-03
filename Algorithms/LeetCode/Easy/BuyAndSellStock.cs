using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class BuyAndSellStock : TheoryData<int[], int>
    {
        public BuyAndSellStock()
        {
            Add(new int[] { 7, 1, 5, 3, 6, 4 }, 5);
        }

        [Theory]
        [ClassData(typeof(BuyAndSellStock))]
        public void ReturnMaximumProfit(int[] price, int profit)
        {
            var result = MaxProfit(price);

            Assert.Equal(profit, result);
        }

        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int minPrice = prices[0];
            foreach (int price in prices)
            {
                if (price < minPrice)
                {
                    minPrice = price;   
                }
                else if(profit < price - minPrice)
                {
                    profit = price- minPrice;
                }
            }
               
            return profit;
        }
    }
}
