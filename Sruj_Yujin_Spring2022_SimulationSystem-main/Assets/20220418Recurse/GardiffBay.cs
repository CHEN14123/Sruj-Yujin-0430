using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardiffBay : MonoBehaviour
{
    public GameObject Cell;
    public int Recurse = 3;

    // Start is called before the first frame update

    private void Grow(int recurse, Transform parent, float scale = 1)
    {
        if (recurse == 0) { return; }

        recurse--;
        GameObject cellA = Instantiate(Cell, parent.transform.position, Quaternion.identity, null);
        GameObject cellB = Instantiate(Cell, parent.transform.position, Quaternion.identity, null);
        cellA.name = "cellA" + recurse;
        cellB.name = "cellB" + recurse;
        // GameObject cellC = Instantiate(Cell, parent.transform.position, Quaternion.identity, null);

        // cellC.transform.parent = parent;

        //TODO: rotate the objects
        Vector3 dirA = parent.right;
        Vector3 dirB = parent.forward - parent.right;
        cellA.transform.forward = dirA;
        cellB.transform.forward = dirB;

        //TODO: move the objects
        cellA.transform.parent = parent; cellB.transform.parent = parent;
        cellA.transform.position = parent.position + (dirA * scale);
        cellB.transform.position = parent.position + (dirB * scale);

        //TODO: scale the objects
        scale = scale / 1.50f;
        cellA.transform.localScale = cellA.transform.localScale * scale;
        cellB.transform.localScale = cellB.transform.localScale * scale;
        //cellC.transform.localScale = cellC.transform.localScale * scale;

        //recurse
        Grow(recurse, cellA.transform, scale);
        Grow(recurse, cellB.transform, scale);
        // Grow(recurse, cellC.transform, scale);
    }

    private void Start()
    {
        GameObject cell = Instantiate(Cell, this.transform.position, Quaternion.identity, null);
        Grow(Recurse, cell.transform);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}