using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Constants.PLAYER_TAG)
        {
            UIManager.Instance.IncreaseScore(ScorePoints);
            Destroy(this.gameObject);
        }
    }

    public int ScorePoints = 1;
    public float rotateSpeed = 50f;
}