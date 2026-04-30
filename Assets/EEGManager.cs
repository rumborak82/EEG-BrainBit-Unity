using UnityEngine;

public class EEGManager : MonoBehaviour
{
    // Това прави класа достъпен от всякъде
    public static EEGManager Instance;

    // дали да използваме фалшиви данни
    public bool useSimulation = true;

    // EEG канали
    public float F1;
    public float F2;
    public float O1;
    public float O2;

    void Awake()
    {
        // запазваме единствената инстанция
        Instance = this;
    }

    void Update()
    {
        if (useSimulation)
        {
            SimulateEEG();
        }
    }

    void SimulateEEG()
    {
        float t = Time.time;

        float baseF1 = Mathf.Sin(t * 8f) * 0.7f + Mathf.Sin(t * 16f) * 0.2f;
        float baseF2 = Mathf.Sin(t * 7.5f) * 0.7f + Mathf.Sin(t * 15f) * 0.2f;
        float baseO1 = Mathf.Sin(t * 9f) * 0.7f + Mathf.Sin(t * 18f) * 0.2f;
        float baseO2 = Mathf.Sin(t * 8.5f) * 0.7f + Mathf.Sin(t * 17f) * 0.2f;

        // малък шум (не много!)
        baseF1 += Random.Range(-0.05f, 0.05f);
        baseF2 += Random.Range(-0.05f, 0.05f);
        baseO1 += Random.Range(-0.05f, 0.05f);
        baseO2 += Random.Range(-0.05f, 0.05f);

        // изглаждане
        F1 = Mathf.Lerp(F1, baseF1, 0.15f);
        F2 = Mathf.Lerp(F2, baseF2, 0.15f);
        O1 = Mathf.Lerp(O1, baseO1, 0.15f);
        O2 = Mathf.Lerp(O2, baseO2, 0.15f);
    }

    
}