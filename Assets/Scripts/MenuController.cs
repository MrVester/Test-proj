using NS.GameEventsScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button tutorialEndButton;

    private void Awake()
    {
        tutorialEndButton.gameObject.SetActive(false);
    }
    void Start()
    {
        //GameEvents.current.onTutorialEnd += EnableButton;
    }
    private void OnDestroy()
    {
        //GameEvents.current.onTutorialEnd -= EnableButton;
    }

    public void EnableButton()
    {
        tutorialEndButton.gameObject.SetActive(true);
    }
}
