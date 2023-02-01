using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    class ROR2Laser : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private LineRenderer _line;

        [SerializeField] private float _aimTime;
        [SerializeField] private Color _aimColor = new Color(1, 0, 0, 0.5f);

        [SerializeField] private Color _shootColor = new Color(1, 0.5f, 0, 1);
        [SerializeField] private GameObject _shootParticles;
        [SerializeField] private float _shootWidth = 0.3f;

        [SerializeField] private float _fadeTime;
        [SerializeField] private Material _fadeMaterial;
        [SerializeField] private AnimationCurve _fadeCurve;

        RaycastHit hit;

        private void Start()
        {
            if (Physics.Raycast(_point.position, _point.forward, out hit))
            {
                _line.positionCount = 2;
                _line.SetPosition(0, _point.position);
                _line.SetPosition(1, hit.point);
            }

            StartCoroutine(StartAttack());
        }

        private IEnumerator StartAttack()
        {
            yield return new WaitForSeconds(_aimTime);

            bool isEnabled = false;
            for (int i = 0; i < 11; i++)
            {
                if (isEnabled)
                {
                    _line.startColor = _aimColor;
                    _line.endColor = _aimColor;
                }
                else
                {
                    _line.startColor = Color.clear;
                    _line.endColor = Color.clear;
                }
                isEnabled = !isEnabled;
                yield return new WaitForSeconds(0.1f);
            }

            _line.material = _fadeMaterial;
            _line.widthMultiplier = _shootWidth;
            _line.startColor = _shootColor;
            _line.endColor = _shootColor;

            Instantiate(_shootParticles, hit.point, Quaternion.identity);

            for (float i = 0; i <= _fadeTime + 0.0001; i += Time.fixedDeltaTime)
            {
                _line.widthMultiplier = _fadeCurve.Evaluate(i / _fadeTime);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
