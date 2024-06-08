using System.Collections.Generic;

public class Solution {

    public int solution(string[,] arr) {
        List<BookTime> bookTimes = new List<BookTime>();

        int arrLen = arr.GetLength(0);
        for (int idx = 0; idx < arrLen; idx++) {
            bookTimes.Add(new BookTime(arr[idx, 0], arr[idx, 1]));
        }

        bookTimes.Sort((x, y) => x.startTime.CompareTo(y.startTime));

        List<string> endTimes = new List<string> { bookTimes[0].endTime };
        int answer = 1;
        for (int idx = 1; idx < arrLen; idx++) {
            int jdx;
            if (bookTimes[idx].startTime.CompareTo(findAvailableTime(endTimes[answer - 1])) < 0) {
                endTimes.Add(null);
                jdx = answer++;
            } else {
                jdx = answer - 1;
            }

            while (jdx != 0 && endTimes[jdx - 1].CompareTo(bookTimes[idx].endTime) < 0)     // Locating the right place to be inserted.
            {
                swap(endTimes, jdx - 1, jdx);
                jdx--;
            }
            endTimes[jdx] = bookTimes[idx].endTime;
        }

        return answer;
    }

    private string findAvailableTime(string endTime) {
        if (endTime[3] < '5') {
            return endTime.Substring(0, 3) + new string((char) (endTime[3] + 1), 1) + endTime[4].ToString();
        } else if (endTime[1] < '9') {
            return endTime[0].ToString() + new string((char) (endTime[1] + 1), 1) + ":0" +
                endTime[4].ToString();
        } else {
            return new string((char) (endTime[0] + 1), 1) + "0:0" + endTime[4].ToString();
        }
    }

    private void swap<T>(List<T> list, int i, int j) {
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    private struct BookTime {
        public BookTime(string s, string e) {
            startTime = s;
            endTime = e;
        }

        public string startTime
        { get; }
        public string endTime
        { get; }
    }
}
