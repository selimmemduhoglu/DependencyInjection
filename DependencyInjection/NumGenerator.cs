using Microsoft.AspNetCore.Components.Forms;
using System;
using static DependencyInjection.NumGenerator;

namespace DependencyInjection
{
    public class NumGenerator : INumGenerator
    {
        public int RandomValue { get; } //sadece get var set i yok (yani sadece okuyabiliyor.)
        public NumGenerator() //BUranıon amacı singleton,scope,trancienti denemek iin bu class ın instance ı oluştuğunda başka bir yerde işlem yapanilmek için
        {
            RandomValue = new Random().Next(1000);
        }
        //public int GetRandomNumber() //Bu method sayfa yenilendiğiğnde çalışıyordu örneğin ilk halinde
        //{
        //    return new Random().Next(1000);
        //}



        public interface INumGenerator
        {
            //int GetRandomNumber();
            public int RandomValue { get; } //Bu şekilde field ı sadece implemente edecek şekilde bıraktık.
        }
    }
}
