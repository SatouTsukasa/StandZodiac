using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if (Player.transform.position.y < transform.position.y)
        {
            //Vector3 w = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 w = Player.transform.position;
            GetComponent<NavMeshAgent2D>().destination = w;
        }
        else
        {
            Debug.Log("rrrrrrrrrrrrrrrrr");
            GetComponent<Rigidbody2D>().velocity = transform.up * -1 * 
                GetComponent<Enemy>().speed * GetComponent<Spaceship>().speed;
        }
    }
}