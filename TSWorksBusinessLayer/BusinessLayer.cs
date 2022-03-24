using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TSWorksDataAccessLayer;

namespace TSWorksBusinessLayer
{
    public class BusinessLayer
    {
        DataAccessLayer DAL;
        public BusinessLayer()
        {
            DAL = new DataAccessLayer();
        }

        public List<Models.AppleData> PostAppleData(List<Models.AppleData> appleDatas)
        {
            
            foreach(var row in appleDatas)
             DAL.PostAppleData(row.Date, row.Open, row.High, row.Low, row.Close, row.AdjClose, row.Volume);

            return appleDatas;
        }

        public List<Models.AppleData> GetAppleData(string date)
        {
            List<Models.AppleData> appleDataList = new List<Models.AppleData>();
            DataTable appleDataTable = new DataTable();
            appleDataTable = DAL.GetAppleData(date);
            try
            {
                
                foreach(DataRow appleDataRow in appleDataTable.Rows)
                {
                    Models.AppleData apple = new Models.AppleData();
                    apple.Date = appleDataRow["date"].ToString();
                    apple.Open = appleDataRow["open"].ToString();
                    apple.High = appleDataRow["high"].ToString();
                    apple.Low = appleDataRow["low"].ToString();
                    apple.Close = appleDataRow["close"].ToString();
                    apple.AdjClose = appleDataRow["adjclose"].ToString();
                    apple.Volume = appleDataRow["volume"].ToString();
                    appleDataList.Add(apple);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                appleDataList = null;
            }
            return appleDataList;
            
        }

        public List<Models.AppleData> GetAllAppleData()
        {
            List<Models.AppleData> appleDataList = new List<Models.AppleData>();
            DataTable appleDataTable = new DataTable();
            appleDataTable = DAL.GetAllAppleData();
            try
            {

                foreach (DataRow appleDataRow in appleDataTable.Rows)
                {
                    Models.AppleData apple = new Models.AppleData();
                    apple.Date = appleDataRow["date"].ToString();
                    apple.Open = appleDataRow["open"].ToString();
                    apple.High = appleDataRow["high"].ToString();
                    apple.Low = appleDataRow["low"].ToString();
                    apple.Close = appleDataRow["close"].ToString();
                    apple.AdjClose = appleDataRow["adjclose"].ToString();
                    apple.Volume = appleDataRow["volume"].ToString();
                    appleDataList.Add(apple);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                appleDataList = null;
            }
            return appleDataList;

        }

    }
}
