namespace AMVC.Core
{
    public interface IPoolItem
    {
        void Initialize(Application app);
        void Remove();
    }
}