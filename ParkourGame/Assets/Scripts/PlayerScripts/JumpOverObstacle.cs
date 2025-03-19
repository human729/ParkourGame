using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverObstacle : MonoBehaviour
{
    RaycastHit hitObstacle;
    void Start()
    {
        
    }

    void Update()
    {
        findWall(GameObject.FindGameObjectWithTag("JumpObstacle"));
    }

    private void findWall(GameObject gameObject)
    {
        if (Physics.Raycast(transform.position + Vector3.up, gameObject.transform.position - transform.position, out hitObstacle, 1.5f))
        {
            Debug.DrawRay(transform.position + Vector3.up, gameObject.transform.position - transform.position, Color.red);
            
        }
    }
}
