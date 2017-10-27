using Festo.Common.DataMapperInterfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Utility.DataMappers
{
    public class BaseMapper<T,U> : IBaseMapper<T,U> where T : class where U : class
    {
        public object CreateShapeDataObject(T orderTracker, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(orderTracker, listOfFields);
        }

        public object CreateShapeDataObject(U orderTrackerDTO, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return orderTrackerDTO;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = orderTrackerDTO.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(orderTrackerDTO, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }

        }
    }
}
