using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    class CarBody : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _thisRigidbody;

        private void Awake()
        {
            _thisRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontalDirection = Input.GetAxis("Horizontal");
            _thisRigidbody.AddTorque(Time.deltaTime * _speed * horizontalDirection);
        }
    }
}
