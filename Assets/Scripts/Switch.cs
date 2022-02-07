using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] bool needRed = false;
    [SerializeField] GameObject objToChange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Correct(other))
        {
            objToChange.SetActive(!objToChange.activeSelf);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Correct(other))
        {
            objToChange.SetActive(!objToChange.activeSelf);
        }
    }


    bool Correct(Collider2D other)
    {
        return (other.tag.Equals("Red") && needRed) || (other.tag.Equals("Blue") && !needRed);
    }
}
