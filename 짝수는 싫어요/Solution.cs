using System.Collections.Generic;

public class Solution {

    public int[] solution(int n) {
        List<int> oddNumberList = new List<int>();
        for (int num = 1; num <= n; num += 2) {
            oddNumberList.Add(num);
        }

        return oddNumberList.ToArray();
    }
}
