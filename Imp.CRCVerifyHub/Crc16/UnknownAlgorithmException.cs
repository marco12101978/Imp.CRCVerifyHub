using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Imp.CRCVerifyHub.Crc16
{
    [Serializable]
    public class UnknownAlgorithmException : Exception
    {
        public Crc16.Crc16Algorithm Algorithm { get; set; }

        public UnknownAlgorithmException()
        {
        }

        public UnknownAlgorithmException(Crc16.Crc16Algorithm algorithm)
        {
            this.Algorithm = algorithm;
        }

        public UnknownAlgorithmException(string message) : base(message)
        {
        }

        public UnknownAlgorithmException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownAlgorithmException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
