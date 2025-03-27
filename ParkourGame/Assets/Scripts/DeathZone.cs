using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject NewPlayer;
    GameObject SpawnPoint;
    List<GameObject> DashBoosts;
    PlayerUI PUI;
    public GameObject camera;
    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        DashBoosts = GameObject.FindGameObjectsWithTag("PowerUp").ToList();
        SpawnPoint = GameObject.Find("SpawnPoint");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            StartCoroutine(WaitSpawn());
            foreach (GameObject DashBoost in DashBoosts)
            {
                DashBoost.GetComponent<Collider>().enabled = true;
                DashBoost.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            }
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
        PUI.jump = NewCreatedPlayer.transform.GetComponent<Jump>();
    }
}
