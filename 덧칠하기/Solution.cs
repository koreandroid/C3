public class Solution {

    public int solution(int n, int m, int[] section) {
        int prevBoundaryIndex = 0;
        int answer = 0;
        foreach (var index in section) {
            if (index > prevBoundaryIndex) {
                answer++;
                prevBoundaryIndex = index + m - 1;
            }
        }

        return answer;
    }
}
