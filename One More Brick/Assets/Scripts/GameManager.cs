using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int countBall;
    private MoveOnTouch _moveOnTouch;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject Countlevel;

    bool isDraging;
    bool Lose;
    int Count_level;
    bool Tap;


    void Start()
    {
        _moveOnTouch = GameObject.Find("Generation").GetComponent<MoveOnTouch>();

        Count_level = PlayerPrefs.GetInt("Count level");
        if(Count_level <= 0)
        {
          Count_level = 1;
          PlayerPrefs.SetInt("Count level", Count_level);
        }

        Countlevel.GetComponent<Text>().text = "Level " + Count_level.ToString();
    }

    void Update()
    {
        countBall = _moveOnTouch.CountBall;
        Tap = _moveOnTouch.Tap;

        if (countBall == 0)
        {
           LoseGame();
        }

       if(!Lose)
       {
        if (Input.GetMouseButtonDown(0)  && Tap)
        {
            isDraging = true;
            if(restartButton != null)
            {
              restartButton.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0)  && Tap)
        {
            isDraging = false;
            if(restartButton != null)
            {
              restartButton.SetActive(true);
            }
        }
       }
      }
      
       public void LoseGame()
      {
          LosePanel.SetActive(true);

          EndGame();
      }

       public void WinGame()
      {
          WinPanel.SetActive(true);

          Count_level++;

          EndGame();
      }

      void EndGame()
      {
          Destroy(restartButton);

          PlayerPrefs.SetInt("Count level", Count_level);
          if(GameObject.Find("Generation") != null)
          {
            GameObject.Find("Generation").SetActive(false);
          }
      }
}
