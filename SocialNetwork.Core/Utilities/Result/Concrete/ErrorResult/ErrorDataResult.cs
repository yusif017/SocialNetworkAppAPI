using SocialNetwork.Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Utilities.Result.Concrete.ErrorResult
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }
    }
}
