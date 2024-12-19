using Sprint0.Interfaces.Player;

namespace Sprint0.Interfaces
{
    public interface IItemBlock : IGameObject
    {
        void MakeItem(IPlayer player);
    }
}
