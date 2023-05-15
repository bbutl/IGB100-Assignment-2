using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    public float maskCutDistance = 0.1f;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public List<Transform> visibleTargets = new List<Transform>();
    public float meshResolution;
    
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInRadius.Length ; i++)
        {
            Transform target = targetsInRadius[i].transform;
            Vector3 DirectionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, DirectionToTarget) < viewAngle / 2)
            {
             float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, DirectionToTarget, distanceToTarget,
                    obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }

        }
    }
    public Vector3 DirectionFromAngle(float angle, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float distance;
        public float angle;

        public ViewCastInfo(bool hit_, Vector3 point_, float distance_, float angle_)
        {
            this.hit = hit_;
            this.point = point_;
            this.distance = distance_;
            this.angle = angle_;
        }

    }
    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 direction = DirectionFromAngle(globalAngle, true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + direction * viewRadius,
                viewRadius, globalAngle);
        }
    }
    void DrawFOV()
    {
        int rayCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAnglesize = viewAngle / rayCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i <= rayCount; i++) {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAnglesize * i;
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }
        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            if (i < vertexCount - 2)
            {
                vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + Vector3.forward * maskCutDistance;
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }
    // Start is called before the first frame update
    void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        StartCoroutine("FindTargetsWithDelay", .2f);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        DrawFOV();
    }
}
