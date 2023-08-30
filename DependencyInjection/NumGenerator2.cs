using System;
using static DependencyInjection.NumGenerator;

namespace DependencyInjection
{
    public class NumGenerator2 : INumGenerator2
    {
        private readonly INumGenerator numGenerator;
        public int RandomValue { get; }


        public NumGenerator2(INumGenerator numGenerator)
        {
            RandomValue = new Random().Next(1000);
            this.numGenerator = numGenerator;
        }

        public int GetNumGeneratorRandomNumber()
        {
            return numGenerator.RandomValue;
        }

    }

    public interface INumGenerator2
    {
        public int RandomValue { get;  }

        public int GetNumGeneratorRandomNumber();
    }
}
