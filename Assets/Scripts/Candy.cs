using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Candy", menuName = "Candy", order = 1)]
public class Candy : ScriptableObject
{
    public CandyComponent CandyObject => candyObject;
    [SerializeField]private CandyComponent candyObject;

    public int CandyValue => candyValue;
    [SerializeField] private int candyValue;
}
