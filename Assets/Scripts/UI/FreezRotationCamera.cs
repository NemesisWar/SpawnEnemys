using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezRotationCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] _guiPanels;
    [SerializeField] private CameraRotate _cameraRotate;

    private void Awake()
    {
        _guiPanels = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _guiPanels[i] = gameObject.transform.GetChild(i).gameObject;
        }
        _cameraRotate = Camera.main.GetComponent<CameraRotate>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeyCode userInput = KeyCode.Escape;
            FoundNeedPanel(userInput);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            KeyCode userInput = KeyCode.Tab;
            FoundNeedPanel(userInput);
        }
    }

    private void FixedUpdate()
    {
        foreach (var panel in _guiPanels)
        {
            if (panel.activeSelf && !panel.GetComponent<GamePanel>())
            {
                _cameraRotate.enabled = false;
                return;
            }
        }
        _cameraRotate.enabled = true;
    }

    private void FoundNeedPanel(KeyCode userInput)
    {
        foreach (var panel in _guiPanels)
        {
            switch (userInput)
            {
                case KeyCode.Escape:
                    if (panel.GetComponent<MainMenuPanel>())
                    {
                        ActiveDeactivePanel(panel);
                    }
                    break;
                case KeyCode.Tab:
                    if (panel.GetComponent<InventoryPanel>())
                    {
                        ActiveDeactivePanel(panel);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void ActiveDeactivePanel(GameObject usertab)
    {
        if (usertab.activeSelf)
        {
            usertab.SetActive(false);
        }
        else
        {
            usertab.SetActive(true);
        }

    }
}
