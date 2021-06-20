using System;

namespace Project.Domain.Common
{
    public class OurException : Exception
    {
        public OurException()
        {

        }

        public OurException(string name)
            : base(string.Format("Invalid Student Name: {0}", name))
        {

        }

    }
}
