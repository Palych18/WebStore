using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Concurrent;
using System.Xml;

namespace WebStore.Logger
{
    public class Log4NetLogger : ILogger
    {
        public Log4NetLogger(string Category, XmlElement Configuration)
        {

        }
    }
}
