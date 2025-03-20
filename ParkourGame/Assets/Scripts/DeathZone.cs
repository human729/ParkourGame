using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject NewPlayer;
    GameObject SpawnPoint;
    PlayerUI PUI;
    public GameObject camera;
    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");

        SpawnPoint = GameObject.Find("SpawnPoint");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            StartCoroutine(WaitSpawn());
        }
    }

    private IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(5);
        GameObject NewCreatedPlayer = Instantiate(NewPlayer, SpawnPoint.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
        PUI = Camera.main.GetComponent<PlayerUI>();
        camera.GetComponent<CinemachineFreeLook>().LookAt = NewCreatedPlayer.transform.GetChild(3).transform;
        camera.GetComponent<CinemachineFreeLook>().Follow = NewCreatedPlayer.transform.GetChild(3).transform;

        PUI.MovementScript = NewCreatedPlayer.transform.GetComponent<PlayerMovement>();
        PUI.dash = NewCreatedPlayer.transform.GetComponent<Dash>();
        PUI.jump = NewCreatedPlayer.transform.GetComponent<Jump>();
    }
}
