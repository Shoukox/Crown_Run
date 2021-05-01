using System;
using System.Threading;

namespace gameserver
{
    class Program
    {
        public static bool isRunning = false;
        static void Main(string[] args)
        {
            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();
            Server.Start(10, 26950);
        }

        public static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SECOND} ticks per second.");
            DateTime nextLoop = DateTime.Now;

            while (isRunning)
            {
                while(nextLoop < DateTime.Now)
                {
                    GameLogic.Update();

                    nextLoop = nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if(nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
