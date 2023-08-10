using UnityEngine;

namespace Core
{
    internal class Location
    {
        public GameObject Terrain;
        int Height = 50;
        float RndHeight = 25;
        float RndAmplitude = 5;
        int Width = 50;
        int RndHillsCount = 5;
        int MainTextureSize = 15;
        Vector3 rightEdgePosition;

        /*
        void GenerateMesh()
        {
            GameObject newTerrain = Instantiate(Terrain, new Vector3(rightEdgePosition.x, 0, 0), Quaternion.identity);

            Mesh pathMesh = newTerrain.GetComponent<MeshFilter>().mesh;

            Vector3[] vertices = newTerrain.GetComponent<MeshFilter>().sharedMesh.vertices;

            int v = Width / RndHillsCount;
            int step = 0;

            float a = GetRandomHeightPoint();
            vertices[0].y = rightEdgePosition.y;

            for (int i = 2; i < vertices.Length; i += 2)
            {
                if (step >= v)
                {
                    a = GetRandomHeightPoint();
                    step = 0;
                }

                vertices[i].y = Mathf.Lerp(vertices[i - 2].y, a, (float)step / v);

                step++;
            }

            rightEdgePosition = newTerrain.transform.localPosition + vertices[vertices.Length - 2];

            pathMesh.vertices = vertices;
            pathMesh.uv = GetMeshUv(vertices);
            pathMesh.RecalculateBounds();
            UpdateCollider2D();
        }

        float GetRandomHeightPoint()
        {
            float a = RndHeight - RndAmplitude;
            float b = RndHeight + RndAmplitude;

            if (a < 0.1f)
                a = 0.1f;
            if (b > Height)
                b = Height;

            return Random.Range(a, b);
        }

        Vector2[] GetMeshUv(Vector3[] vertices)
        {
            Vector2[] uv = new Vector2[vertices.Length];

            for (int i = 0; i < uv.Length; i += 2)
            {
                uv[i] = new Vector2((float)i / (uv.Length - 2) * MainTextureSize, (vertices[i].y / Height) * ((float)Height / Width) * MainTextureSize);
                uv[i + 1] = new Vector2((float)i / (uv.Length - 2) * MainTextureSize, (vertices[i + 1].y / Height) * ((float)Height / Width) * MainTextureSize);
            }

            return uv;
        }

        public void UpdateCollider2D()
        {
            if (GetComponent<EdgeCollider2D>() != null)
            {
                Vector3[] path = GetPath(Space.Self);
                Vector2[] colliderPath = new Vector2[path.Length];

                for (int i = 0; i < path.Length; i++)
                {
                    colliderPath[i] = path[i];
                }

                GetComponent<EdgeCollider2D>().points = colliderPath;
            }
        }

        public Vector3[] GetPath(Space relativeSpace)
        {
            Mesh terrainMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;

            if (terrainMesh == null)
                return null;

            Vector3[] path = new Vector3[terrainMesh.vertexCount / 2];
            int vertIndex = 0;
            if (relativeSpace == Space.Self)
            {
                for (int i = 0; i < terrainMesh.vertexCount; i += 2)
                {
                    path[vertIndex] = terrainMesh.vertices[i];
                    vertIndex++;
                }
            }
            else
            {
                for (int i = 0; i < terrainMesh.vertexCount; i += 2)
                {
                    path[vertIndex] = terrainMesh.vertices[i] + transform.position;
                    vertIndex++;
                }
            }

            return path;
        }
        */

        public void Update()
        {

        }
    }
}