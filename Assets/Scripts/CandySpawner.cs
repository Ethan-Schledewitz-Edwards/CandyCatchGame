using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] CandyIndex candyIndex;
    [SerializeField] Transform[] _spawnPoints;

    [Header("Systetm")]
    private int candyRemaning;

    private void Start()
    {
        ToggleCandySpawining(true);
    }

    //TOggles the candy spawner on and off
    public void ToggleCandySpawining(bool enabled)
    {
        if (enabled)
        {
            candyRemaning = 15;
            InvokeRepeating("spawnCandy", 0.5f, Random.Range(1, 3));
        }
        else CancelInvoke();
    }

    //This method picks a candy from a table based on weight. The candy spawns at a random position.
    private void spawnCandy()
    {
        //Stop repeating
        if (candyRemaning <= 0)
        {
            ToggleCandySpawining(false);
            ScoreTracker.Instance.FinishGame();
            return;
        }

        //Get the total weight of the table
        int totalWeight = 0;
        foreach (CandyIndex.candyWeight i in candyIndex.CandyWeights)
            totalWeight += i.Weight;

        //Find a random value within the table
        int rand = Random.Range(0, totalWeight);

        //Loop through the table and find an item based on probablility
        foreach (CandyIndex.candyWeight i in candyIndex.CandyWeights)
        {
            //Add Item
            if (i != null && rand <= i.Weight)
            {
                //Get a random spawnpoint
                Transform spawn = randomPos();

                //Create object and remove it from the pool
                Instantiate(i.Candy.CandyObject, spawn.position, spawn.rotation);
                candyRemaning--;
                return;
            }

            //Shrink the domain if nothing was found
            rand -= i.Weight;
        }
    }

    //Random pas returns a random position from an array of transforms
    private Transform randomPos()
    {
        int rand = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[rand];
        return  spawnPoint;
    }

}
