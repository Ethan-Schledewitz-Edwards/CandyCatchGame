using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CandyIndex", menuName = "CandyIndex", order = 1)]
public class CandyIndex : ScriptableObject
{
    public candyWeight[] CandyWeights => candyWeights;
    [SerializeField] private candyWeight[] candyWeights;

    [Serializable]
    public class candyWeight
    {
        public int Weight => weight;
        [SerializeField] private int weight;

        public Candy Candy => candy;
        [SerializeField] private Candy candy;
    }
}
