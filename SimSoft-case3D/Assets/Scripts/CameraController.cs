using DG.Tweening;
using SimSoft;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Vector3 offsetPosition = new Vector3(0, 3, -10);
   private CubeObject _cubeObject;

   public void UpdateCameraPosition(Vector3 position)
   {
      transform.DOMove(position + offsetPosition, 2f).SetTarget(this);
   }

   private void OnDestroy()
   {
      DOTween.Kill(this);
   }
}
