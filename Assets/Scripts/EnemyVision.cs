using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyVision : MonoBehaviour
    {
        [SerializeField] private LayerMask _filter;
        
        public event UnityAction Detection;

        private void Start()
        {
            var collider = GetComponent<Collider2D>();
            collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((_filter.value & (1 << collision.gameObject.layer)) > 0)
            {
                Detection?.Invoke();
            }
        }
    }
}