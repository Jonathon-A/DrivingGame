using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public MSVehicleControllerFree StartVehicle;
    private static List<MSVehicleControllerFree> VehicleScriptArray;
    private static MSVehicleControllerFree ThisCarScript;
    void Start()
    {

        GameObject[] CarDetectionArray = GameObject.FindGameObjectsWithTag("CarDetection");

        VehicleScriptArray = new List<MSVehicleControllerFree>();
           
       
        foreach (GameObject Car in CarDetectionArray)
        {
            VehicleScriptArray.Add(Car.GetComponent<MSVehicleControllerFree>());
           
        }
        foreach (MSVehicleControllerFree Car in VehicleScriptArray)
        {
            Car.EnableCameras(-1);
        }

        ThisCarScript = StartVehicle;

        ThisCarScript.EnableCameras(0);
        ThisCarScript.CurrentCameraCar = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {

            SwitchCar(ThisCarScript);
        }
    }

    public static void SwitchCar(MSVehicleControllerFree NewCarScript) {
        if (NewCarScript == ThisCarScript && VehicleScriptArray.Count > 1)
        {

        
        int CameraIndex = ThisCarScript.indexCamera;


        float Distance = Mathf.Infinity;
        int j = 0;
        for (int i = 0; i < VehicleScriptArray.Count; i++)
        {
            VehicleScriptArray[i].EnableCameras(-1);
            VehicleScriptArray[i].CurrentCameraCar = false;
            VehicleScriptArray[i].indexCamera = CameraIndex;

            if (VehicleScriptArray[i] != ThisCarScript)
            {
                float NewDistance = Vector3.Distance(VehicleScriptArray[i].gameObject.transform.position, ThisCarScript.gameObject.transform.position);
                if (NewDistance < Distance)
                {
                        j = i;
                    Distance = NewDistance;
                }
            }

        }
            ThisCarScript = VehicleScriptArray[j];
            ThisCarScript.EnableCameras(CameraIndex);
            ThisCarScript.CurrentCameraCar = true;
        }
    }

    public static void RemoveCar(MSVehicleControllerFree Car) {
        VehicleScriptArray.Remove(Car);
    }
}
