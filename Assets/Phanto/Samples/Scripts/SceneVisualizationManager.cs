// Copyright (c) Meta Platforms, Inc. and affiliates.

using System;
using System.Collections;
using System.Collections.Generic;
using Utilities.XR;
using Phanto.Enemies.DebugScripts;
using Phantom.Environment.Scripts;
using PhantoUtils;
using PhantoUtils.VR;
using UnityEngine;

//luke S
using UnityEngine.UI;
//Luke E
using static NavMeshConstants;
//using System.Drawing;
//using UnityEditor.Experimental.GraphView;

namespace Phantom
{
    public class SceneVisualizationManager : MonoBehaviour
    {
        [SerializeField] private Transform leftHand;
        [SerializeField] private Transform rightHand;

        [SerializeField] private bool debugDraw = true;

        public static Action<bool> ShowWireframe;

        private readonly Dictionary<Transform, OVRSemanticClassification> _sceneClassifications = new Dictionary<Transform, OVRSemanticClassification>();

        private bool _sceneReady;
        private bool _started;

        private Transform _head;
        private int _layerMask;
        //private bool _meshVisible = true;
        private bool _meshVisible = false;

<<<<<<< Updated upstream
=======
        //Luke S
        public Text Intro_Txt;
        public Image Image_A_type;
        public GameObject image;


        private bool activateGo = true;
        //Luke E

>>>>>>> Stashed changes
        protected void Awake()
        {
            _layerMask = DefaultLayerMask | SceneMeshLayerMask;
            DebugDrawManager.DebugDraw = debugDraw;
        }

        private IEnumerator Start()
        {
            while (CameraRig.Instance == null)
            {
                yield return null;
            }

            _head = CameraRig.Instance.CenterEyeAnchor;

            ShowWireframe?.Invoke(_meshVisible);
            _started = true;

            // Luke Start       
            /*
            //Center Light
            // Make a game object
            GameObject lightGameObject = new GameObject("The Light");

            // Add the light component
            Light lightComp = lightGameObject.AddComponent<Light>();

            // Set color and position
            lightComp.color = Color.white;

            // Set the position (or any transform property)
            lightGameObject.transform.position = new Vector3(0, 0, 0);
            lightComp.type = LightType.Directional;
            lightComp.shadows = LightShadows.None;
            lightComp.intensity = 1;
            lightComp.range = 2;
            lightGameObject.transform.Rotate(-90f, 0, 0);

            */
            //CSpot
            // Make a game object
            GameObject lightGameObject_02 = new GameObject("The Light");

            // Add the light component
            Light lightComp_02 = lightGameObject_02.AddComponent<Light>();

            // Set color and position
            lightComp_02.color = Color.white;

            // Set the position (or any transform property)
            lightGameObject_02.transform.position = new Vector3(+2, 0, 0);
            lightComp_02.type = LightType.Directional;
            lightComp_02.shadows = LightShadows.None;
            lightComp_02.intensity = 2;
            lightComp_02.range = 5;
            lightGameObject_02.transform.Rotate(-90f, 0, 90f);

            // Center of place
            // Center =================================================================
            /*
            GameObject cube_base = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube_base.transform.position = new Vector3(0, 1, 0);
            cube_base.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cube_base.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);
            cube_base.transform.Rotate(45.0f, 45.0f, 0);
            */

            // Image Object
            /*
            image.GetComponent<Image>().sprite = Resources.Load("Image/poster04", typeof(Sprite)) as Sprite;
            image.transform.position = new Vector3(0, 2, 0);
            image.transform.localScale = new Vector3(100, 100, 100);
            */

            /*
            // room scale
            var sceneRoom = FindObjectOfType<OVRSceneRoom>();

            if (sceneRoom != null)
            {
                GameObject cube_advertize = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube_advertize.transform.position = new Vector3(sceneRoom.Ceiling.transform.position.x, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z);
                
            }
            else
            { Debug.Log("Empty Room"); }
            */

            //Luke End
        }

