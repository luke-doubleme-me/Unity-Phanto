// Copyright (c) Meta Platforms, Inc. and affiliates.

using Phanto.Audio.Scripts;
using Phanto.Enemies.DebugScripts;
using PhantoUtils;
using UnityEngine;
using Utilities.XR;
//luke S
using UnityEngine.UI;
//Luke E

namespace Phantom.EctoBlaster.Scripts
{
    public class EctoBlasterDemoSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject blasterPrefab;
        [SerializeField] private GameObject blasterPreviewPrefab;
        [SerializeField] private LayerMask meshLayerMask;

        [SerializeField] private Transform leftHand;
        [SerializeField] private Transform rightHand;

<<<<<<< Updated upstream
        [Tooltip("The radius to start tracking the target")]
        [SerializeField]
=======
        [Tooltip("The radius to start tracking the target")][SerializeField]
>>>>>>> Stashed changes
        private float trackingRadius = 1.0f;

        [SerializeField] private PhantoRandomOneShotSfxBehavior placeDownSFX;
        [SerializeField] private PhantoRandomOneShotSfxBehavior pickUpSFX;

        [SerializeField] private bool debugDraw = true;

        private OVRInput.Controller _activeController = OVRInput.Controller.RTouch;

        private GameObject _blaster;
        private GameObject _blasterPreview;

        private EctoBlasterDemoRadar _blasterRadar;
        private bool _isPlaced;

        private (Vector3 point, Vector3 normal, bool hit) _leftHandHit;
        private (Vector3 point, Vector3 normal, bool hit) _rightHandHit;



        //Luke S
        public Text Intro_Txt;
        public Image Image_A_type;
        public GameObject image;
        private bool activateGo = true;


        private const int count = 100;
        private bool createObject = false;
        public const int objectNumber = 0;
        public GameObject[] adsObject;

        //Luke E

        private void Start()
        {
            _blasterPreview = Instantiate(blasterPreviewPrefab, transform);
            _blaster = Instantiate(blasterPrefab, transform);
            _blaster.SetActive(false);

            _blasterRadar = _blaster.GetComponent<EctoBlasterDemoRadar>();
            _blasterRadar.TrackingRadius = trackingRadius;

            DebugDrawManager.DebugDraw = debugDraw;



            // Luke Start
            // Center of place
            // Center =================================================================

            GameObject cube_base0 = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube_base0.transform.position = new Vector3(0, 1, 0);
            cube_base0.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cube_base0.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);
            cube_base0.transform.Rotate(45.0f, 45.0f, 0);

            // ==========================================================================================

            GameObject cube_advertize0 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube_advertize0.transform.position = new Vector3(0, 2, 0);
            cube_advertize0.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cube_advertize0.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

            Texture2D texture_advertize0 = new Texture2D(0, 0);
            string PATHadvertize0 = "Image/soju002";
            texture_advertize0 = Resources.Load<Texture2D>(PATHadvertize0);

            var rendadvertize0 = cube_advertize0.GetComponent<MeshRenderer>();
            rendadvertize0.material.mainTexture = texture_advertize0;

