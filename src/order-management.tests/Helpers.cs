using System;
using Newtonsoft.Json;
using Xunit;

namespace order_management.tests
{
    public static class Helpers
    {
        public static void AssertWith(this object obj, object anotherObj)
        {
            if (ReferenceEquals(obj, anotherObj))
            {
                return;
            }

            if (obj == null || anotherObj == null)
            {
                throw new Exception("One of those objects is null");
            }

            if (obj.GetType() != anotherObj.GetType())
            {
                throw new Exception("Object types not equal");
            }

            var objJson = JsonConvert.SerializeObject(obj);
            var anotherObjJson = JsonConvert.SerializeObject(anotherObj);
            
            Assert.Equal(objJson, anotherObjJson);
        }
    }
}