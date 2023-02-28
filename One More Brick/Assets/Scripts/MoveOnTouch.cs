using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveOnTouch : MonoBehaviour
{
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private GameObject bulletPrefab; // префаб снаряда
    [SerializeField] public float bulletSpeed = 10.0f; // скорость снаряда
    [SerializeField] private float time;
    [SerializeField] private TextMeshPro myText;
    [SerializeField] private List<GameObject> listBall = new List<GameObject>();

    public int CountBall;
    public bool Tap;
    public Vector2 clickPosition;
    public Vector2 direction;
    public Quaternion rotation;

    bool isDraging;

    void Update()
    {
        ListForeach();

       if(Tap)
       {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(BallPush());
            foreach (GameObject go in listBall) {
             Destroy(go);
            }
            listBall.Clear();

          isDraging = true;
          _trajectory.Show ();

        }

        if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            _trajectory.Hide ();
            
            if(direction.y >= 0)
            {
              StartCoroutine(BallPush());
            }
        }

        if(isDraging)
        {
          OnDrag();
        }
       }

        myText.text = "x" + CountBall.ToString();
    }

    void OnDrag()
    {
       listBall.Clear();
       clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       direction = (clickPosition - (Vector2)transform.position).normalized;
       rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);

       if(direction.y >= 0)
       {
         _trajectory.UpdateDots(transform.position, direction*bulletSpeed / 5);
         _trajectory.Show ();
       }
       else
       {
          _trajectory.Hide ();
       }
    }

    IEnumerator BallPush()
    {
       for (int i = 1; (CountBall+1) != i; i++)
          {
          if(!isDraging)
            {

            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            bullet.transform.SetParent(transform);
            listBall.Add(bullet);
            bullet.GetComponent<direction>().ball_direction = direction;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * bulletSpeed;

            yield return new WaitForSeconds(time);
            }
          }
    }

    void ListForeach()
    {
    int CountFull = 0;

      foreach (GameObject go in listBall) {
          if(go != null)
          {
            CountFull++;
          }
         }
        if(CountFull == 0)
        {
          Tap = true;
        }
        else
        {
          Tap = false;
        }
    }

    public void AddBall()
    {
      CountBall++;
    }

    public void DeleteBall()
    {
      CountBall--;
    }

	public void Stop()
	{
       StopCoroutine(StopPush());
       StartCoroutine(StopPush());
	}

    IEnumerator StopPush()
    {
       yield return new WaitForSeconds(0.05f);
       foreach (GameObject go in listBall) {
        Destroy(go);
       }
       listBall.Clear();
    }
}

