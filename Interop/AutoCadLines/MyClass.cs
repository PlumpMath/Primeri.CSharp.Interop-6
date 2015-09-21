using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace AutoCadLines
{


    public class ACADLines
    {
        [CommandMethod("testLine")]
        public static void testLine()
        {
            List<point> points= new List<point>();
            points.Add(new point(0, 0));
            points.Add(new point(0, 10));
            points.Add(new point(10, 10));
            points.Add(new point(10, 0));
           
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.CurrentDocument; 
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Отваряне на блок таблицата за четене
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;

                // Отваряне на модела на блок таблицата за писсане
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;


                foreach (point _p in points)
                {
                    // Създаване на линия с координати
                    Line acLine = new Line(new Point3d(_p.x,_p.y, 0), new Point3d(0, 0, 0));
                     acLine.SetDatabaseDefaults();
                    
                    // Добавяне на линията
                 acBlkTblRec.AppendEntity(acLine);
                 acTrans.AddNewlyCreatedDBObject(acLine, true);
                }

//                // Създаване на линия с координати
//                Line acLine = new Line(new Point3d(5, 5, 0), new Point3d(12, 3, 0));
//                acLine.SetDatabaseDefaults();
//
//                // Добавяне на линията
//                acBlkTblRec.AppendEntity(acLine);
//                acTrans.AddNewlyCreatedDBObject(acLine, true);
//
//                // Запазване на прмените
//                acTrans.Commit();


            }
        }
        public class point
        {
            private int _x = 0, _y=0;
            public point(int __x, int __y)
            {
                _x = __x;
                _y = __y;

            }
            public int x
            {
                get {return _x;}
                set {_x = value;}
            }
            public int y
            {
                get {return _y;}
                set {_y = value;}
            }
        }

        public ACADLines()
        {
        }
    }
}

