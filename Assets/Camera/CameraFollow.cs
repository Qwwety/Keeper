using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("ForFollow")]
    [SerializeField] private Transform Player;
    [SerializeField] private float CamRange;
    [SerializeField] private float CamPosition;
    [SerializeField] private float AddCamPositionX;
    [SerializeField] private float AddCamPositionY;
    [Header("ForBorder")]
    [SerializeField] float MinX;
    [SerializeField] float MaxX;
    [SerializeField] float MinY;
    [SerializeField] float MaxY;

    private Camera Camera;

    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.position = new Vector3(Player.position.x+ AddCamPositionX, Player.position.y+ AddCamPositionY, CamRange);
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY));
            Camera.orthographicSize = CamPosition;
        }
        catch
        {

        }
        
    }
}
