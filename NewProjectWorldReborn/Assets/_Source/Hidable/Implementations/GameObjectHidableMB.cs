namespace HidableSystem.Implementations
{
    public class GameObjectHidableMB : AHidableMB
    {
        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }
    }
}