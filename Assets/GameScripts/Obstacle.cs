using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == Constants.PLAYER_TAG)
        {
            GameManager.Instance.Die();
        }
    }
}