        private void Update()
        {
            if (!_sceneReady || !_started)
            {
                return;
            }

            if (OVRInput.GetDown(OVRInput.Button.One | OVRInput.Button.Three, OVRInput.Controller.LTouch | OVRInput.Controller.RTouch))
            {
                // toggle the wireframe.
                _meshVisible = !_meshVisible;
                ShowWireframe?.Invoke(_meshVisible);
            }
            // Luke start ============================================================================================================
            var sceneRoom = FindObjectOfType<OVRSceneRoom>();

            //activateGo = false;

            if (activateGo == true)
            {
                if (sceneRoom != null)
                {
                    
                    GameObject cube_advertize = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize.transform.position = new Vector3(sceneRoom.Ceiling.transform.position.x, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z);
                    cube_advertize.transform.localScale = new Vector3(1, 0.2f, 1);
                    cube_advertize.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize = new Texture2D(0, 0);
                    string PATHadvertize = "Image/CocaCola";
                    texture_advertize = Resources.Load<Texture2D>(PATHadvertize);

                    var rendadvertize = cube_advertize.GetComponent<MeshRenderer>();
                    rendadvertize.material.mainTexture = texture_advertize;

                    cube_advertize.transform.Rotate(0.0f, 90f, 0.0f);
                    
                    // ==========================================================================================
                    /*
                    GameObject cube_advertize1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize1.transform.position = new Vector3(sceneRoom.Floor.transform.position.x - 1f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.7f);
                    cube_advertize1.transform.localScale = new Vector3(2, 0.1f, 1.2F);
                    cube_advertize1.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize1 = new Texture2D(0, 0);
                    string PATHadvertize1 = "Image/supercar007";
                    texture_advertize1 = Resources.Load<Texture2D>(PATHadvertize1);

                    var rendadvertize1 = cube_advertize1.GetComponent<MeshRenderer>();
                    rendadvertize1.material.mainTexture = texture_advertize1;

                    cube_advertize1.transform.Rotate(0.0f, -90f, 0.0f);
                    */
                    // ==========================================================================================
                    
                    GameObject cube_advertize2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //cube_advertize2.transform.position = new Vector3(sceneRoom.Floor.transform.position.x - 2.2f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.7f);
                    cube_advertize2.transform.position = new Vector3(sceneRoom.Floor.transform.position.x, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z);
                    cube_advertize2.transform.localScale = new Vector3(2, 0.1f, 1.2F);
                    cube_advertize2.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize2 = new Texture2D(0, 0);
                    string PATHadvertize2 = "Image/supercar008";
                    texture_advertize2 = Resources.Load<Texture2D>(PATHadvertize2);

                    var rendadvertize2 = cube_advertize2.GetComponent<MeshRenderer>();
                    rendadvertize2.material.mainTexture = texture_advertize2;

                    cube_advertize2.transform.Rotate(0.0f, -90f, 0.0f);
                    
                    // ==========================================================================================
                    /*
                    GameObject cube_advertize3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize3.transform.position = new Vector3(sceneRoom.Floor.transform.position.x + 0.2f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.7f);
                    cube_advertize3.transform.localScale = new Vector3(2f, 0.1f, 1.2F);
                    cube_advertize3.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize3 = new Texture2D(0, 0);
                    string PATHadvertize3 = "Image/supercar003";
                    texture_advertize3 = Resources.Load<Texture2D>(PATHadvertize3);

                    var rendadvertize3 = cube_advertize3.GetComponent<MeshRenderer>();
                    rendadvertize3.material.mainTexture = texture_advertize3;

                    cube_advertize3.transform.Rotate(0.0f, -90f, 0.0f);

                    */
                    
                    // ==========================================================================================
                    
                    GameObject cube_advertize4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize4.transform.position = new Vector3(sceneRoom.Walls[1].transform.position.x, sceneRoom.Walls[1].transform.position.y, sceneRoom.Walls[1].transform.position.z);
                    cube_advertize4.transform.localScale = new Vector3(1, 1, 1);
                    cube_advertize4.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize4 = new Texture2D(0, 0);
                    string PATHadvertize4 = "Image/soju002";
                    texture_advertize4 = Resources.Load<Texture2D>(PATHadvertize4);

                    var rendadvertize4 = cube_advertize4.GetComponent<MeshRenderer>();
                    rendadvertize4.material.mainTexture = texture_advertize4;

                    cube_advertize4.transform.Rotate(0.0f, 0.0f, 0.0f);


                    // ==========================================================================================

                    GameObject cube_advertize5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize5.transform.position = new Vector3(sceneRoom.Walls[3].transform.position.x, sceneRoom.Walls[3].transform.position.y + 0.55f, sceneRoom.Walls[3].transform.position.z);
                    cube_advertize5.transform.localScale = new Vector3(0.1f,1f, 0.8f);
                    cube_advertize5.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize5 = new Texture2D(0, 0);
                    string PATHadvertize5 = "Image/soju009";
                    texture_advertize5 = Resources.Load<Texture2D>(PATHadvertize5);

                    var rendadvertize5 = cube_advertize5.GetComponent<MeshRenderer>();
                    rendadvertize5.material.mainTexture = texture_advertize5;

                    cube_advertize5.transform.Rotate(0.0f, 0.0f, 0.0f);
                    
                    /*
                    // Advertizing pannel 1 =================================================================
                    GameObject cube_button = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_button.transform.position = new Vector3(sceneRoom.Walls[2].transform.position.x + 1, sceneRoom.Walls[2].transform.position.y, sceneRoom.Walls[2].transform.position.z);
                    cube_button.transform.localScale = new Vector3(1.5f, 2f, 0.1f);
                    cube_button.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);


                    Texture2D texture_A = new Texture2D(0, 0);
                    string PATH = "Image/soju004";
                    texture_A = Resources.Load<Texture2D>(PATH);

                    var rend = cube_button.GetComponent<MeshRenderer>();
                    rend.material.mainTexture = texture_A;

                    cube_button.transform.Rotate(0.0f, 180.0f, 0.0f);
                    //---------------------------------------------------------------------------------------
                    GameObject cube_button_02 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_button_02.transform.position = new Vector3(sceneRoom.Walls[2].transform.position.x + 4, sceneRoom.Walls[2].transform.position.y + 0.5f, sceneRoom.Walls[2].transform.position.z);
                    cube_button_02.transform.localScale = new Vector3(0.7f, 1f, 0.1f);
                    cube_button_02.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    var rend_02 = cube_button_02.GetComponent<MeshRenderer>();
                    rend_02.material.mainTexture = texture_A;

                    cube_button_02.transform.Rotate(0.0f, 180.0f, 0.0f);

                    // Advertizing pannel 1 =================================================================
                    GameObject cube_button30 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_button30.transform.position = new Vector3(sceneRoom.Walls[2].transform.position.x + 2.5f, sceneRoom.Walls[2].transform.position.y, sceneRoom.Walls[2].transform.position.z);
                    cube_button30.transform.localScale = new Vector3(1.5f, 2f, 0.1f);
                    cube_button30.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);


                    Texture2D texture_30 = new Texture2D(0, 0);
                    string PATH30 = "Image/soju008";
                    texture_30 = Resources.Load<Texture2D>(PATH30);

                    var rend30 = cube_button30.GetComponent<MeshRenderer>();
                    rend30.material.mainTexture = texture_30;

                    cube_button30.transform.Rotate(0.0f, 180.0f, 0.0f);

                    */
                    
                    // Advertizing pannel 2 =================================================================
                    GameObject cube_Ads2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    //cube_Ads2.transform.position = new Vector3(sceneRoom.Walls[5].transform.position.x - 0.05f, sceneRoom.Walls[5].transform.position.y, sceneRoom.Walls[5].transform.position.z + 0.5f);
                    cube_Ads2.transform.position = new Vector3(sceneRoom.Walls[2].transform.position.x - 0.05f, sceneRoom.Walls[2].transform.position.y, sceneRoom.Walls[2].transform.position.z + 0.5f);
                    cube_Ads2.transform.localScale = new Vector3(0.1f, 1.5f, 1 );
                    cube_Ads2.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);


                    Texture2D texture_2 = new Texture2D(0, 0);
                    string PATH2 = "Image/CocaCola004";
                    texture_2 = Resources.Load<Texture2D>(PATH2);

                    var rend2 = cube_Ads2.GetComponent<MeshRenderer>();
                    rend2.material.mainTexture = texture_2;

                    cube_Ads2.transform.Rotate(0.0f, 180.0f, 0f);

                    //-----------------------------------------------------------------------------------------
                    GameObject cube_Ads2_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    //cube_Ads2_2.transform.position = new Vector3(sceneRoom.Walls[5].transform.position.x - 0.05f, sceneRoom.Walls[5].transform.position.y, sceneRoom.Walls[5].transform.position.z + 1.5f);
                    cube_Ads2_2.transform.position = new Vector3(sceneRoom.Walls[0].transform.position.x - 0.05f, sceneRoom.Walls[0].transform.position.y, sceneRoom.Walls[0].transform.position.z + 1.5f);

                    cube_Ads2_2.transform.localScale = new Vector3(0.1f, 1f, 0.7f);
                    cube_Ads2_2.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    var rend2_2 = cube_Ads2_2.GetComponent<MeshRenderer>();
                    rend2_2.material.mainTexture = texture_2;

                    cube_Ads2.transform.Rotate(0.0f, 180.0f, 0f);

                    /*
                    // Advertizing pannel 3 =================================================================
                    GameObject cube_Ads3 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads3.transform.position = new Vector3(sceneRoom.Walls[6].transform.position.x + 2, sceneRoom.Walls[6].transform.position.y + 0.5f, sceneRoom.Walls[6].transform.position.z);
                    cube_Ads3.transform.localScale = new Vector3(1.5f, 1, 0.1f);
                    cube_Ads3.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_3 = new Texture2D(0, 0);
                    string PATH3 = "Image/poster03";
                    texture_3 = Resources.Load<Texture2D>(PATH3);

                    var rend3 = cube_Ads3.GetComponent<MeshRenderer>();
                    rend3.material.mainTexture = texture_3;

                    cube_Ads3.transform.Rotate(0f, 0f, 0.0f);


                    // Advertizing pannel 5 =================================================================
                    GameObject cube_Ads5 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads5.transform.position = new Vector3(sceneRoom.Walls[6].transform.position.x, sceneRoom.Walls[6].transform.position.y + 0.5f, sceneRoom.Walls[6].transform.position.z);
                    cube_Ads5.transform.localScale = new Vector3(1.5f, 1, 0.1f);
                    cube_Ads5.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_5 = new Texture2D(0, 0);
                    string PATH5 = "Image/logo002";
                    texture_5 = Resources.Load<Texture2D>(PATH5);

                    var rend5 = cube_Ads5.GetComponent<MeshRenderer>();
                    rend5.material.mainTexture = texture_5;

                    cube_Ads5.transform.Rotate(0.0f, 0.0f, 0.0f);

                    //--------------------------------------------------------------------------------------

                    // Advertizing pannel 4 =================================================================
                    GameObject cube_Ads4 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads4.transform.position = new Vector3(sceneRoom.Walls[6].transform.position.x - 2, sceneRoom.Walls[6].transform.position.y + 0.5f, sceneRoom.Walls[6].transform.position.z);
                    cube_Ads4.transform.localScale = new Vector3(1.5f, 1, 0.1f);
                    cube_Ads4.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_4 = new Texture2D(0, 0);
                    string PATH4 = "Image/poster04";
                    texture_4 = Resources.Load<Texture2D>(PATH4);

                    var rend4 = cube_Ads4.GetComponent<MeshRenderer>();
                    rend4.material.mainTexture = texture_4;

                    cube_Ads4.transform.Rotate(0.0f, 0.0f, 0.0f);
                    */
                    /*
                    // Advertizing pannel 6 =================================================================
                    GameObject cube_Ads6 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads6.transform.position = new Vector3(sceneRoom.Walls[7].transform.position.x, sceneRoom.Walls[7].transform.position.y, sceneRoom.Walls[7].transform.position.z);
                    cube_Ads6.transform.localScale = new Vector3(0.1f, 2.5f, 3.5f);
                    cube_Ads6.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_6 = new Texture2D(0, 0);
                    string PATH6 = "Image/nike001";
                    texture_6 = Resources.Load<Texture2D>(PATH6);

                    var rend6 = cube_Ads6.GetComponent<MeshRenderer>();
                    rend6.material.mainTexture = texture_6;

                    cube_Ads6.transform.Rotate(0.0f, 0.0f, 0.0f);

                    //--------------------------------------------------------------------------------------
                    GameObject cube_Ads6_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads6_2.transform.position = new Vector3(sceneRoom.Walls[7].transform.position.x, sceneRoom.Walls[7].transform.position.y, sceneRoom.Walls[7].transform.position.z + 2.7f);
                    cube_Ads6_2.transform.localScale = new Vector3(0.1f, 0.7f, 1.2f);
                    cube_Ads6_2.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);
                                        
                    var rend6_2 = cube_Ads6_2.GetComponent<MeshRenderer>();
                    rend6_2.material.mainTexture = texture_6;

                    cube_Ads6.transform.Rotate(0.0f, 0.0f, 0.0f);
                    //=========================================================================================
                    */
                    
                }
                else
                { Debug.Log("Empty Room"); }


                activateGo = false;
            }