            cube_advertize0.transform.Rotate(0.0f, 0.0f, 0.0f);
            //=================================================================================
        }

        private void Update()
        {
            var togglePlacement = false;
            const OVRInput.Button buttonMask = OVRInput.Button.PrimaryIndexTrigger | OVRInput.Button.PrimaryHandTrigger;

            if (OVRInput.GetDown(buttonMask, OVRInput.Controller.LTouch))
            {
                _activeController = OVRInput.Controller.LTouch;
                togglePlacement = true;
            }
            else if (OVRInput.GetDown(buttonMask, OVRInput.Controller.RTouch))
            {
                _activeController = OVRInput.Controller.RTouch;
                togglePlacement = true;
            }

            var leftRay = new Ray(leftHand.position, leftHand.forward);
            var rightRay = new Ray(rightHand.position, rightHand.forward);

            var leftRaySuccess = Physics.Raycast(leftRay, out var leftHit, 100.0f, meshLayerMask);
            var rightRaySuccess = Physics.Raycast(rightRay, out var rightHit, 100.0f, meshLayerMask);

            _leftHandHit = (leftHit.point, leftHit.normal, leftRaySuccess);
            _rightHandHit = (rightHit.point, rightHit.normal, rightRaySuccess);
            var active = _activeController == OVRInput.Controller.LTouch ? _leftHandHit : _rightHandHit;

            if (togglePlacement && active.hit) TogglePlacement(active.point, active.normal);

            if (!_isPlaced && active.hit)
            {
                // update the position of the preview to match the raycast.
                var blasterPreviewTransform = _blasterPreview.transform;

                blasterPreviewTransform.position = active.point;
                blasterPreviewTransform.up = active.normal;
            }

            // Luke start
            var sceneRoom = FindObjectOfType<OVRSceneRoom>();

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

                    GameObject cube_advertize1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize1.transform.position = new Vector3(sceneRoom.Floor.transform.position.x - 1f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.7f);
                    cube_advertize1.transform.localScale = new Vector3(2, 0.07f, 1.2F);
                    cube_advertize1.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize1 = new Texture2D(0, 0);
                    string PATHadvertize1 = "Image/supercar007";
                    texture_advertize1 = Resources.Load<Texture2D>(PATHadvertize1);

                    var rendadvertize1 = cube_advertize1.GetComponent<MeshRenderer>();
                    rendadvertize1.material.mainTexture = texture_advertize1;

                    cube_advertize1.transform.Rotate(0.0f, -90f, 0.0f);

                    // ==========================================================================================

                    GameObject cube_advertize2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize2.transform.position = new Vector3(sceneRoom.Floor.transform.position.x - 2.2f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.7f);
                    cube_advertize2.transform.localScale = new Vector3(2, 0.07f, 1.2F);
                    cube_advertize2.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize2 = new Texture2D(0, 0);
                    string PATHadvertize2 = "Image/supercar008";
                    texture_advertize2 = Resources.Load<Texture2D>(PATHadvertize2);

                    var rendadvertize2 = cube_advertize2.GetComponent<MeshRenderer>();
                    rendadvertize2.material.mainTexture = texture_advertize2;

                    cube_advertize2.transform.Rotate(0.0f, -90f, 0.0f);

                    // ==========================================================================================

                    GameObject cube_advertize3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube_advertize3.transform.position = new Vector3(sceneRoom.Floor.transform.position.x + 0.2f, sceneRoom.Floor.transform.position.y, sceneRoom.Floor.transform.position.z + 0.7f);
                    cube_advertize3.transform.localScale = new Vector3(2f, 0.07f, 1.2F);
                    cube_advertize3.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize3 = new Texture2D(0, 0);
                    string PATHadvertize3 = "Image/supercar003";
                    texture_advertize3 = Resources.Load<Texture2D>(PATHadvertize3);

                    var rendadvertize3 = cube_advertize3.GetComponent<MeshRenderer>();
                    rendadvertize3.material.mainTexture = texture_advertize3;

                    cube_advertize3.transform.Rotate(0.0f, -90f, 0.0f);


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
                    cube_advertize5.transform.position = new Vector3(sceneRoom.Walls[3].transform.position.x, sceneRoom.Walls[3].transform.position.y, sceneRoom.Walls[3].transform.position.z);
                    cube_advertize5.transform.localScale = new Vector3(0.05f, 1.5f, 1);
                    cube_advertize5.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_advertize5 = new Texture2D(0, 0);
                    string PATHadvertize5 = "Image/soju009";
                    texture_advertize5 = Resources.Load<Texture2D>(PATHadvertize5);

                    var rendadvertize5 = cube_advertize5.GetComponent<MeshRenderer>();
                    rendadvertize5.material.mainTexture = texture_advertize5;

                    cube_advertize5.transform.Rotate(0.0f, 0.0f, 0.0f);


                    // Advertizing pannel 1 =================================================================
                    GameObject cube_button = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_button.transform.position = new Vector3(sceneRoom.Walls[2].transform.position.x + 1, sceneRoom.Walls[2].transform.position.y, sceneRoom.Walls[2].transform.position.z);
                    cube_button.transform.localScale = new Vector3(1.5f, 2f, 0.05f);
                    cube_button.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);


                    Texture2D texture_A = new Texture2D(0, 0);
                    string PATH = "Image/soju004";
                    texture_A = Resources.Load<Texture2D>(PATH);

                    var rend = cube_button.GetComponent<MeshRenderer>();
                    rend.material.mainTexture = texture_A;

                    cube_button.transform.Rotate(0.0f, 180.0f, 0.0f);



                    // Advertizing pannel 1 =================================================================
                    GameObject cube_button30 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_button30.transform.position = new Vector3(sceneRoom.Walls[2].transform.position.x + 2.5f, sceneRoom.Walls[2].transform.position.y, sceneRoom.Walls[2].transform.position.z);
                    cube_button30.transform.localScale = new Vector3(1.5f, 2f, 0.05f);
                    cube_button30.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);


                    Texture2D texture_30 = new Texture2D(0, 0);
                    string PATH30 = "Image/soju008";
                    texture_30 = Resources.Load<Texture2D>(PATH30);

                    var rend30 = cube_button30.GetComponent<MeshRenderer>();
                    rend30.material.mainTexture = texture_30;

                    cube_button30.transform.Rotate(0.0f, 180.0f, 0.0f);


                    // Advertizing pannel 2 =================================================================
                    GameObject cube_Ads2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads2.transform.position = new Vector3(sceneRoom.Walls[5].transform.position.x, sceneRoom.Walls[5].transform.position.y, sceneRoom.Walls[5].transform.position.z);
                    cube_Ads2.transform.localScale = new Vector3(0.05f, 1.5f, 1);
                    cube_Ads2.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);


                    Texture2D texture_2 = new Texture2D(0, 0);
                    string PATH2 = "Image/CocaCola004";
                    texture_2 = Resources.Load<Texture2D>(PATH2);

                    var rend2 = cube_Ads2.GetComponent<MeshRenderer>();
                    rend2.material.mainTexture = texture_2;

                    cube_Ads2.transform.Rotate(0.0f, 180.0f, 0f);


                    // Advertizing pannel 3 =================================================================
                    GameObject cube_Ads3 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads3.transform.position = new Vector3(sceneRoom.Walls[6].transform.position.x + 2, sceneRoom.Walls[6].transform.position.y + 0.5f, sceneRoom.Walls[6].transform.position.z);
                    cube_Ads3.transform.localScale = new Vector3(1.5f, 1, 0.05f);
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
                    cube_Ads5.transform.localScale = new Vector3(1.5f, 1, 0.05f);
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
                    cube_Ads4.transform.localScale = new Vector3(1.5f, 1, 0.05f);
                    cube_Ads4.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_4 = new Texture2D(0, 0);
                    string PATH4 = "Image/poster04";
                    texture_4 = Resources.Load<Texture2D>(PATH4);

                    var rend4 = cube_Ads4.GetComponent<MeshRenderer>();
                    rend4.material.mainTexture = texture_4;

                    cube_Ads4.transform.Rotate(0.0f, 0.0f, 0.0f);

                    // Advertizing pannel 6 =================================================================
                    GameObject cube_Ads6 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    cube_Ads6.transform.position = new Vector3(sceneRoom.Walls[7].transform.position.x, sceneRoom.Walls[7].transform.position.y, sceneRoom.Walls[7].transform.position.z);
                    cube_Ads6.transform.localScale = new Vector3(0.05f, 2.5f, 3.5f);
                    cube_Ads6.GetComponent<MeshRenderer>().material.SetColor("Blue", Color.blue);

                    Texture2D texture_6 = new Texture2D(0, 0);
                    string PATH6 = "Image/nike001";
                    texture_6 = Resources.Load<Texture2D>(PATH6);

                    var rend6 = cube_Ads6.GetComponent<MeshRenderer>();
                    rend6.material.mainTexture = texture_6;

                    cube_Ads6.transform.Rotate(0.0f, 0.0f, 0.0f);

                    //--------------------------------------------------------------------------------------


                }
                else
                { Debug.Log("Empty Room"); }


                activateGo = false;
            }



        }
    

        private void OnEnable()
        {
            DebugDrawManager.DebugDrawEvent += DebugDraw;
        }

        private void OnDisable()
        {
            DebugDrawManager.DebugDrawEvent -= DebugDraw;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_blasterRadar != null) _blasterRadar.TrackingRadius = trackingRadius;
        }
