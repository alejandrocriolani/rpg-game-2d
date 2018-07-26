using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DialogueSystemExtensionUI : EditorWindow
{
    string npcName = "NPC sin nombre";
    string playerName = "Jugador";
    int nDialogues = 0, nDiagAnt = 0;
    string[] dialogues = null;

    [MenuItem("Window/ My Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(DialogueSystemExtensionUI));
    }

    private void MostrarNTextArea(int n)
    {
        if (n < 1)
            return;

        if (dialogues == null || n != nDiagAnt)
        {
            dialogues = new string[n];
            nDiagAnt = n;
        }

        for (int i = 0; i < n; i++)
        {
            dialogues[i] = EditorGUILayout.TextArea(dialogues[i]);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Sistema de diálogo", EditorStyles.boldLabel);
        GUILayout.Label("Nombres");
        npcName = EditorGUILayout.TextField("Nombre del npc:", npcName);
        playerName = EditorGUILayout.TextField("Nombre del jugador:", playerName);

        EditorGUILayout.Separator();
        GUILayout.Label("Diálogos");
        nDialogues = EditorGUILayout.IntField(nDialogues);
        GUILayout.Label("Ingrese los diáolgos");
        MostrarNTextArea(nDialogues);
    }

}
