using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    class Plane : MonoBehaviour
    {
        private Rigidbody _thisRigidbody;

        private void Awake()
        {
            _thisRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _thisRigidbody.AddForce(new Vector3(20, 10, 0),ForceMode.Impulse);
        }
    }
}
