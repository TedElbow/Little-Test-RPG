using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartsSelector : MonoBehaviour
{
    // ~~ 1. Handles Body Part Selection Updates

    // Full Character Body
    [SerializeField] private SO_CharacterBody characterBody;
    // Body Part Selections
    [SerializeField] private BodyPartSelection[] bodyPartSelections;

    [SerializeField] private SO_Avaliable _avaliableParts;



    private void Start()
    {
        // Get All Current Body Parts
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyParts(i);
        }
    }

    private void Update()
    {
        
    }

    public void NextBodyPart(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (_avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex < _avaliableParts.characterBodyParts[partIndex].bodyPartOptions.Count - 1)
            {
                _avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                _avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (_avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex > 0)
            {
                _avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                _avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex = _avaliableParts.characterBodyParts[partIndex].bodyPartOptions.Count - 1;
            }

            UpdateCurrentPart(partIndex);
        }    
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {
        // Get Current Body Part Name
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartName;
        // Get Current Body Part Animation ID
        _avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID;
        //Get count Body types
    }

    private void UpdateCurrentPart(int partIndex)
    {
        // Update Selection Name Text
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = _avaliableParts.characterBodyParts[partIndex].bodyPartOptions[_avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex].bodyPartName;
        // Update Character Body Part
        characterBody.characterBodyParts[partIndex].bodyPart = _avaliableParts.characterBodyParts[partIndex].bodyPartOptions[_avaliableParts.characterBodyParts[partIndex].bodyPartCurrentIndex];
    }

}

[System.Serializable]
public class BodyPartSelection
{
    public Text bodyPartNameTextComponent;
}
