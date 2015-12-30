
namespace MagicGameTracker.Logic
{
    namespace MagicEnums
    {
        public enum ManaColor
        {
            Black, White, Red, Blue, Green, None
        }

        public enum DeckFormats
        {
            Block, Standard, Modern, Limited /*Version 3.3.1.0*/, Commander, Legacy, Vintage, Pauper, Singleton, Custom
        }

        public enum DatabaseCondition
        {
            Intact, Repaired, Failed
        }
    }
}
