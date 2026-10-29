using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstaculoPrefabs;
    
    //Variables de tiempo
    public float minIntervaloPrefabs = 0.5f;
    public float maxIntervaloPrefabs = 2f;
    private float timer = 0f;
    private float nextIntervaloPrefabs;

    //Variables de posicion
    public float minPosicionX = -7.5f;
    public float maxPosicionX = 7.5f;
    public float spawnPosicionY = 10f;

    public enum dificultad { Facil, Normal, Dificil };

    public dificultad nivel = dificultad.Facil;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextIntervaloPrefabs = Random.Range(minIntervaloPrefabs, maxIntervaloPrefabs);

        Debug.Log("DIFICULTAD: " + nivel);
        switch (nivel)
        {
            case dificultad.Facil:
                minIntervaloPrefabs = 0.5f;
                maxIntervaloPrefabs = 2f;
                break;
            case dificultad.Normal:
                minIntervaloPrefabs = 0.5f;
                maxIntervaloPrefabs = 1f;
                break;
            case dificultad.Dificil:
                minIntervaloPrefabs = 0.5f;
                maxIntervaloPrefabs = 0.7f;
                break;
            default:
                minIntervaloPrefabs = 0.5f;
                maxIntervaloPrefabs = 2f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextIntervaloPrefabs)
        {
            float randomX = Random.Range(minPosicionX, maxPosicionX);
            Vector3 spawnPosicion = new Vector3(randomX, spawnPosicionY, 0f);
            int randomIndex = Random.Range(0, obstaculoPrefabs.Length);
            Instantiate(obstaculoPrefabs[randomIndex], spawnPosicion, Quaternion.identity);

            //Resetear el timer y calcular el siguiente intervalo de tiempo para instanciar el siguiente prefab
            timer = 0f;
            nextIntervaloPrefabs = Random.Range(minIntervaloPrefabs, maxIntervaloPrefabs);
        }
    }
}
