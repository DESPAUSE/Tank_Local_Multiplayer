using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace PlayerUnity
{
public enum EnumPlayer
{
    Player1 = 1,
    Player2 = 2
}

public class Player : MonoBehaviour, IPunObservable
{
    public GameData_SO gameData;
    public PlayerData_SO data;
    public EnumPlayer numPlayer;
    PhotonView view;

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

        public GameObject myCam,
            mainCam;

    public bool damaged,
        isMoving,
        isPlaying;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("Shutup");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRotation = transform.rotation;
        view = GetComponent<PhotonView>();
           
    }

    private void Update()
    {
            if (view.IsMine)
            {
                myCam.SetActive(true);
                Destroy(Camera.main);
            }
            else
            {
                myCam.SetActive(false);

            }

            if (!damaged)
        {
            if(Input.GetButton("Horizontal" + (int)numPlayer) || Input.GetButton("Vertical" + (int)numPlayer))
            {
                FindObjectOfType<AudioManager>().Stop("TankIdle" + (int)numPlayer);
                if(!isMoving && isPlaying)
                {
                    isPlaying = false;
                    isMoving = true;
                }
            }
            else if (Input.GetButtonUp("Horizontal" + (int)numPlayer) || Input.GetButtonUp("Vertical" + (int)numPlayer))
            {
                isMoving = false;
                isPlaying = false;
                FindObjectOfType<AudioManager>().Stop("TankMoving" + (int)numPlayer);
            }

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
        FindObjectOfType<AudioManager>().Stop("Fire" + (int)numPlayer);
        FindObjectOfType<AudioManager>().Play("Shutup");
    }

    public void Morri()
    {
        if (this.enabled == true)
        {
            //Instancia fumaça no modelo e não no centro do objeto que nao entendi onde está
            fumacaOld = Instantiate(fumaca, this.gameObject.GetComponentInChildren<LODGroup>().transform);
            damaged = true;

            FindObjectOfType<AudioManager>().Stop("TankIdle" + (int)numPlayer);
            FindObjectOfType<AudioManager>().Stop("TankMoving" + (int)numPlayer);
            FindObjectOfType<AudioManager>().Play("Fire" + (int)numPlayer);
            FindObjectOfType<AudioManager>().Play("Shutdown");
            }
    }

    void Movement()
    {
        Vector3 dir = transform.forward * ver * force;
        rb.velocity = new Vector3(dir.x, rb.velocity.y, dir.z);

        float angle = transform.rotation.eulerAngles.y;
        rb.MoveRotation(Quaternion.Euler(0, angle + (hor * torque), 0));
        if (isMoving && !isPlaying)
        {
            isPlaying = true;
            FindObjectOfType<AudioManager>().Play("TankMoving" + (int)numPlayer);
        }
        else if (!isMoving && !isPlaying)
        {
            isPlaying = true;
            FindObjectOfType<AudioManager>().Play("TankIdle" + (int)numPlayer);
        }

    }

    void Fire()
    {
            var instance = PhotonNetwork.Instantiate("Tiro", ponta.transform.position, ponta.transform.rotation);
            instance.GetComponent<Shot>().player = this;
            instance.GetComponent<Rigidbody>().AddForce(ponta.transform.forward * 6000);
            FindObjectOfType<AudioManager>().Play("TankFire" + (int)numPlayer);
    }

    public void AddPoints(int value)
    {
        data.score += value;
        gameData.OnUpdateHUD.Invoke();
    }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            /*if (stream.IsWriting)
            {
                stream.SendNext(render.flipX);
            }
            else
            {
                render.flipX = (bool)stream.ReceiveNext();
            }*/
            
        }
    }
}