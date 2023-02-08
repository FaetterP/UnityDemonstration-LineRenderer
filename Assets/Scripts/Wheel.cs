using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    class Wheel : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _thisRigidbody;

        private void Awake()
        {
            _thisRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float verticalDirection = Input.GetAxis("Vertical");
            _thisRigidbody.AddTorque(Time.deltaTime * _speed * verticalDirection);
        }
    }
}
