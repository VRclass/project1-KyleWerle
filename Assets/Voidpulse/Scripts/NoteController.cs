using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public AudioHelm.HelmController helmController;

    public GameObject centerPoint;
    public GameObject keyObject;

    private float xKey;
    private float zKey;

    public int note = 60;
    public int ID = 0;
    public int globalID = 0;

    private float distance;
    private float previousDistance;
    private float filterCutoff = 0f;

    private float modulationX;
    private float modulationZ;

    public bool isGrabbed = false;

    void Start()
    {
        //print(gameObject.name);
    }

    void Update() {

        if (isGrabbed){
            if (globalID == 0){
                if (Global.synthVoiceControl0 == ID) {
                    ModulateParameters();
                }
            } else if (globalID == 1) {
                if (Global.synthVoiceControl1 == ID) {
                    ModulateParameters();
                }
            } else if (globalID == 2) {
                if (Global.synthVoiceControl2 == ID) {
                    ModulateParameters();
                }
            }
        }
    }

    public void GrabActivation(bool grabber) {
        isGrabbed = grabber;
    }

    void ModulateParameters() {
        //distance of both gameobjects
        distance = Vector3.Distance(keyObject.transform.position, centerPoint.transform.position);
        //filterCutoff = helmController.GetParameterPercent(AudioHelm.Param.kFilterCutoff);
        distance = Mathf.Clamp(distance * 0.9f + 0.01f, .01f, 0.5f) * 2;
        filterCutoff = distance;

        helmController.SetParameterPercent(AudioHelm.Param.kFilterCutoff, filterCutoff);

        /*
        //angle of key object based on x 
        xKey = keyObject.transform.rotation.eulerAngles.x;
        //print(xKey);
        modulationX = Mathf.DeltaAngle(xKey, 345.0f);
        modulationX = Mathf.Clamp(modulationX * 0.03f, -1, 1);
        modulationX = (modulationX * 0.5f) + 0.5f; 

        helmController.SetParameterPercent(AudioHelm.Param.kOsc1Tune, modulationX);
        */

        //z angle change of key object
        zKey = keyObject.transform.rotation.eulerAngles.z;
        modulationZ = Mathf.DeltaAngle(zKey, 0f);
        modulationZ = Mathf.Abs(modulationZ);
        modulationZ = Mathf.Clamp(modulationZ * 0.005f, 0f, 0.85f);
        modulationZ = (modulationZ - 1.0f) * -1.0f;
        //print (modulationZ);


        helmController.SetParameterPercent(AudioHelm.Param.kVolume, modulationZ);
}

    public void PlayNote() {
        //  midi note, velocity, length
        helmController.NoteOn(note, 1.0f);
    }

    public void StopNote() {
        helmController.NoteOff(note);
        modulationX = 0.5f;
    }

    public void SetVoiceController() {
        if (globalID == 0){
            Global.synthVoiceControl0 = ID;
        } else if (globalID == 1) {
            Global.synthVoiceControl1 = ID;
        } else if (globalID == 2) {
            Global.synthVoiceControl2 = ID;
        }

    }

}
