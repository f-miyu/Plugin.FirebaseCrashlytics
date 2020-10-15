using System;
namespace Plugin.FirebaseCrashlytics
{
    internal class StackFrame
    {
        public StackFrame(string className, string methodName, string fileName, int lineNumber)
        {
            ClassName = className;
            MethodName = methodName;
            FileName = fileName;
            LineNumber = lineNumber;
        }

        public string ClassName { get; }
        public string MethodName { get; }
        public string FileName { get; }
        public int LineNumber { get; }
    }
}
