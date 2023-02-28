using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
        private MoveOnTouch _moveOnTouch;
        public bool x;
        public bool y;
        Vector2 direction;

        void Start()
        {
          _moveOnTouch = GameObject.Find("Generation").GetComponent<MoveOnTouch>();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
          if(x == true)
          {
            Debug.Log("Colision wall");
            col.gameObject.GetComponent<direction>().ball_direction.x = - col.gameObject.GetComponent<direction>().ball_direction.x;

            col.gameObject.GetComponent<Rigidbody2D>().velocity = col.gameObject.GetComponent<direction>().ball_direction * _moveOnTouch.bulletSpeed;
          }

          if(y == true)
          {
            Debug.Log("Colision wall");
            col.gameObject.GetComponent<direction>().ball_direction.y = - col.gameObject.GetComponent<direction>().ball_direction.y;

            col.gameObject.GetComponent<Rigidbody2D>().velocity = col.gameObject.GetComponent<direction>().ball_direction * _moveOnTouch.bulletSpeed;
          }
        }
}
