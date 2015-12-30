
namespace MagicGameTracker.Model
{
    public class LifeStatus
        {
            public int lifeChange { get; set; }
            public int currentLife { get; set; }

            public LifeStatus(int change, int previousLife)
            {
                this.lifeChange = change;
                this.currentLife = previousLife + change;
            }
        }
}
