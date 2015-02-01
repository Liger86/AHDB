using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AHDB.UI.Common
{
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }
            if (object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            
            IFormatter myFormatter = new BinaryFormatter();
            Stream myStream = new MemoryStream();
            using (myStream)
            {
                myFormatter.Serialize(myStream, source);
                myStream.Seek(0, SeekOrigin.Begin);
                return (T)myFormatter.Deserialize(myStream);
            }
        }
    }
}
