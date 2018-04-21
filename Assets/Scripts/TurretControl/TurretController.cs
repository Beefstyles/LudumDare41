using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject Projectile;
    private bool _canFire = true;
    private Transform _targetTransform;
    public float StrengthOfShot;
    public float ReloadSpeed;

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            _targetTransform = coll.gameObject.transform;
            transform.LookAt(_targetTransform);
            if (_canFire)
            {
                FireAtTarget();
                _canFire = false;
                StartCoroutine("DelayFire");
            }
        }
    }

    private void FireAtTarget()
    {
        GameObject projectile = Instantiate(Projectile, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce((_targetTransform.position - transform.position)* StrengthOfShot);
    }


    IEnumerator DelayFire()
    {
        yield return new WaitForSeconds(ReloadSpeed);
        _canFire = true;
    }

}
