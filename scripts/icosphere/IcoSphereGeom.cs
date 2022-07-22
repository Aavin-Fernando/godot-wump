using Godot;
using System;


public sealed class IcoSphereGeom : Node {

    private IcoSphereGeom() {
        GenerateGeometry();
        CreateAdjacencyGraph();
        GD.Print("IcoSphereGeom constructor called");
    }

    public static IcoSphereGeom Instance { get { 
       if (instance == null)
            instance = new IcoSphereGeom();
            return instance; } }

    public Godot.Collections.Array faces = new Godot.Collections.Array();

    public void GenerateGeometry() {

        Vector3[] lla = {
            new Vector3(0, -58.5f, 0),
            new Vector3(0, 58.5f, 0),
            new Vector3(180, 58.5f, 0),
            new Vector3(180, -58.5f, 0),
            new Vector3(90, -31.5f, 0),
            new Vector3(90, 31.5f, 0),
            new Vector3(-90, 31.5f, 0),
            new Vector3(-90, -31.5f, 0),
            new Vector3(-31.5f, 0, 0),
            new Vector3(31.5f, 0, 0),
            new Vector3(148.5f, 0, 0),
            new Vector3(-148.5f, 0, 0)
        };

        faces.Add(face_lla_xyz(lla[1], lla[2], lla[6]));
        faces.Add(face_lla_xyz(lla[1], lla[5], lla[2]));
        faces.Add(face_lla_xyz(lla[5], lla[10], lla[2]));
        faces.Add(face_lla_xyz(lla[2], lla[10], lla[11]));
        faces.Add(face_lla_xyz(lla[2], lla[11], lla[6]));
        faces.Add(face_lla_xyz(lla[7], lla[6], lla[11]));
        faces.Add(face_lla_xyz(lla[8], lla[6], lla[7]));
        faces.Add(face_lla_xyz(lla[8], lla[1], lla[6]));
        faces.Add(face_lla_xyz(lla[9], lla[1], lla[8]));
        faces.Add(face_lla_xyz(lla[9], lla[5], lla[1]));
        faces.Add(face_lla_xyz(lla[9], lla[4], lla[5]));
        faces.Add(face_lla_xyz(lla[4], lla[10], lla[5]));
        faces.Add(face_lla_xyz(lla[10], lla[4], lla[3]));
        faces.Add(face_lla_xyz(lla[10], lla[3], lla[11]));
        faces.Add(face_lla_xyz(lla[11], lla[3], lla[7]));
        faces.Add(face_lla_xyz(lla[0], lla[8], lla[7]));
        faces.Add(face_lla_xyz(lla[0], lla[9], lla[8]));
        faces.Add(face_lla_xyz(lla[4], lla[9], lla[0]));
        faces.Add(face_lla_xyz(lla[4], lla[0], lla[3]));
        faces.Add(face_lla_xyz(lla[3], lla[0], lla[7]));
    }




    public Vector3[] face_lla_xyz(Vector3 lla0, Vector3 lla1, Vector3 lla2) {
        Vector3 corner1 = SphereGeom.lla_to_xyz(lla0);
        Vector3 corner2 = SphereGeom.lla_to_xyz(lla1);
        Vector3 corner3 = SphereGeom.lla_to_xyz(lla2);

        Godot.Collections.Array<Vector3> _corners = 
            new Godot.Collections.Array<Vector3>();
        Vector3[] corners = new Vector3[3];
        
        _corners.Add(corner1);
        _corners.Add(corner2);
        _corners.Add(corner3);

        // Godot.Collections.Array _arrayofarray = new Godot.Collections.Array();

        // _arrayofarray.Resize( (int) ArrayMesh.ArrayType.Max);
        // _arrayofarray[ (int) ArrayMesh.ArrayType.Vertex ] = _corners;
        
        // _array_mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles,_arrayofarray);

        _corners.CopyTo(corners,0);
        return corners;
    }
        

    public bool is_adjacent( 
        Godot.Collections.Array face1, Godot.Collections.Array face2) {
            int common = 0;

            // check for shared points
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    if ( face1[i] == face2[j] ) {
                        common ++;
                    }
                }
            }
            return (common == 2);
    }

    public bool is_adjacent( 
        Vector3[] face1, Vector3[] face2) {
            int common = 0;

            // check for shared points
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    if ( face1[i] == face2[j] ) {
                        common ++;
                    }
                }
            }
            return (common == 2);
    }


    public void CreateAdjacencyGraph() {
        // GameState _gamestate = GetNode<GameState>("/root/GameState");

        // if (_gamestate.adjacency != null) {
        //         GD.Print("adjacency graph already created");
        //         return;
        // } else {
        //     GD.Print("was not created");

        //     _gamestate.adjacency = new Godot.Collections.Array();
        //     _gamestate.adjacency.Resize(20);

        //     for (int i = 0; i < faces.Count; i++) {
        //         Godot.Collections.Array<int> _adj = new Godot.Collections.Array<int>();

        //         for (int j = 0; j < faces.Count; j++) {
        //             if(this.is_adjacent( (Vector3[]) faces[i], (Vector3[]) faces[j])){
        //                 _adj.Add(j);
        //             }
        //         }
                
                

        //         _gamestate.adjacency![i] = _adj;
        //     }

        //     if (_gamestate.debugMode) {
        //         // TODO: check for existence of adjacency and save compute
        //         // by only calculating ONCE
        //         GD.Print(_gamestate.adjacency);
        //         GD.Print("adjacency graph created");
        //     }
        // }
    }


}

