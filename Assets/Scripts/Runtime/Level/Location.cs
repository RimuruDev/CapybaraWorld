using UnityEngine;

namespace Core.Level
{
    [CreateAssetMenu(fileName = "New Location", menuName = "Presets/Location")]
    public class Location : ScriptableObject
    {
        [SerializeField] private bool _useDefaultBackground = true;
        [SerializeField] private Color _backgroundColor;
        [SerializeField] private SimplePlatform[] _simplePlatforms;
        [SerializeField] private SpecialPlatform[] _specialPlatforms;

        public bool UseDefaultBackground => _useDefaultBackground;
        public Color BackgroundColor => _backgroundColor;
        public SimplePlatform[] SimplePlatforms => _simplePlatforms;
        public SpecialPlatform[] SpecialPlatforms => _specialPlatforms;
    }
}