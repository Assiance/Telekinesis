using Assets.Telekinesis.Scripts.Regular.Actions.Attacks;

namespace Assets.Telekinesis.Scripts.Regular.General
{
    public interface IHittable
    {
        void Hit(IAttack hitter);
    }
}