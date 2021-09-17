using System;
using System.IO;

namespace ReservationSystem.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Stream GetResponseStream()
        {
            throw new NotImplementedException();
        }
    }
}
