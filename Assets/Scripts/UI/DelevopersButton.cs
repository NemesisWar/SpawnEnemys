using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelevopersButton : MonoBehaviour
{
    public void ShowDevelopers()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