#endif

        private bool shooting1 = false;

        //public object GameObjects { get => gameObjects; set => gameObjects = value; }

        private void TogglePlacement(Vector3 point, Vector3 normal)
        {
            if (_isPlaced)
            {
                _blaster.SetActive(false);
                _blasterPreview.SetActive(true);
                pickUpSFX.PlaySfxAtPosition(point);

                _isPlaced = false;
            }
            else
            {
                var blasterTransform = _blaster.transform;
                blasterTransform.position = point;
                blasterTransform.up = normal;

                _blaster.SetActive(true);
                _blasterPreview.SetActive(false);
                placeDownSFX.PlaySfxAtPosition(point);

                _isPlaced = true;

                // Luke s
                //if (shooting1 == false)
                //{
                // Advertizing pannel 6 =================================================================
                GameObject cube_shooting1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube_shooting1.transform.localScale = new Vector3(1f, 1f, 0.05f);
                cube_shooting1.transform.position = point;
                cube_shooting1.transform.up = normal;
                cube_shooting1.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);

                
                cube_shooting1.transform.Rotate(90f, 0.0f, 0f);
                
                if(point.x < 0 && point.z > 0)
                {
                    cube_shooting1.transform.Rotate(0f, 180f, 0.0f);
                }

                if (point.x > 0 && point.z > 0)
                {
                    cube_shooting1.transform.Rotate(0f, 180f, 0.0f);
                }
                


                Texture2D cube_texture1 = new Texture2D(0, 0);
                string PATHcube_texture1 = "Image/soju002";
                cube_texture1 = Resources.Load<Texture2D>(PATHcube_texture1);

                var cube_rend1 = cube_shooting1.GetComponent<MeshRenderer>();
                cube_rend1.material.mainTexture = cube_texture1;
                      

                               
            }

            //luke e
    }
     

        private void DebugDraw()
        {
            Color GetPointerColor(float angle)
            {
                if (angle > 30 && angle < 120) return MSPalette.Yellow;

                if (angle >= 120) return MSPalette.Red;

                return MSPalette.Lime;
            }

            if (_leftHandHit.hit)
            {
                var position = _leftHandHit.point;
                var rotation = Quaternion.FromToRotation(Vector3.up, _leftHandHit.normal);

                XRGizmos.DrawCircle(position, rotation, 0.15f, MSPalette.Blue);

                var angle = Vector3.Angle(Vector3.up, _leftHandHit.normal);
                var pointerColor = GetPointerColor(angle);
                XRGizmos.DrawPointer(position, _leftHandHit.normal, pointerColor, 0.3f, 0.005f);
            }

            if (_rightHandHit.hit)
            {
                var position = _rightHandHit.point;
                var rotation = Quaternion.FromToRotation(Vector3.up, _rightHandHit.normal);

                XRGizmos.DrawCircle(position, rotation, 0.15f, MSPalette.Red);

                var angle = Vector3.Angle(Vector3.up, _rightHandHit.normal);
                var pointerColor = GetPointerColor(angle);
                XRGizmos.DrawPointer(position, _rightHandHit.normal, pointerColor, 0.3f, 0.005f);
            }
        }
    }
}
