using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Core.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult   // out keyword allows us to give covariant type as T like IEnumarable<Category>
    {
        public T Data { get; }
    }
}
