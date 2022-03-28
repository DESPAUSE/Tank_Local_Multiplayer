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
    public GameData_SO gameData;
    public PlayerData_SO data;
    public EnumPlayer numPlayer;

    public float force = 10;
    public float torque = 10;

    Rigidbody rb;

    float hor;
    float ver;

    Vector3 startPos;
    Quaternion startRotation;

    public GameObject fumaca, fumacaOld;
    public GameObject Shot;
    public GameObject ponta;

    public bool damaged;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (!damaged)
        {
            hor = Input.GetAxis("Horizontal" + (int)numPlayer);
            ver = Input.GetAxis("Vertical" + (int)numPlayer);

            if (Input.GetButtonDown("Fire" + (int)numPlayer))
                Fire();
        }
    }

    private void FixedUpdate()
    {

        if (!damaged)
        {
            Movement();
        }
    }

    public void Reset()
    {
        damaged = false;
        Destroy(fumacaOld);
        transform.rotation = startRotation;
        transform.position = startPos;
    }

    public void Morri()
    {
        if (this.enabled == true)
        {
            //Instancia fumaça no modelo e não no centro do objeto que nao entendi onde está
            fumacaOld = Instantiate(fumaca, this.gameObject.GetComponentInChildren<LODGroup>().transform);
            damaged = true;
            GameManager.GM.hud.DeathCountdown(((int)numPlayer));
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
        instance.GetComponent<Shot>().player = this;
        instance.GetComponent<Rigidbody>().AddForce(ponta.transform.forward * 6000);
        FindObjectOfType<AudioManager>().Play("TankFire" + (int)numPlayer);
    }

    public void AddPoints(int value)
    {
        data.score += value;
        gameData.OnUpdateHUD.Invoke();
    }
}