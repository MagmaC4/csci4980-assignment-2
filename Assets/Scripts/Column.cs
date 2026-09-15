using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            Bird bird = other.GetComponent<Bird>();
            GameControl.instance.BirdScored(bird.playerId);
        }
    }


}
