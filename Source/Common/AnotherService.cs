using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AnotherService : IAnotherService
    {
        private List<string> receivedData = new List<string>();

        public void DoStuff(string data)
        {
            this.receivedData.Add(data);
            Console.WriteLine($"[{this.GetHashCode()}] {DateTime.UtcNow} - AnotherService.DoStuff called with data = {data} (received {this.receivedData.Count} messages so far)");
        }
    }
}
