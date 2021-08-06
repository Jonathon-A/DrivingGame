using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject ParentObject;
    public MSVehicleControllerFree ThisCarScript;
    public Transform ExplosionOrigin;

    public GameObject Explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
          //  Debug.Log("hitttt");
            CarSwitcher.SwitchCar(ThisCarScript);
            CarSwitcher.RemoveCar(ThisCarScript);
            Instantiate(Explosion, ExplosionOrigin.position, Quaternion.Euler(-90,0,0));
            Destroy(ParentObject);
        }
      
    }
}
