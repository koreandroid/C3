public class Solution {

    public int solution(int n, int a, int b) {
        int confrontDigit = (a - 1) ^ (b - 1);

        int answer = 0;
        do
        {
            confrontDigit >>= 1;
            answer++;
        } while (0 < confrontDigit);

        return answer;
    }
}
