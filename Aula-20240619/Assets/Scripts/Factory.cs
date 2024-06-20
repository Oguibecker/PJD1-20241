using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum FactoryObject
{
    None,
    Bullet,
    Pistol,
}

public class Factory : MonoBehaviour
{
    protected Dictionary<FactoryObject, GameObject> prefabsRef = new Dictionary<FactoryObject, GameObject>();

    static protected Factory _instance;
    static public Factory Instance {
        get
        {
            if(_instance == null)
            {
                CreateInstance();
            }
            return _instance;
        }
    }

    public List<FactoryObject> dkey = new List<FactoryObject>();
    public List<GameObject> dvalue = new List<GameObject>();

    static protected void CreateInstance()
    {
        if(_instance)
        { 
            return; 
        }
        var go = new GameObject("Factory");
        _instance = go.AddComponent<Factory>();
    }

    public void Init()
    {
        GameObject go;

        string[] enumNames = Enum.GetNames(typeof(FactoryObject));

        foreach (var name in enumNames)
        {
            if(name == "None")
            {
                continue;
            }

            go = Resources.Load<GameObject>($"Prefabs/{name}");
            prefabsRef.Add(Enum.Parse<FactoryObject>(name), go);

        }


        dkey = prefabsRef.Keys.ToList();
        dvalue = prefabsRef.Values.ToList();
    }

    public GameObject Create(FactoryObject type) {
        return Create(type, Vector3.zero, Quaternion.identity);
    }

    public GameObject Create(FactoryObject type, Vector3 position, Quaternion rotation)
    {
        var go = prefabsRef[type];
        if(go != null)
        {
            return Instantiate(go, position, rotation);
        }
        return null;
    }
}