            if (sceneRoom != null)
            {
                var classifications = sceneRoom.GetComponentsInChildren<OVRSemanticClassification>(true);

                var cornerPoints = GetClockwiseFloorOutline(sceneRoom);
                var volumes = new List<OVRSceneVolume>();
                var planes = new List<OVRScenePlane>();

                var ceilingHeight = sceneRoom.Ceiling.transform.position.y - sceneRoom.Floor.transform.position.y;

                var rotationRoom = Quaternion.FromToRotation(Vector3.up, new Vector3(0, 0, 0));
                /*
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x + 2.5f, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z - 3), rotationRoom, new Vector3(2, 0.07f, 1), Color.white);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x + 2.5f, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z - 2), rotationRoom, new Vector3(2, 0.07f, 1), Color.cyan);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x + 2.5f, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z - 1), rotationRoom, new Vector3(2, 0.07f, 1), Color.magenta);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x + 2.5f, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z), rotationRoom, new Vector3(2, 0.07f, 1), Color.blue);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x + 1, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z + 0.5f), rotationRoom, new Vector3(1, 0.07f, 2), Color.red);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z), rotationRoom, new Vector3(1, 0.07f, 1), Color.white);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Ceiling.transform.position.x - 1.5f, sceneRoom.Ceiling.transform.position.y, sceneRoom.Ceiling.transform.position.z - 1), rotationRoom, new Vector3(2, 0.07f, 3), Color.blue);
                
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x + 2.5f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z - 1), rotationRoom, new Vector3(2, 0.07f, 1), Color.magenta);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x + 0.5f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z - 1), rotationRoom, new Vector3(2, 0.07f, 1), Color.white);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x + 1, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.5f), rotationRoom, new Vector3(1, 0.1f, 2), Color.red);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z), rotationRoom, new Vector3(1, 0.1f, 1), Color.white);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x - 1.5f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z - 1), rotationRoom, new Vector3(2, 0.07f, 3), Color.blue);

                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x - 3.8f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z - 2.7f), rotationRoom, new Vector3(0.05f, 3, 1), Color.cyan);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x - 3.8f, sceneRoom.Floor.transform.position.y + 2, sceneRoom.Floor.transform.position.z - 2.7f), rotationRoom, new Vector3(0.05f, 2, 1), Color.yellow);
                XRGizmos.DrawCube(new Vector3(sceneRoom.Floor.transform.position.x - 4.3f, sceneRoom.Floor.transform.position.y + 2, sceneRoom.Floor.transform.position.z - 2.15f), rotationRoom, new Vector3(1, 2, 0.07f), Color.yellow);
                //XRGizmos.DrawCube(new Vector3(sceneRoom.Walls.transform.position.x, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z), rotationRoom, new Vector3(1, 0.5f, 1), Color.red);
                */
            }

// luke end

