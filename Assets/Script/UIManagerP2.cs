using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerP2 : MonoBehaviour
{
    public GameObject player1Win;
    private void OnEnable()
    {
        LiveP2.player2Dead += EnalblePlayer1Win;
    }
    private void OnDisable()
    {
        LiveP2.player2Dead -= EnalblePlayer1Win;
    }
    public void EnalblePlayer1Win()
    {
        player1Win.SetActive(true);
    }

}
