using System;

namespace ITWEB_Mandatory5.Library
{
    public class Time : ITime
    {
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