            XRGizmos.DrawPointer(leftHand.position, leftHand.forward, Color.blue, 0.2f);
            XRGizmos.DrawPointer(rightHand.position, rightHand.forward, Color.red, 0.2f);
            /*
            var ray = new Ray(leftHand.position, leftHand.forward);

            TestSceneObjects(ray);

            ray = new Ray(rightHand.position, rightHand.forward);

            TestSceneObjects(ray);
            */


        }

        private void OnEnable()
        {
            SceneBoundsChecker.BoundsChanged += OnBoundsChanged;
        }

        private void OnDisable()
        {
            SceneBoundsChecker.BoundsChanged -= OnBoundsChanged;
        }

        private void OnBoundsChanged(Bounds bounds)
        {
            _sceneReady = true;
        }

        private readonly RaycastHit[] _raycastHits = new RaycastHit[256];


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

        private void TestSceneObjects(Ray ray)
        {
            var count = Physics.RaycastNonAlloc(ray, _raycastHits, 100.0f, _layerMask, QueryTriggerInteraction.Ignore);

            RaycastHit? globalMeshHit = null;
            Transform closest = null;
            Vector3 closestPoint = default;
            float closestDistance = float.MaxValue;
            OVRSemanticClassification closestClassification = null;

            for (int i = 0; i < count; i++)
            {
                var hit = _raycastHits[i];

                if (!_sceneClassifications.TryGetValue(hit.transform, out var classification))
                {
                    if (!hit.transform.TryGetComponent(out classification))
                    {
                        classification = hit.transform.GetComponentInParent<OVRSemanticClassification>();
                    }

                    _sceneClassifications[hit.transform] = classification;
                }

                if (classification == null)
                {
                    continue;
                }

                if (!globalMeshHit.HasValue && classification.Labels[0] == OVRSceneManager.Classification.GlobalMesh)
                {
                    globalMeshHit = hit;
                    continue;
                }

                if (hit.distance < closestDistance)
                {
                    closestClassification = classification;
                    closest = classification.transform;
                    closestDistance = hit.distance;
                    closestPoint = hit.point;
                }
            }

            if (closest != null)
            {
                var pos = closest.position;
                var direction = Vector3.ProjectOnPlane(pos - _head.position, Vector3.up).normalized;

                XRGizmos.DrawPoint(closestPoint, Color.white, 0.05f);
                XRGizmos.DrawAxis(closest, 0.15f, 0.006f);
                XRGizmos.DrawString(closestClassification.Labels[0], pos + new Vector3(0, 0.18f, 0), Quaternion.LookRotation(direction), Color.cyan, 0.05f, 0.1f, 0.004f);
            }

            if (globalMeshHit.HasValue)
            {
                var position = globalMeshHit.Value.point;
                var normal = globalMeshHit.Value.normal;

                var rotation = Quaternion.FromToRotation(Vector3.up, normal);

                XRGizmos.DrawCircle(position, rotation, 0.1f, MSPalette.Red);

                var angle = Vector3.Angle(Vector3.up, normal);
                var pointerColor = GetPointerColor(angle);
                XRGizmos.DrawPointer(position, normal, pointerColor, 0.15f, 0.005f);


                //Luke Start
                
                XRGizmos.DrawCube(position, rotation, new Vector3(0.5f, 0.01f, 0.5f), Color.cyan);

                //XRGizmos.DrawCube(closest.position, rotation, new Vector3(1, 0.02f, 4), Color.black);
                //XRGizmos.DrawCube(closest.localPosition, rotation, new Vector3(1, 0.02f, 1), Color.black);

            }

            Color GetPointerColor(float angle)
            {
                if (angle > 30 && angle < 120) return MSPalette.Yellow;

                if (angle >= 120) return MSPalette.Red;

                return MSPalette.Lime;
            }
        }
    }
}
