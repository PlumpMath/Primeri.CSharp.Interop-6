using System;
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

                // Създаване на линия с координати
                Line acLine = new Line(new Point3d(5, 5, 0), new Point3d(12, 3, 0));
                acLine.SetDatabaseDefaults();

                // Добавяне на линията
                acBlkTblRec.AppendEntity(acLine);
                acTrans.AddNewlyCreatedDBObject(acLine, true);

                // Запазване на прмените
                acTrans.Commit();


            }
        }
        public ACADLines()
        {
        }
    }
}

