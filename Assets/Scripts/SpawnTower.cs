using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;

public class SpawnTower : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private Transform rayStartPoint;
    [SerializeField] private float rayLength = 20.0f;
    [SerializeField] private MRUKAnchor.SceneLabels labelFlag;

    [Header("Gizmo Display")]
    [SerializeField] private GameObject gizmoDisplay;
    [SerializeField] private TextMeshPro gizmoLabelText;
    [SerializeField] private bool showGizmoLabelText;

    [Header("Tower Prefabs")]
    [SerializeField] private GameObject mainTowerPrefab;
    [SerializeField] private GameObject TowerPrefab01; // Tour secondaire 1
    [SerializeField] private GameObject TowerPrefab02; // Tour secondaire 2

    [Header("Spawn Settings")]
    [SerializeField] private OVRInput.Button spawnButton;

    public bool mainTowerPlaced = false; // Vérifie si la tour principale est placée
    public GameObject selectedTowerPrefab = null; // Tour sélectionnée pour le placement

    private MRUKRoom room; // Référence à la pièce actuelle détectée
    private Vector3 hitPoint; // Point d'impact du rayon

    private void Start()
    {
        room = MRUK.Instance.GetCurrentRoom();
        gizmoLabelText.enabled = showGizmoLabelText;
    }

    private void Update()
    {
        if (room == null)
        {
            Debug.LogWarning("Aucune pièce détectée.");
            return;
        }

        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

        if (room.Raycast(ray, rayLength, new LabelFilter(labelFlag), out RaycastHit hitInfo, out MRUKAnchor anchor))
        {
            HandleGizmoDisplay(hitInfo, anchor);

            if (IsGizmoPointingSkyward() && OVRInput.GetDown(spawnButton, OVRInput.Controller.RTouch))
            {
                if (!mainTowerPlaced)
                {
                    PlaceMainTower();
                }
                else if (selectedTowerPrefab != null)
                {
                    PlaceSecondaryTower();
                }
                else
                {
                    Debug.LogWarning("Aucune tour secondaire sélectionnée !");
                }
            }
        }
        else
        {
            gizmoDisplay.SetActive(false);
        }
    }

    private void HandleGizmoDisplay(RaycastHit hitInfo, MRUKAnchor anchor)
    {
        gizmoDisplay.SetActive(true);
        hitPoint = hitInfo.point;
        gizmoDisplay.transform.position = hitPoint;
        gizmoDisplay.transform.rotation = Quaternion.LookRotation(-hitInfo.normal);
        gizmoLabelText.text = $"Anchor: {anchor.Label}";
    }

    private bool IsGizmoPointingSkyward()
    {
        float rotationXGizmo = gizmoDisplay.transform.rotation.eulerAngles.x;
        return rotationXGizmo >= 89.0f && rotationXGizmo <= 91.0f;
    }

    private void PlaceMainTower()
    {
         if (mainTowerPrefab == null)
    {
        return;
    }

    GameObject tower = Instantiate(mainTowerPrefab, hitPoint, Quaternion.identity);

    GameEndManager gameEndManager = FindObjectOfType<GameEndManager>();
    if (gameEndManager == null)
    {
        return;
    }

    gameEndManager.SetMainTower(tower);

    mainTowerPlaced = true;
    }

    private void PlaceSecondaryTower()
    {
        Instantiate(selectedTowerPrefab, hitPoint, Quaternion.identity);
    }

    public void SelectTower01()
    {
        selectedTowerPrefab = TowerPrefab01;
    }

    public void SelectTower02()
    {
        selectedTowerPrefab = TowerPrefab02;
    }
}
