using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace RollBall
{
    public class BinaryData<T> : IData<T>
    {
        private static BinaryFormatter formatter;
        public BinaryData()
        {
            formatter = new BinaryFormatter();
        }
        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path)) return;
            if (!typeof(T).IsSerializable) return;
            using (var fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, data);
            }
        }
        public T Load(string path)
        {
            T result;
            if (!File.Exists(path)) return default(T);
            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
