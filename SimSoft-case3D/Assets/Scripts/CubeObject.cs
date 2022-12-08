using DG.Tweening;
using UnityEngine;

namespace SimSoft
{
    public class CubeObject : MonoBehaviour
    {
        private CameraController _camera;
        private Sequence _moveSequence;

        private void Awake()
        {
            _camera = FindObjectOfType<CameraController>();
        }

        public void SetPositionAndRotationInstant(Vector3 position, Vector3 rotation)
        {
            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);
            _camera.UpdateCameraPosition(transform.position);
        }

        public void SetPositionAndRotationSmooth(Vector3 position, Vector3 rotation, float duration)
        {
            if (_moveSequence != null && _moveSequence.IsPlaying())
            {
                _moveSequence.Complete();
            }

            _moveSequence = DOTween.Sequence()
                .Append(transform.DOMove(position, duration).SetEase(Ease.Linear))
                .Join(transform.DORotate(rotation, duration, RotateMode.FastBeyond360).SetEase(Ease.Linear))
                .OnComplete(() => _camera.UpdateCameraPosition(transform.position))
                .SetTarget(this);
        }

        private void OnDestroy()
        {
            DOTween.Kill(this);
        }
    }
}