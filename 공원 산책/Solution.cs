public class Solution {

    private int[] di = new int[91];
    private int[] dj = new int[91];

    public int[] solution(string[] park, string[] routes) {
        setDirectionalMoveArrays();

        Position pos = getStartingPosition(park);
        foreach (string route in routes) {
            if (isRouteAvailable(park, pos.i, pos.j, route)) {
                pos.i += (route[2] - '0') * di[route[0]];
                pos.j += (route[2] - '0') * dj[route[0]];
            }
        }

        return new int[] {pos.i, pos.j};
    }

    private void setDirectionalMoveArrays() {
        di['N'] = -1; dj['N'] = 0;
        di['S'] = 1; dj['S'] = 0;
        di['W'] = 0; dj['W'] = -1;
        di['E'] = 0; dj['E'] = 1;
    }

    private Position getStartingPosition(string[] park) {
        int parkWidth = park[0].Length;
        for (int idx = 0; idx < park.Length; idx++) {
            for (int jdx = 0; jdx < parkWidth; jdx++) {
                if (park[idx][jdx] == 'S') {
                    return new Position(idx, jdx);
                }
            }
        }

        return new Position(-1, -1);
    }

    private bool isRouteAvailable(string[] park, int i, int j, string route) {
        int parkWidth = park[0].Length;

        char dir = route[0];
        int num = route[2] - '0';
        if (i + num * di[dir] < 0 || park.Length - 1 < i + num * di[dir] ||
           j + num * dj[dir] < 0 || parkWidth - 1 < j + num * dj[dir]) {
            return false;
        }

        for (int move = 1; move <= num; move++) {
            i += di[dir];
            j += dj[dir];

            if (park[i][j] == 'X') return false;
        }

        return true;
    }

    private struct Position {
        public Position(int i, int j) {
            this.i = i;
            this.j = j;
        }

        public int i
        { get; set; }
        public int j
        { get; set; }
    }
}
