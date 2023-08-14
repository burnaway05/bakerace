using UnityEngine;

namespace Core
{
    internal class Terrain
    {
        const int Height = 50;
        const int Width = 50;
        const float RndHeight = 25;
        const float RndAmplitude = 3;
        const int RndHillsCount = 4;
        const int MainTextureSize = 15;

        private TerrainView _view;

        public Terrain(GameObject prefab, Vector3 position)
        {
            var obj = Object.Instantiate(prefab, position, Quaternion.identity);
            _view = obj.GetComponent<TerrainView>();
        }

        public void DeformMesh(Vector3 previousRightTop)
        {
            Mesh pathMesh = _view.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = _view.GetComponent<MeshFilter>().sharedMesh.vertices;

            int v = Width / RndHillsCount;
            int step = 0;

            float a = GetRandomHeight();
            vertices[0].y = previousRightTop.y;

            for (int i = 2; i < vertices.Length; i += 2)
            {
                if (step >= v)
                {
                    a = GetRandomHeight();
                    step = 0;
                }

                vertices[i].y = Mathf.Lerp(vertices[i - 2].y, a, (float)step / v);

                step++;
            }

            pathMesh.vertices = vertices;
            pathMesh.uv = GetMeshUV(vertices);
            pathMesh.RecalculateBounds();
            UpdateCollider2D();
        }

        float GetRandomHeight()
        {
            float a = RndHeight - RndAmplitude;
            float b = RndHeight + RndAmplitude;

            if (a < 0.1f)
            {
                a = 0.1f;
            }

            if (b > Height)
            {
                b = Height;
            }

            return Random.Range(a, b);
        }

        Vector2[] GetMeshUV(Vector3[] vertices)
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
            if (_view.GetComponent<EdgeCollider2D>() != null)
            {
                Vector3[] path = GetPath(Space.Self);
                Vector2[] colliderPath = new Vector2[path.Length];

                for (int i = 0; i < path.Length; i++)
                {
                    colliderPath[i] = path[i];
                }

                _view.GetComponent<EdgeCollider2D>().points = colliderPath;
            }
        }

        public Vector3[] GetPath(Space relativeSpace)
        {
            Mesh terrainMesh = _view.GetComponent<MeshFilter>().sharedMesh;

            if (terrainMesh == null)
            {
                return null;
            }

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
                    path[vertIndex] = terrainMesh.vertices[i] + _view.transform.position;
                    vertIndex++;
                }
            }

            return path;
        }

        public Vector3 GetRightTopVertex()
        {
            int vertices = _view.GetComponent<MeshFilter>().sharedMesh.vertices.Length;

            return _view.GetComponent<MeshFilter>().sharedMesh.vertices[vertices - 2];
        }

        public Vector3 GetRightBottomPosition()
        {
            int vertices = _view.GetComponent<MeshFilter>().sharedMesh.vertices.Length;

            return _view.transform.localPosition + _view.GetComponent<MeshFilter>().sharedMesh.vertices[vertices - 1];
        }

        public void DisableEnterTrigger()
        {
            _view.DisableTrigger();
        }
    }
}