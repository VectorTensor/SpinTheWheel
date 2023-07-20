using UnityEngine;

public class ProbabilityHandler: MonoBehaviour
{
    int[] cumulativeProbability;

    public int GetItemByProbability(int[] probability) //30 40 20 10
    {
        MakeCumulativeProbability(probability); //30 70 90 100

        float rnd = Random.Range(0, 101); // 0%, 100%

        for (int i = 0; i < probability.Length; i++)
        {
            if (rnd <= cumulativeProbability[i])                  //without sum(100<=10)
            {
                return i;  //40, 10
            }
        }

        return -1;
    }

    void MakeCumulativeProbability(int[] probability)
    {
        int probabilitiesSum = 0;
        cumulativeProbability = new int[probability.Length];

        for (int i = 0; i < probability.Length; i++)
        {
            probabilitiesSum += probability[i];
            cumulativeProbability[i] = probabilitiesSum;
        }

        if (probabilitiesSum > 100)
        {
            Debug.Log("Probability exceed 100%");
        }
    }
}