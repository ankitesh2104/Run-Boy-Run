using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float minSpeed1;
    public float maxSpeed1;

    float speed1;

    Player playerScript1;
    public int gain;

    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        speed1 = Random.Range(minSpeed1, maxSpeed1);

        //make this script access the script of the player
        playerScript1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //to make enemy go down
        transform.Translate(Vector2.down * speed1 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            playerScript1.TakeHealth(gain);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
