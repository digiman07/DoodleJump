using UnityEngine;
public class DeadZone : MonoBehaviour
{
    //Reference The LevelManager MonoBehaviour
    public LevelManager LevelManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("DeadZone");

        if (collision.gameObject.tag == "Player")
        {
            //You Hit the DeadZone and Died, restart Level
            LevelManager.PlayerDied();
        }
    }
}
