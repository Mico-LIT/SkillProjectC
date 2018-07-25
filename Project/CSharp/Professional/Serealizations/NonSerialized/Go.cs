using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CSharp.Professional.Serealizations.NonSerialized
{
    [Serializable]
    class ShoppingCartItem : IDeserializationCallback
    {
        public int productID;
        public decimal price;
        public int quantity;
        [NonSerialized]
        public decimal total;

        // Поле добавленное в класс в новой версии. Инициализируется значением по умолчанию.
        [OptionalField]
        public bool taxable;

        public ShoppingCartItem(int _productID,decimal _price,int _quantity)
        {
            this.productID = _productID;
            this.price = _price;
            this.quantity = _quantity;
            //total = price * quantity;
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            // Поле десериализации подсчитываем общую стоймость
            total = price * quantity;
        }
    }
    class Go
    {
        public Go()
        {
            var item = new ShoppingCartItem(2012154, 50000, 5);

            #region Сериализация
            FileStream filestream = new FileStream("SerializedCar.txt",FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(filestream, item);
            filestream.Close();
            #endregion

            #region Десериализация
            filestream = new FileStream("SerializedCar.txt", FileMode.Open);
            item = (ShoppingCartItem)formatter.Deserialize(filestream);

            filestream.Close();

            Console.WriteLine($"{item.total}");
            #endregion

            Console.ReadLine();

        }
    }
}
