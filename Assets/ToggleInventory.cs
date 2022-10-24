using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Toggle Inventoru");
        }
        if (Input.GetButtonDown("Inventory"))
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }

}
