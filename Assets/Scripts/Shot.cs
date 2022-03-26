using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject vfx;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {       

            vfx = Instantiate(vfx, collision.contacts[0].point, Quaternion.identity);
            Destroy(vfx, 3f);
            Destroy(this.gameObject, 0);

            collision.gameObject.GetComponent<Player>().Morri();
        }
    }

    private void Start()
    {
        {
            //Autodestroy tiro
            Destroy(this.gameObject, 5f);
        }
    }
}
