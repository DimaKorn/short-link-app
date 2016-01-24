using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Common
{
    public struct RepositoryResult<T>
    {
        public RepositoryResult(T data,bool isSuccess=true,string message= null)
        {
            this.Data = data;
            this.IsSuccess = isSuccess;
            this.Message = message;
        }
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
