namespace MultyThreading
{
    class FinderAverage : FinderBase
    {
        private long avg;
        public long Average => avg;
        public FinderAverage(int threadsCount, int[] arr): base (threadsCount, arr)
        {
            avg = arr[0];
            Process();
        }

        override protected void ThreadProc (object tIndxObj)
        {
            int tIdx = (int)tIndxObj;

            Index start = tIdx * (arr.Length / threads.Length);
            Index end = (tIdx + 1) * (arr.Length / threads.Length);
            Range range = tIdx == threads.Length - 1 ? start.. : start..end;

            var subArr = arr.AsSpan(range);
            long subSum = 0;
            for (int i = 0; i < subArr.Length; i++)
            {
                subSum += subArr[i];
            }
            long subAvg = subSum/subArr.Length;

            lock (sync)
            {
                avg = (subAvg + avg) / 2;
            }
        }
    }
}
