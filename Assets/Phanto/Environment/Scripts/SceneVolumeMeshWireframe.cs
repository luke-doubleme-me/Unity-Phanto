// Copyright (c) Meta Platforms, Inc. and affiliates.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Utilities.XR;

/// <summary>
/// Creates a volume mesh wireframe for the scene.
/// </summary>
public class SceneVolumeMeshWireframe : MonoBehaviour
{
    [Tooltip("The mesh filter containing the mesh to be rendered.")]
    [SerializeField] private MeshFilter meshFilter;

    [Tooltip("The OVRSceneVolumeMeshFilter mesh filter.")]
    [SerializeField] private OVRSceneVolumeMeshFilter volumeMeshFilter;

    private Mesh _mesh;


    private static List<Vector3> GetClockwiseFloorOutline(OVRSceneRoom sceneRoom)
    {
        List<Vector3> cornerPoints = new List<Vector3>();

        var floor = sceneRoom.Floor;
        var floorTransform = floor.transform;

        foreach (var corner in floor.Boundary)
        {
            cornerPoints.Add(floorTransform.TransformPoint(corner));
        }
        cornerPoints.Reverse();
        return cornerPoints;
    }


    private IEnumerator Start()
    {
        while (!volumeMeshFilter.IsCompleted) yield return null;

        yield return null;

        var parentMeshFilter = volumeMeshFilter.GetComponent<MeshFilter>();

        var parentMesh = parentMeshFilter.sharedMesh;

        var vertices = new List<Vector3>();
        var triangles = new List<int>();

        parentMesh.GetVertices(vertices);
        parentMesh.GetTriangles(triangles, 0);

        var c = new Color[triangles.Count];
        var v = new Vector3[triangles.Count];
        var idx = new int[triangles.Count];
        //Luke S
        
        for (var i = 0; i < triangles.Count; i++)
        {
            c[i] = new Color(
                i % 3 == 0 ? 1.0f : 0.0f,
                i % 3 == 1 ? 1.0f : 0.0f,
                i % 3 == 2 ? 1.0f : 0.0f);
            v[i] = vertices[triangles[i]];
            idx[i] = i;
        }
        
        //Luke E
        _mesh = new Mesh
        {
            indexFormat = IndexFormat.UInt32
        };
        _mesh.SetVertices(v);
        _mesh.SetColors(c);
        _mesh.SetIndices(idx, MeshTopology.Triangles, 0, true, 0);
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();

        meshFilter.sharedMesh = _mesh;


        //Luke Start
        /*
        var sceneRoom = FindObjectOfType<OVRSceneRoom>();

        if (sceneRoom != null)
        {
            var classifications = sceneRoom.GetComponentsInChildren<OVRSemanticClassification>(true);

            var cornerPoints = GetClockwiseFloorOutline(sceneRoom);
            var volumes = new List<OVRSceneVolume>();
            var planes = new List<OVRScenePlane>();

            var ceilingHeight = sceneRoom.Ceiling.transform.position.y - sceneRoom.Floor.transform.position.y;

            var rotationRoom = Quaternion.FromToRotation(Vector3.up, new Vector3(1,1,1));


            XRGizmos.DrawCube(new Vector3(1, 1, 1), rotationRoom, new Vector3(10, 10, 10), Color.red);

            //XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z), rotationRoom, new Vector3(3, 3, 3), Color.red);
            //XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z), rotationRoom, new Vector3(10, 12, 12), Color.red);
            //XRGizmos.DrawCube(new Vector3(sceneRoom.Walls.transform.position.x, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z), rotationRoom, new Vector3(1, 0.5f, 1), Color.red);
        
        }
        */
    }

    private void OnDestroy()
    {
        Destroy(_mesh);
    }

#if UNITY_EDITOR
    private void Reset()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();

        if (volumeMeshFilter == null) volumeMeshFilter = GetComponentInParent<OVRSceneVolumeMeshFilter>();
    }
#endif
}
