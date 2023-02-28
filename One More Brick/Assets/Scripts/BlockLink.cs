using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockLink : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    public TextMeshPro myText;
    int range;


    void Start()
    {
        range = Random.Range(0, 10) + 1;
        _colorChanger.SetMaxCalls(range);
        myText.text = range.ToString();
    }

    void Update()
    {
       myText.text = range.ToString();
       if(range <= 0)
       {
         Destroy(this.gameObject);
       }
    }

     void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Player")
      {
         range--;

         _colorChanger.ChangeColor();
      }
    }
}
