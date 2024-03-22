using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerP1 : MonoBehaviour
{
    public GameObject player2Win;
    private void OnEnable()
    {
        Live.player1Dead += EnalblePlayer2Win;
    }
    private void OnDisable()
    {
        Live.player1Dead -= EnalblePlayer2Win;
    }
    public void EnalblePlayer2Win()
    {
        player2Win.SetActive(true);
    }

}
