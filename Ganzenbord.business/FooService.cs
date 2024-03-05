using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business
{
    public class FooService : IFooService
    {
        public ILogger Logger { get; set; }

        public FooService(ILogger logger, ISquareFactory squareFactory, IPlayerFactory playerFactory)
        {
            Logger = logger;
            SquareFactory = squareFactory;
            PlayerFactory = playerFactory;
        }

        public ISquareFactory SquareFactory { get; set; }

        public IPlayerFactory PlayerFactory { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Pretend I am doing useful");
        }


    }
}
