using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCambioController : MonoBehaviour
{
    public void CargarSiguienteNivel()
    {
        int escenaActualIndex=SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndex = ++escenaActualIndex;
        SceneManager.LoadScene(siguienteEscenaIndex);
    }
}
