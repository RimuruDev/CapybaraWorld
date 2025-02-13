using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.UI
{
    public class MainMenuRoot : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        
        private MainMenuView _mainMenu;
        private HeroMenuView _heroMenu;
        private SettingsMenuView _settingsMenu;

        public RectTransform RectTransform => _rectTransform;

        public void InitializeMainMenu(MainMenuView menu, MainMenuPresenter presenter)
        {
            _mainMenu = menu;
            _mainMenu.Initialize(this, presenter);
        }

        public void InitializeHeroMenu(HeroMenuView menu, HeroMenuPresenter presenter)
        {
            _heroMenu = menu;
            _heroMenu.Initialize(this, presenter);

            _heroMenu.InstantConceal(true);
        }

        public void InitializeSettingsMenu(SettingsMenuView menu, SettingsMenuPresenter presenter)
        {
            _settingsMenu = menu;
            _settingsMenu.Initialize(this, presenter);

            _settingsMenu.InstantConceal(true);
        }

        public void ShowMainMenu() => 
            _mainMenu.Reveal(enable: true).Forget();

        public void ShowHeroMenu() => 
            _heroMenu.Reveal(enable: true).Forget();

        public void ShowSettingsMenu() => 
            _settingsMenu.Reveal(enable: true).Forget();
    }
}