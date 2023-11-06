using UnityEngine;

namespace Core.UI
{
    [CreateAssetMenu(fileName = "UI Collection", menuName = "Collections/UI Collection")]
    public class UICollection : ScriptableObject
    {
        [Header("")]
        [SerializeField] private MainMenu _mainMenuPrefab;
        [SerializeField] private GameOverMenu _gameOverMenuPrefab;
        [SerializeField] private LoadingScreen _loadingScreenCanvasPrefab;

        public MainMenu MainMenuPrefab => _mainMenuPrefab;
        public GameOverMenu GameOverMenuPrefab => _gameOverMenuPrefab;
        public LoadingScreen LoadingScreenCanvasPrefab => _loadingScreenCanvasPrefab;
    }
}
