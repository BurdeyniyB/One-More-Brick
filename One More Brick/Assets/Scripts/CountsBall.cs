using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountsBall : MonoBehaviour
{
   private MoveOnTouch _moveOnTouch;
   private GameManager _gameManager;
   private CoinManager _coinManager;

   public bool Add;
   public bool Remove;
   public bool Coin;
   public bool Finish;
   public bool Delete;

     void Start()
     {
       _moveOnTouch = GameObject.Find("Generation").GetComponent<MoveOnTouch>();
       _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       _coinManager = GameObject.Find("Coin Manager").GetComponent<CoinManager>();
     }

     void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Player")
      {
         if(Add)
         {
           Debug.Log("+++");
           Destroy(this.gameObject);
           _moveOnTouch.AddBall();
         }

         if(Remove)
         {
           Debug.Log("---");
           Destroy(this.gameObject);
           _moveOnTouch.DeleteBall();
         }

         if(Coin)
         {
           _coinManager.AddCoin();
           Destroy(this.gameObject);
         }

         if(Finish)
         {
           _gameManager.WinGame();
         }

         if(Delete)
         {
           Destroy(col.gameObject);
         }
      }
    }
}
