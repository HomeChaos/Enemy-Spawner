using System;
using UnityEngine;

namespace Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyVision _vision;
        [SerializeField] private float _speed = 1f;

        private void OnEnable()
        {
            _vision.Detection += OnVisionDetection;
        }

        private void OnVisionDetection()
        {
            _speed = -_speed;
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        }

        private void Update()
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }

        private void OnDisable()
        {
            _vision.Detection -= OnVisionDetection;
        }
    }
}