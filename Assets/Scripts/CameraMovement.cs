using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   private Transform player;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   private void LateUpdate()
   {
      var cameraTransform = transform;
      var temp = cameraTransform.position;
      var position = player.position;
      
      temp.x = position.x;
      temp.y = position.y;
      cameraTransform.position = temp;
   }
}
