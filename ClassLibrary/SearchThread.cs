using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SearchThread
    {
        public event EventHandler<int> SearchIndex;

        public async Task DoWork()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    OnUpdateSearchIndex(i);
                }
            });
        }

        protected virtual void OnUpdateSearchIndex(int e)
        {
            SearchIndex?.Invoke(this, e);
        }
    }
}