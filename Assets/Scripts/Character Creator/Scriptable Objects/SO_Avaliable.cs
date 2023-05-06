using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Avaliable", menuName = "123")]
public class SO_Avaliable : ScriptableObject
{
    // ~~ 1. Holds details about the full character body

    public BodyPartAvaliable[] characterBodyParts;
}

[System.Serializable]
public class BodyPartAvaliable
{
    public string bodyPartName;
    public List<SO_BodyPart> bodyPartOptions;
    public int bodyPartCurrentIndex;

}

