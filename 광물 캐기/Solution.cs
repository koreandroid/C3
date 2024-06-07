using System.Collections.Generic;
using System.Linq;

public class Solution {

    private const int M = 3;        // Number of types of minerals.

    private int[][] fatigue = {
        new int[M] {1, 1, 1},
        new int[M] {5, 1, 1},
        new int[M] {25, 5, 1}
    };

    private Dictionary<string, int> mineralWeightMap = new Dictionary<string, int> {
        {"diamond", 100},
        {"iron", 10},
        {"stone", 1}
    };

    public int solution(int[] picks, string[] minerals) {
        List<int> workUnits = new List<int>();

        int lastIndex = min(5 * picks.Sum(), minerals.Length) - 1;
        for (int i = 0; i <= lastIndex;) {
            int j = min(i + 4, lastIndex);
            int workUnit = 0;
            for (int idx = i; idx <= j; idx++) {
                workUnit += mineralWeightMap[minerals[idx]];
            }
            workUnits.Add(workUnit);

            i = j + 1;
        }

        workUnits.Sort();
        workUnits.Reverse();

        int answer = 0;
        int pickIndex = 0;
        foreach (int workUnit in workUnits) {
            while (picks[pickIndex] <= 0)
            {
                pickIndex++;
            }

            int[] mineralCounts = new int[M] {
                workUnit / 100,
                (workUnit / 10) % 10,
                workUnit % 10
            };
            for (int i = 0; i < M; i++) {
                answer += fatigue[pickIndex][i] * mineralCounts[i];
            }

            picks[pickIndex]--;
        }

        return answer;
    }

    private int min(int a, int b) {
        return (a < b) ? a : b;
    }
}
