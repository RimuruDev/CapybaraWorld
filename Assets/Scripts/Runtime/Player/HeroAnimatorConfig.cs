using UnityEngine;

namespace Core.Player
{
    [CreateAssetMenu(fileName = "Hero Animator Config", menuName = "Configs/Hero Animator Config")]
    public class HeroAnimatorConfig : ScriptableObject
    {
        [Header("Body")]
        [SerializeField] private bool _rotateBody = true;
        [SerializeField] private float _bodyRotationSpeed = 2f;
        
        [Header("Arm with Hook")]
        [SerializeField] private bool _rotateArmWithHook = true;
        [SerializeField] private float _handRotationSpeed = 5f;
        
        [Header("Legs")]
        [SerializeField] private bool _rotateLegs = true;
        [SerializeField] private float _legsRotationDuration = 0.8f;
        [SerializeField] private Vector3 _fallingLegsRotation = new(0f, 0f, -30f);
        [SerializeField] private Vector3 _raisingLegsRotation = new(0f, 0f, 30f);

        [Space]
        [SerializeField] private float _heroFallingVelocityMinimum = -2f;
        [SerializeField] private float _heroRaisingVelocityMinimum = 0.1f;

        [Header("Default State")]
        [SerializeField] private Vector3 _defaultRotation = Vector3.zero;
        [SerializeField] private float _rotateToDefaultDuration = 1f;

        public bool RotateBody => _rotateBody;
        public bool RotateArmWithHook => _rotateArmWithHook;
        public float HandRotationSpeed => _handRotationSpeed;
        public float BodyRotationSpeed => _bodyRotationSpeed;
        public Vector3 DefaultRotation => _defaultRotation;
        public float RotateToDefaultDuration => _rotateToDefaultDuration;
        public bool RotateLegs => _rotateLegs;
        public float LegsRotationDuration => _legsRotationDuration;
        public Vector3 FallingLegsRotation => _fallingLegsRotation;
        public Vector3 RaisingLegsRotation => _raisingLegsRotation;
        public float HeroFallingVelocityMinimum => _heroFallingVelocityMinimum;
        public float HeroRaisingVelocityMinimum => _heroRaisingVelocityMinimum;
    }
}
