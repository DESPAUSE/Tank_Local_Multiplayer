using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumPlayer
{
    Player1 = 1,
    Player2 = 2
}

public class Player : MonoBehaviour
{
    public EnumPlayer numPlayer;

    public float force = 10;
    public float torque = 10;

    Rigidbody rb;

    float hor;
    float ver;

    public GameObject fumaca;
    public GameObject Shot;
    public GameObject ponta;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal" + (int)numPlayer);
        ver = Input.GetAxis("Vertical" + (int)numPlayer);

        if (Input.GetButtonDown("Fire"+(int)numPlayer))
            Fire();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Morri()
    {
        if (this.enabled == true)
        {
            //Instancia fumaça no modelo e não no centro do objeto que nao entendi onde está
            Instantiate(fumaca, this.gameObject.GetComponentInChildren<LODGroup>().transform);
            this.enabled = false;
        }
    }

    void Movement()
    {
        Vector3 dir = transform.forward * ver * force;
        rb.velocity = new Vector3(dir.x, rb.velocity.y, dir.z);

        float angle = transform.rotation.eulerAngles.y;
        rb.MoveRotation(Quaternion.Euler(0, angle + (hor * torque), 0));
    }

    void Fire()
    {
        var instance = Instantiate(Shot, ponta.transform);
        instance.GetComponent<Rigidbody>().AddForce(ponta.transform.forward * 6000);
    }
}