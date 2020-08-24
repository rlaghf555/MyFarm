using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraPos
{
    TITLE,SELECT,CREATE
};
public class MenuController : MonoBehaviour
{
    public Transform characterSelectPos;
    public Transform characterCreatePos;
    public Transform mainCamera;
    public float speed = 1.0f;
    private CameraPos cp;
    [Range(0.001f, 1.0f)]
    public float SmoothFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cp = CameraPos.TITLE;
    }
   
    void FixedUpdate()
    {
        if (cp == CameraPos.SELECT)
            MoveCameraToCharacterSelectPos();
        if (cp == CameraPos.CREATE)
            MoveCameraToCharacterCreatePos();
        
    }
    public void SetCameraPosToCharacterSelectPos()
    {
        cp = CameraPos.SELECT;
    }
    public void SetCameraPosToCharacterCreatePos()
    {
        cp = CameraPos.CREATE;
    }
    void MoveCameraToCharacterSelectPos()
    {
        mainCamera.position = Vector3.Slerp(mainCamera.position, characterSelectPos.position, SmoothFactor);
        mainCamera.rotation = Quaternion.Slerp(mainCamera.rotation, characterSelectPos.rotation, SmoothFactor);

    }
    void MoveCameraToCharacterCreatePos()
    {
        mainCamera.position = Vector3.Slerp(mainCamera.position, characterCreatePos.position, SmoothFactor);
        mainCamera.rotation = Quaternion.Slerp(mainCamera.rotation, characterCreatePos.rotation, SmoothFactor);
    }
}
