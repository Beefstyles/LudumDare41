using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObject : MonoBehaviour {

    public bool IsInfringing = false;

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Building")
        {
            Debug.Log("Not here");
            IsInfringing = true;
        }
    }

    void Start()
    {
        StartCoroutine("DestroySelf");
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1F);
        Destroy(gameObject);
    }

}
