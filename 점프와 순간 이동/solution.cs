class Solution {

    public int solution(int n) {
        int answer = 0;
        while (n != 1)
        {
            answer += n % 2;
            n /= 2;
        }

        answer++;

        return answer;
    }
}
