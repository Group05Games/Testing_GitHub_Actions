using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsScript : MonoBehaviour, ICollectable {

    public GameObject d8;
    public PlayerManager Player;
    public GameObject TopHat;

    public AudioClip audioFile;
    public GameObject KillFloor;


    [Header("Grab Dist")]
    [Range(0f, 20.0f)]
    public float dist;

    void Start()
    {
        TopHat = GameObject.FindGameObjectWithTag("UnitOne");
        //KillFloor = GameObject.FindGameObjectWithTag("KillFloor");
        //KillFloor.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftControl) && Vector3.Distance(this.gameObject.transform.position, TopHat.transform.position) < dist))
        {
            //Debug.Log("Got Into Log Collect");
            //this.GetComponent<AudioSource>().Play();
            AudioSource.PlayClipAtPoint(audioFile, transform.position);
            Collect();
        }

        
    }

    public void Collect() {
        //Set variables
        Wallet wallet = this.Player.wallet;
        ResourceTypes.Resource resource = ResourceTypes.Resource.Wood;

        //Add a number [1-8] of rocks to the player wallet
        wallet.addResource(resource);
        //wallet.getResource(resource);

        Instantiate(d8, this.transform.position + (Vector3.up*2), Quaternion.identity);

        //Remove this object from the scene
        Kill();
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    //public void OnTriggetEnter(Collider BoxCollider)
    //{
    //    Kill();
    //}
}
