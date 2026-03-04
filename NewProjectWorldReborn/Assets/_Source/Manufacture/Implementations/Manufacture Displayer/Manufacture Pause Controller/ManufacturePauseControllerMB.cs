using UnityEngine;
using UnityEngine.UI;

namespace ManufactureSystem.Implementations
{
    public class ManufacturePauseControllerMB : MonoBehaviour, IManufacturePauseController
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Image pauseImage;
        [SerializeField] private Sprite unpausedSprite;
        [SerializeField] private Sprite pausedSprite;

        private void Awake()
        {
            pauseButton.onClick.AddListener(SwitchManufacturePause);
        }

        private IManufacture _controledManufacture;

        public void ControlManufacture(IManufacture manufacture)
        {
            ReleaseManufacture();

            manufacture.OnPaused += DisplayManufacturePauseState;
            manufacture.OnResumed += DisplayManufacturePauseState;
            DisplayPauseState(manufacture.IsPaused);

            _controledManufacture = manufacture;
        }

        public void ReleaseManufacture()
        {
            if (_controledManufacture == null) return;

            _controledManufacture.OnPaused -= DisplayManufacturePauseState;
            _controledManufacture.OnResumed -= DisplayManufacturePauseState;
            DisplayPauseState(true);

            _controledManufacture = null;
        }

        private void SwitchManufacturePause()
        {
            if (_controledManufacture == null) return;

            if (_controledManufacture.TryPause()) return;

            _controledManufacture.TryResume();
        }

        private void DisplayManufacturePauseState()
        {
            DisplayPauseState(_controledManufacture.IsPaused);
        }

        private void DisplayPauseState(bool isPaused)
        {
            pauseImage.sprite = isPaused ? pausedSprite : unpausedSprite;
        }
    }
}