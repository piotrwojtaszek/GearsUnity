using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    private static GearManager _instance;
    public static GearManager Instance { get { return _instance; } }

    private List<IRotatationChange> itemsToUpdateOnRotationChange = new List<IRotatationChange>();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    /// <summary>
    /// Loop over all elements on list and callback function
    /// </summary>
    /// <param name="id"></param>
    /// <param name="deltaRotation"></param>
    public void UpdateAllObjectsOnList(int id, float deltaRotation)
    {
        foreach(var item in itemsToUpdateOnRotationChange)
        {
            item.OnRotationChange(id, deltaRotation);
        }
    }

    /// <summary>
    /// Add given item to list
    /// </summary>
    /// <param name="item"></param>
    public void AddToListOnRotationChange(IRotatationChange item)
    {
        itemsToUpdateOnRotationChange.Add(item);
    }

    /// <summary>
    /// Remove given item from list
    /// </summary>
    /// <param name="item"></param>
    public void RemoveFromListOnRotationChange(IRotatationChange item)
    {
        itemsToUpdateOnRotationChange.Remove(item);
    }
}
