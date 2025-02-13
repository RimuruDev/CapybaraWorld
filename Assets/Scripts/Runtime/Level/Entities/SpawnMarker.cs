using System;
using System.Diagnostics;
using System.Linq;
using TriInspector;
using UnityEngine;

namespace Core.Level
{
    public class SpawnMarker : MonoBehaviour
    {
        private const string NameFormat = "# {0} Marker";
        
        [SerializeField] private EntityKind _entityKind;
        
        [Space]
        [SerializeField] private Vector3 _gizmosOffset = Vector3.down;

        [Title("Chest Spawn Settings")]
        [ShowIf(nameof(_entityKind), EntityKind.Chest), EnumToggleButtons]
        [InfoBox("Choose Chest to be spawned")]
        [SerializeField] private ChestKind _chestKind;

        [Title("Enemy Spawn Settings")]
        [ShowIf(nameof(_entityKind), EntityKind.Enemy)]
        [InfoBox("Choose Enemy to be spawned")]
        [SerializeField] private EnemyKind _enemyKind;

        private GameObject _product;

        public EntityKind EntityKind => _entityKind;
        public EnemyKind EnemyKind => _enemyKind;
        public ChestKind ChestKind => _chestKind;

        public static SpawnMarker[] FilterByKind(SpawnMarker[] markers, EntityKind kind)
        {
            return markers
                .Where(marker => marker.IsEmpty() == true)
                .Where(marker => marker.EntityKind == kind)
                .ToArray();
        }

        #region MonoBehaviour
        
        private void OnValidate() =>
            gameObject.name = string.Format(NameFormat, _entityKind.ToString());

        [Conditional("UNITY_EDITOR")]
        private void OnDrawGizmos()
        {
            if (transform == null)
                return;
            
            Gizmos.color = Color.magenta;

            Vector3 thisPosition = transform.position;
            Gizmos.DrawLine(thisPosition, thisPosition + _gizmosOffset);
        }

        #endregion

        public void SetProduct(GameObject product)
        {
            if (product == null || product.activeSelf == false)
                throw new ArgumentNullException("Spawn Marker: null product given!");

            _product = product;
        }

        private bool IsEmpty()
        {
            if (_product == null)
                return true;

            return _product.activeSelf == false;
        }
    }
}
