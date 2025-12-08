using HW22_23;

namespace HW24_25
{
    public interface IDamagable : ITransformPosition
    {
        void TakeDamage(int damage);
    }
}
