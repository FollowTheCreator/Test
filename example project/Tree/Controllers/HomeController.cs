using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tree.Models;

namespace Tree.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Main()
        {
            // дерево
            List<OBJECT_CONSTRUCTION_TREE> mas = db.OBJECT_CONSTRUCTION_TREE.OrderBy(b => b.LVL).ThenBy(b => b.NAME).ToList();
            /////////

            // субъекты
            List<masfullnames_result1> qry = (db.Database.SqlQuery<masfullnames_result1>("SELECT CAST(((SELECT GET_SUB_OBJECT_NAME.NAME FROM GET_SUB_OBJECT_NAME(SUB_OBJECT.ID)) || COALESCE(' №' || SUB_OBJECT.CONSTRUCTION_NUMBER, ''  )) AS VARCHAR(1000)) AS NAME,SUB_OBJECT.CODE AS CODE, QUALIFIER_OBJECT_CONSTRUCTION.NAME AS TYPE_SUB_OBJECT_NAME,SUB_OBJECT.ID,SUB_OBJECT.ALL_SCH_WORK_IS_COMPLETE,SUB_OBJECT.CONSTRUCTION_PERIOD,SUB_OBJECT.PERM_IDKNS_NUMBER,SUB_OBJECT.PERM_BUILDING_SITE_DATE_RECEIPT,SUB_OBJECT.PERM_BUILDING_SITE_EXPIRY_DATE,SUB_OBJECT.COMMISSIONIN_DATE, CAST ( SUB_OBJECT.COMMIS_DATE_COMMENT AS VARCHAR(1000) ) FROM QUALIFIER_OBJECT_CONSTRUCTION INNER JOIN SUB_OBJECT ON((QUALIFIER_OBJECT_CONSTRUCTION.ID = SUB_OBJECT.TYPE_SUB_OBJECT_ID)) order by code")).ToList();
            ///////////

            // доп инфо о субъектах
            List<subdata1> subData = new List<subdata1>();
            foreach (var one_qry in qry)
            {
                List<subdata1> sub = (db.Database.SqlQuery<subdata1>("SELECT GET_LAST_CONSTRACTION_TERM.DATE_RECEIPT, GET_LAST_CONSTRACTION_TERM.DATE_EXPIRY, CAST( GET_LAST_CONSTRACTION_TERM.FULL_NAME AS VARCHAR(1000) ) AS FULL_NAME, CAST( GET_LAST_CONSTRACTION_TERM.TEXT_COMMENT AS VARCHAR(1000) ) AS TEXT_COMMENT, CAST( GET_ALL_TYPE_SOUR_FIN.ALL_TYPE_SOUR_FIN AS VARCHAR(1000) ) AS ALL_TYPE_SOUR_FIN, GET_LAST_PERMISSION_ICW.DATE_RECEIPT AS DATE_RECEIPT1, GET_LAST_PERMISSION_ICW.DATE_EXPIRY AS DATE_EXPIRY1, CAST( GET_LAST_PERMISSION_ICW.TEXT_COMMENT AS VARCHAR(1000) ) AS COMMENT FROM GET_LAST_CONSTRACTION_TERM(" + one_qry.ID.ToString() + "), GET_ALL_TYPE_SOUR_FIN(" + one_qry.ID.ToString() + "), GET_LAST_PERMISSION_ICW(" + one_qry.ID.ToString() + ")")).ToList();
                foreach (var sub1 in sub)
                {
                    subData.Add(new subdata1() { DATE_RECEIPT = sub1.DATE_RECEIPT, DATE_EXPIRY = sub1.DATE_EXPIRY, FULL_NAME = sub1.FULL_NAME, TEXT_COMMENT = sub1.TEXT_COMMENT, ALL_TYPE_SOUR_FIN = sub1.ALL_TYPE_SOUR_FIN, DATE_RECEIPT1 = sub1.DATE_RECEIPT1, DATE_EXPIRY1 = sub1.DATE_EXPIRY1, COMMENT = sub1.COMMENT, ID = one_qry.ID});
                }
            }
            ////////////////////////

            // доп инфо о субъектах (для домов)
            List<subdata1_house> subData_house = new List<subdata1_house>();
            foreach (var one_qry in qry)
            {
                List<subdata1_house> sub = (db.Database.SqlQuery<subdata1_house>("SELECT HOUSE.BEGINNING_TECHNICAL_BREAK, HOUSE.TERMINATION_TECHNICAL_BREAK, HOUSE.MAX_COUNT_FLOORS, HOUSE.COUNT_APARTMENTS, HOUSE.TOTAL_AREA, HOUSE.SETTLING_DATE, TYPE_FOUNDATION.NAME, GET_ALL_SERIES_FOR_HOUSE.ALL_SERIES AS ALL_SERIES FROM HOUSE left join TYPE_FOUNDATION on (HOUSE.TYPE_FOUNDATION_ID=TYPE_FOUNDATION.ID), GET_ALL_SERIES_FOR_HOUSE(" + one_qry.ID.ToString() + ") where  house.id = " + one_qry.ID.ToString())).ToList();
                if (sub.Count != 0)
                {
                    foreach (var sub1 in sub)
                    {
                        subData_house.Add(new subdata1_house() { BEGINNING_TECHNICAL_BREAK = sub1.BEGINNING_TECHNICAL_BREAK, TERMINATION_TECHNICAL_BREAK = sub1.TERMINATION_TECHNICAL_BREAK, MAX_COUNT_FLOORS = sub1.MAX_COUNT_FLOORS, COUNT_APARTMENTS = sub1.COUNT_APARTMENTS, TOTAL_AREA = sub1.TOTAL_AREA, SETTLING_DATE = sub1.SETTLING_DATE, NAME = sub1.NAME, ALL_SERIES = sub1.ALL_SERIES, ID = one_qry.ID });
                    }
                }
                else
                {
                    subData_house.Add(new subdata1_house() { BEGINNING_TECHNICAL_BREAK = null, TERMINATION_TECHNICAL_BREAK = null, MAX_COUNT_FLOORS = null, COUNT_APARTMENTS = null, TOTAL_AREA = null, SETTLING_DATE = null, NAME = null, ALL_SERIES = null, ID = one_qry.ID });
                }
            }
            ////////////////////////////////////

            // доп инфо о субъектах (для встроенных помещений)
            List<subdata1_built_in_room> subData_built_in_room = new List<subdata1_built_in_room>();
            foreach (var one_qry in qry)
            {
                List<subdata1_built_in_room> sub = (db.Database.SqlQuery<subdata1_built_in_room>("SELECT BUILT_IN_ROOM.TOTAL_AREA, TYPE_FOUNDATION.NAME FROM BUILT_IN_ROOM, TYPE_FOUNDATION WHERE BUILT_IN_ROOM.TYPE_FOUNDATION_ID=TYPE_FOUNDATION.ID AND BUILT_IN_ROOM.ID=" + one_qry.ID.ToString())).ToList();
                List<subdata1_built_in_room> sub_sub = (db.Database.SqlQuery<subdata1_built_in_room>("SELECT CAST ( LIST((GET_SUB_OBJECT_NAME.NAME || COALESCE( ' №' || SUB_OBJECT.CONSTRUCTION_NUMBER, '' )), ', ') AS VARCHAR(1000)  ) AS HOUSE_NAME FROM BUILT_IN_ROOM LEFT JOIN L_BUILT_IN_ROOM_HOUSE ON((BUILT_IN_ROOM.ID = L_BUILT_IN_ROOM_HOUSE.BUILT_IN_ROOM_ID)) LEFT JOIN HOUSE ON((L_BUILT_IN_ROOM_HOUSE.HOUSE_ID = HOUSE.ID)) LEFT JOIN SUB_OBJECT ON((HOUSE.ID = SUB_OBJECT.ID)) LEFT JOIN GET_SUB_OBJECT_NAME(SUB_OBJECT.ID) ON((1 = 1)) WHERE (BUILT_IN_ROOM_ID = " + one_qry.ID.ToString() + ") GROUP BY BUILT_IN_ROOM_ID")).ToList();
                if (sub.Count != 0)
                {
                    subData_built_in_room.Add(new subdata1_built_in_room() { TOTAL_AREA = sub[0].TOTAL_AREA, NAME = sub[0].NAME, HOUSE_NAME= sub_sub[0].HOUSE_NAME, ID = one_qry.ID });
                }
                else
                {
                    subData_built_in_room.Add(new subdata1_built_in_room() { TOTAL_AREA = null, NAME = null, HOUSE_NAME = null, ID = one_qry.ID });
                }
            }
            ////////////////////////////////////

            // доп инфо о субъектах (для сопутствующих построек)
            List<subdata1_accompanying_construction> subData_accompanying_construction = new List<subdata1_accompanying_construction>();
            foreach (var one_qry in qry)
            {
                List<subdata1_accompanying_construction> sub = (db.Database.SqlQuery<subdata1_accompanying_construction>("SELECT TYPE_FOUNDATION.NAME FROM ACCOMPANYING_CONSTRUCTION LEFT JOIN TYPE_FOUNDATION ON ACCOMPANYING_CONSTRUCTION.TYPE_FOUNDATION_ID=TYPE_FOUNDATION.ID where ACCOMPANYING_CONSTRUCTION.id = " + one_qry.ID.ToString())).ToList();
                if (sub.Count != 0)
                {
                    foreach (var sub1 in sub)
                    {
                        subData_accompanying_construction.Add(new subdata1_accompanying_construction() { NAME = sub1.NAME, ID = one_qry.ID });
                    }
                }
                else
                {
                    subData_accompanying_construction.Add(new subdata1_accompanying_construction() { NAME = null, ID = one_qry.ID });
                }
            }
            ////////////////////////////////////

            // объекты
            List<objects_result1> qry1 = (db.Database.SqlQuery<objects_result1>("SELECT OBJECT_CONSTRUCTION.ID, CAST( OBJECT_CONSTRUCTION.FULL_NAME AS VARCHAR(1000) ) AS FULL_NAME, CUSTOMER.NAME AS CUSTOMER_NAME, OBJECT_CONSTRUCTION.CONTRACT_NUMBER, OBJECT_CONSTRUCTION.CONTRACT_DATE, CAST( OBJECT_CONSTRUCTION.CONTRACT_COMMENT AS VARCHAR(10000) ) AS COMMENT, MANAGEMENT.NAME AS MANAGEMENT_NAME FROM OBJECT_CONSTRUCTION INNER JOIN CUSTOMER ON(OBJECT_CONSTRUCTION.CUSTOMER_ID = CUSTOMER.ID) LEFT JOIN MANAGEMENT ON(OBJECT_CONSTRUCTION.GEN_MANAGEMENT_ID = MANAGEMENT.ID)")).ToList();
            //////////

            ViewBag.Objects = qry1; // объекты
            ViewBag.check = qry; // субъекты
            ViewBag.AddObjects = subData; // доп инфо о субъектах
            ViewBag.AddObjects_house = subData_house; // доп инфо о субъектах (для домов)
            ViewBag.AddObjects_built_in_room = subData_built_in_room; // доп инфо о субъектах (для встроенных помещений)
            ViewBag.AddObjects_accompanying_construction = subData_accompanying_construction; // доп инфо о субъектах (для сопутствующих построек)
            ViewBag.LengthSub = qry.Count();
            ViewBag.LengthSub1 = subData_house.Count();

            int maxlvl = 0;
            int lengthmas = 0;
            foreach (var i in mas)
            {
                if (maxlvl < i.LVL) maxlvl = Convert.ToInt32(i.LVL);
                lengthmas++;
            }
            int[] levelscount = new int[maxlvl + 1];
            for (int i = 0; i < lengthmas; i++)
            {
                for (int j = 0; j <= maxlvl; j++)
                {
                    if (mas[i].LVL == j) levelscount[j]++;
                }
            }
            int[] levels = new int[maxlvl + 2];
            int step = 0;
            levels[0] = 0;
            for (int j = 1; j <= maxlvl + 1; j++)
            {
                step += levelscount[j - 1];
                levels[j] = step;
            }
            ViewBag.Levels = levels; //////////
            ViewBag.MaxLvl = maxlvl; ////////// выборка информации о дереве и передача на view
            ViewBag.Mas = mas; ////////////////
            ViewBag.LengthMas = lengthmas; ////


            return View();
        }
    }
}