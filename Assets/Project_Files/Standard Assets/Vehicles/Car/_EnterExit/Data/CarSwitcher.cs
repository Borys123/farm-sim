using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitcher : MonoBehaviour
{
    public DriverManager driverManager;
    private GameObject carCamObject;
    public GameObject[] cars;
    public GameObject car;
    private int m_CurrentActiveCar;
    private int m_CurrentActiveCharacter;
    private int m_CurrentActiveCamera;
    public Vector3 pos;
    public float rotX;
    public float rotY;
    public float rotZ;
    public Vector3 spawnPos;
    public float spawnPeriod = 5f;
    public float nextSpawnTime;
    float spawnDistance = -2;
 
    private void Awake()
    {
        carCamObject = GameObject.Find("DriverManager");
        driverManager = carCamObject.GetComponent("DriverManager") as DriverManager;
    }

    private void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.E) && car.activeInHierarchy == true && Time.time > nextSpawnTime ) {
            nextSpawnTime = Time.time + spawnPeriod;
            rotX = cars[m_CurrentActiveCar].transform.eulerAngles.x;
            rotY = cars[m_CurrentActiveCar].transform.eulerAngles.y;
            rotZ = cars[m_CurrentActiveCar].transform.eulerAngles.z;

            pos = cars[m_CurrentActiveCar].transform.position;
            Vector3 pod = cars[m_CurrentActiveCar].transform.forward;
            Vector3 pod2 = cars[m_CurrentActiveCar].transform.right;
            spawnPos = pod + pos + pod2*spawnDistance;
        
            Debug.Log("Car");
            OlSwitcheroo();
        }
    }
    public void OlSwitcheroo()
    {
        int nextactivecar = m_CurrentActiveCar + 1 >= cars.Length ? 0 : m_CurrentActiveCar + 1;
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == nextactivecar);
        }
        m_CurrentActiveCar = nextactivecar;
        cars[m_CurrentActiveCar].transform.position = pos;
        cars[m_CurrentActiveCar].transform.eulerAngles = new Vector3(rotX, rotY, rotZ);

        int nextactivecharacter = m_CurrentActiveCharacter + 1 >= driverManager.charactersReverse.Length ? 0 : m_CurrentActiveCharacter + 1;
        for (int i = 0; i < driverManager.charactersReverse.Length; i++)
        {
            driverManager.charactersReverse[i].SetActive(i == nextactivecharacter);
        }
        m_CurrentActiveCharacter = nextactivecharacter;
        driverManager.charactersReverse[m_CurrentActiveCharacter].transform.position = spawnPos;

        int nextactivecamera = m_CurrentActiveCamera + 1 >= driverManager.camerasReverse.Length ? 0 : m_CurrentActiveCamera + 1;
        for (int i = 0; i < driverManager.camerasReverse.Length; i++)
        {
            driverManager.camerasReverse[i].SetActive(i == nextactivecamera);
        }
        m_CurrentActiveCamera = nextactivecamera;
    }
}
