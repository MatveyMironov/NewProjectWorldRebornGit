using UnityEngine;

namespace HidableSystem
{
    public abstract class AHidableMB : MonoBehaviour, IHidable
    {
        public abstract void Hide();
        public abstract void Show();
    }
}