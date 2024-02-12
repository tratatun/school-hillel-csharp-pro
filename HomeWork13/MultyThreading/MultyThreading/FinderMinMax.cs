namespace MultyThreading
{
    class FinderMinMax: FinderBase
    {
        private int min;
        private int max;
        public int Min => min;
        public int Max => max;
        public FinderMinMax(int threadsCount, int[] arr) : base(threadsCount, arr)
        {
            min = arr[0];
            max = arr[0];
            Process();
        }

        override protected void ThreadProc (object tIndxObj)
        {
            int tIdx = (int)tIndxObj;

            Index start = tIdx * (arr.Length / threads.Length);
            Index end = (tIdx + 1) * (arr.Length / threads.Length);
            Range range = tIdx == threads.Length - 1 ? start.. : start..end;

            var subArr = arr.AsSpan(range);
            int subMin = arr[0];
            int subMax = arr[0];
            for (int i = 0; i < subArr.Length; i++)
            {
                if (subArr[i] < subMin)
                {
                    subMin = subArr[i];
                }
                if (subArr[i] > subMax)
                {
                    subMax = subArr[i];
                }
            }

            lock (sync)
            {
                if (subMin < min)
                {
                    min = subMin;
                }
                if (subMax > max)
                { 
                    max = subMax;
                }
            }
        }
    }
}
