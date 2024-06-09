public class Solution {

    public int solution(int n, int a, int b) {
        int confrontingDigit = (a - 1) ^ (b - 1);

        int answer = 0;
        do
        {
            answer++;
        } while (confrontingDigit >> answer != 0);

        return answer;
    }
}
