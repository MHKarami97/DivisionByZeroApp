using System;
using MvvmCross.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace MyApp
{
    public class DebugTrace : IMvxLog
    {
        public bool IsLogLevelEnabled(MvxLogLevel logLevel) => true;

        public bool Log(MvxLogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
        {
            var properties = new Dictionary<string, string> {
                { "messageFunc", messageFunc() }
            };

            Debug.WriteLine(logLevel + ":" + messageFunc());
            Crashes.TrackError(exception, properties);
            return true;
        }
    }
}