using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// This class is responsible for placing and moving instance of the prefab in the real world.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class ARPlaceObject : MonoBehaviour
{
    // Reference to the AR Raycast Manager
    private ARRaycastManager raycastManager;

    // Prefab which will be spawned in the real world.
    [SerializeField]
    private GameObject prefab;

    // Instance of the prefab.
    private GameObject prefabInstance;
    bool isAct;
    /// <summary>
    /// Unity method called in before first frame.
    /// </summary>
    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();

        //InvokeRepeating("SpawnObject", 2.0f, 3f);
        prefabInstance = Instantiate(prefab);

        prefabInstance.SetActive(false);
    }

    /// <summary>
    /// Unity method called every frame.
    /// </summary>
    private void Update()
    {
        // List of the hit points in real world.
        var hitList = new List<ARRaycastHit>();


        // Raycast from the center of the screen which should hit only detected surfaces.
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitList, TrackableType.PlaneWithinBounds | TrackableType.PlaneWithinPolygon) && !isAct)
        {
            // In the instance is inactive, enable it.
            if (!prefabInstance.activeInHierarchy)
            {
                prefabInstance.SetActive(true);
            }

            // Sort hit list base on distance to the camera.
            hitList = hitList.OrderBy(h => h.distance).ToList();
            var hitPoint = hitList[0];

            // Position instance in the closest hit point.


            prefabInstance.transform.position = hitPoint.pose.position;
            prefabInstance.transform.up = hitPoint.pose.up;

            isAct = true;
        }
        else
        {
            /*
            // In the instance is active, disable it.
            if (prefabInstance.activeInHierarchy)
            {
                prefabInstance.SetActive(false);
            }
            */
            StartCoroutine(isActActive());

        }
    }
    /*
    void SpawnObject()
    {
        prefabInstance = Instantiate(prefab);

    }
    */
    IEnumerator isActActive()
    {
        yield return new WaitForSeconds(3f);
        prefabInstance = Instantiate(prefab);
        prefabInstance.SetActive(false);

        //isAct = false;
    }
}