using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.DataMapperInterfaces
{
    public interface IBaseMapper<T,U>
    {
        object CreateShapeDataObject(T orderTracker, List<string> listOfFields);
        object CreateShapeDataObject(U orderTracker, List<string> listOfFields);
    }
}
