using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{
    private bool isDeleted = false;
    void Start()
    {
        //Invoke("DestroyObject", LifeTime);
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Playing && !isDeleted)
        {
            isDeleted = true;
            Invoke("DestroyObject", LifeTime);
        }
    }

    void DestroyObject()
    {
        if (GameManager.Instance.GameState != GameState.Dead)
            Destroy(gameObject);
    }


    public float LifeTime = 10f;
}