using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace Adapters
{
    public class MyService : IMyService
    {
        private List<string> receivedData = new List<string>();

        public async Task DoStuffAsync(string data)
        {
            await Task.Delay(100);
            this.receivedData.Add(data);
            Console.WriteLine($"[{this.GetHashCode()}] {DateTime.UtcNow} - MyService.DoStuffAsync called with data = {data} (received {this.receivedData.Count} messages so far)");
        }
    }
}
