using Microsoft.VisualStudio.Services.Agent.Util;
using System;
using System.Globalization;
using System.Threading;

namespace Microsoft.VisualStudio.Services.Agent
{
    public interface IExecutionContext
    {
        CancellationToken CancellationToken { get; }
        void LogMessage(LogLevel level, String format, params Object[] args);
    }
    
    public class ExecutionContext: IExecutionContext
    {
        public ExecutionContext(IHostContext hostContext) {
            CancellationToken = CancellationTokenSource.CreateLinkedTokenSource(hostContext.CancellationToken).Token;
        }
        
        public CancellationToken CancellationToken { get; private set;}
        
        public void LogMessage(LogLevel level, String format, params Object[] args)
        {
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", level, StringUtil.Format(format, args)));
        }
    }
}