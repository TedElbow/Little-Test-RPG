using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BoughtItems : MonoBehaviour
{
    public static BoughtItems instance;
    public List<SO_BodyPart> bodyPartsBought = new List<SO_BodyPart>();
    public List<SO_BodyPart> defaultItems = new List<SO_BodyPart>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }


}

