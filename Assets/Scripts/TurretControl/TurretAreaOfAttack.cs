using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAreaOfAttack : MonoBehaviour
{
    GameObject ParentTransform;
    TurretController _turretController;

    void Start()
    {
        _turretController = GetComponentInParent<TurretController>();
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            _turretController.TargetTransform = coll.gameObject.transform;
            _turretController.HaveTarget = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            _turretController.TargetTransform = null;
            _turretController.HaveTarget = false;
        }
    }
}
