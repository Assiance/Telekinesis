using Assets.Scripts.Actions.Attacks;

namespace Assets.Scripts.General
{
    public interface IHittable
    {
        void Hit(IAttack hitter);
    }
}