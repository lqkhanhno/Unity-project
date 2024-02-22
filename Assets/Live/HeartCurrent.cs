using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCurrent : MonoBehaviour
{
    [SerializeField] private Live playerLive;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    private void Start()
    {
        totalhealthBar.fillAmount = playerLive.currentLive / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerLive.currentLive / 10;
    }
}