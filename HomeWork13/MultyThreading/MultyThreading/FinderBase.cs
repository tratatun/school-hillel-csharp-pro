namespace MultyThreading
{
    abstract class FinderBase
    {
        protected int[] arr;
        protected Thread[] threads;
        protected readonly object sync = new object();
        public FinderBase(int threadsCount, int[] arr)
        {
            this.arr = arr;
            threads = new Thread[threadsCount];
        }

        public void Process()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ThreadProc);
                threads[i].Start(i);
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }

        abstract protected void ThreadProc(object tIndxObj);
    }
}
