using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business
{
    public interface IFooService
    {
        ILogger Logger { get; set; }
        IPlayerFactory PlayerFactory { get; set; }
        ISquareFactory SquareFactory { get; set; }

        void DoSomething();
    }
}