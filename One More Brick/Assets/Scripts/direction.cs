using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{
   public Vector2 ball_direction;

   void Update()
   {
     if(transform.position.y > 20f)
     {
       Destroy(this.gameObject);
     }
   }
}
