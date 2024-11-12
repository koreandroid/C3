using System.Collections.Generic;

public class Solution {

    public int solution(int[,] targets) {
        // 리스트로 변환하기
        List<int[]> targetList = new List<int[]>();
        for (var idx = 0; idx < targets.GetLength(0); idx++) {
            targetList.Add(new int[] { targets[idx, 0], targets[idx, 1] });
        }

        targetList.Sort((x, y) => x[0].CompareTo(y[0]));

        int endX = 0;
        int answer = 0;
        foreach (int[] target in targetList) {
            if (endX <= target[0]) {
                answer++;
                endX = target[1];
            } else {
                endX = target[1] < endX ? target[1] : endX;
            }
        }

        return answer;
    }
}
