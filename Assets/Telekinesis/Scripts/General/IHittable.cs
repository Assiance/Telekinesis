using Assets.Telekinesis.Scripts.Actions.Attacks;

namespace Assets.Telekinesis.Scripts.General
{
    public interface IHittable
    {
        void Hit(IAttack hitter);
    }
}