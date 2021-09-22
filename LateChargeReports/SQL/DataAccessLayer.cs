using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LateChargeReports.Models
{
    public class DataAccessLayer
    {
        public static Results GetData(DateTime startDate, DateTime endDate)
        {
            string FromBusinessDate = startDate.ToString("yyyy-MM-dd");
            string ToBusinessDate = endDate.ToString("yyyy-MM-dd");
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["LateCharges"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = BuildSQLCommand(FromBusinessDate, ToBusinessDate, cnn);
            Results queryResults = QueryDatabase(cnn, cmd, FromBusinessDate, ToBusinessDate);

            return queryResults;
        }

        private static SqlCommand BuildSQLCommand(string FromBusinessDate, string ToBusinessDate, SqlConnection cnn)
        {
            // Initialize SQL command
            SqlCommand cmd = new SqlCommand();

            // Configure SQL Command
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].SelectCLinesHcaWithExpectedPayCalculation";
            cmd.Parameters.Add(new SqlParameter("@FromBusinessDate", FromBusinessDate));
            cmd.Parameters.Add(new SqlParameter("@ToBusinessDate", ToBusinessDate));
            cmd.CommandTimeout = 0;

            return cmd;
        }

        private static Results QueryDatabase(SqlConnection cnn, SqlCommand cmd, string FromBusinessDate, string ToBusinessDate)
        {
            cnn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            Results sqlDataResults = new Results();
            sqlDataResults.QueryDates.StartDate = DateTime.ParseExact(FromBusinessDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            sqlDataResults.QueryDates.EndDate = DateTime.ParseExact(ToBusinessDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            while (sdr.Read())
            {
                sqlData dataInstance = GetFormattedData(sdr);

                sqlDataResults.DataList.Add(dataInstance);

            }

            cnn.Close();

            return sqlDataResults;
        }

        private static sqlData GetFormattedData(SqlDataReader sdr)
        {
            string Cpaj02EffectiveDate,
                    UnitNumber,
                    PatientNumber,
                    FieldCode,
                    NewData,
                    SnComment,
                    SendToCollections,
                    ShouldBeAutomated,
                    PreAutomationComment,
                    SystemComment,
                    IPlan,
                    PatType,
                    FC,
                    AdmitDate,
                    DischDate,
                    FbillDate,
                    EntDate,
                    DOS,
                    Status,
                    ProcCode,
                    RevCode,
                    ChargeDescription,
                    Quantity,
                    RunDate,
                    Q1,
                    Q2,
                    Q3,
                    Q4,
                    APC,
                    B,
                    Batch,
                    Department,
                    HCPCS,
                    RCode,
                    Proc,
                    PatName;

            decimal CurrentCalcExpectedPay,
                    PayerPayment,
                    CalcAnalysisExpectedPay,
                    Amount,
                    LateCharges,
                    PATotalCharges,
                    Ins1Pymt;

            double PercentChangeInReimbursement;

            Cpaj02EffectiveDate = Convert.ToString(sdr["Cpaj02EffectiveDate"]);
            UnitNumber = sdr["UnitNumber"].ToString();
            PatientNumber = sdr["PatientNumber"].ToString();
            FieldCode = sdr.IsDBNull(sdr.GetOrdinal("FieldCode")) ? null : sdr["FieldCode"].ToString();
            NewData = sdr["NewData"].ToString();
            SnComment = sdr["SnComment"].ToString();
            SendToCollections = sdr["SendToCollections"].ToString();
            CurrentCalcExpectedPay = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("CurrentCalcExpectedPay")) ? null : sdr["CurrentCalcExpectedPay"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            PayerPayment = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("PayerPayment")) ? null : sdr["PayerPayment"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            CalcAnalysisExpectedPay = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("CalcAnalysisExpectedPay")) ? null : sdr["CalcAnalysisExpectedPay"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            PercentChangeInReimbursement = Convert.ToDouble(sdr.IsDBNull(sdr.GetOrdinal("PercentChangeInReimbursement")) ? null : sdr["PercentChangeInReimbursement"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            ShouldBeAutomated = sdr["ShouldBeAutomated"].ToString();
            PreAutomationComment = sdr["PreAutomationComment"].ToString();
            SystemComment = sdr.IsDBNull(sdr.GetOrdinal("SystemComment")) ? null : sdr["SystemComment"].ToString();
            IPlan = sdr.IsDBNull(sdr.GetOrdinal("IPlan")) ? null : sdr["IPlan"].ToString();
            PatType = sdr.IsDBNull(sdr.GetOrdinal("Pat Type")) ? null : sdr["Pat Type"].ToString();
            FC = sdr.IsDBNull(sdr.GetOrdinal("FC")) ? null : sdr["FC"].ToString();
            AdmitDate = sdr.IsDBNull(sdr.GetOrdinal("Admit Date")) ? null : Convert.ToString(sdr["Admit Date"]);
            DischDate = sdr.IsDBNull(sdr.GetOrdinal("Disch Date")) ? null : Convert.ToString(sdr["Disch Date"]);
            FbillDate = sdr.IsDBNull(sdr.GetOrdinal("Fbill Date")) ? null : Convert.ToString(sdr["Fbill Date"]);
            EntDate = sdr.IsDBNull(sdr.GetOrdinal("ENTDATE")) ? null : Convert.ToString(sdr["ENTDATE"]);
            DOS = sdr.IsDBNull(sdr.GetOrdinal("DOS")) ? null : Convert.ToString(sdr["DOS"]);
            Amount = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("Amount")) ? null : sdr["Amount"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            Status = sdr.IsDBNull(sdr.GetOrdinal("Status")) ? null : sdr["Status"].ToString();
            ProcCode = sdr.IsDBNull(sdr.GetOrdinal("Proc Code")) ? null : sdr["Proc Code"].ToString();
            RevCode = sdr.IsDBNull(sdr.GetOrdinal("Rev Code")) ? null : sdr["Rev Code"].ToString();
            ChargeDescription = sdr.IsDBNull(sdr.GetOrdinal("Charge Description")) ? null : sdr["Charge Description"].ToString();
            Quantity = sdr.IsDBNull(sdr.GetOrdinal("Quantity")) ? null : sdr["Quantity"].ToString();
            RunDate = sdr.IsDBNull(sdr.GetOrdinal("RUNDATE")) ? null : Convert.ToString(sdr["RUNDATE"]);
            Q1 = sdr.IsDBNull(sdr.GetOrdinal("Q1")) ? null : sdr["Q1"].ToString();
            Q2 = sdr.IsDBNull(sdr.GetOrdinal("Q2")) ? null : sdr["Q2"].ToString();
            Q3 = sdr.IsDBNull(sdr.GetOrdinal("Q3")) ? null : sdr["Q3"].ToString();
            Q4 = sdr.IsDBNull(sdr.GetOrdinal("Q4")) ? null : sdr["Q4"].ToString();
            APC = sdr.IsDBNull(sdr.GetOrdinal("APC")) ? null : sdr["APC"].ToString();
            B = sdr.IsDBNull(sdr.GetOrdinal("B")) ? null : sdr["B"].ToString();
            Batch = sdr.IsDBNull(sdr.GetOrdinal("Batch")) ? null : sdr["Batch"].ToString();
            Department = sdr.IsDBNull(sdr.GetOrdinal("Department")) ? null : sdr["Department"].ToString();
            HCPCS = sdr.IsDBNull(sdr.GetOrdinal("HCPCS")) ? null : sdr["HCPCS"].ToString();
            RCode = sdr.IsDBNull(sdr.GetOrdinal("RCODE")) ? null : sdr["RCODE"].ToString();
            Proc = sdr.IsDBNull(sdr.GetOrdinal("Proc")) ? null : sdr["Proc"].ToString();
            PatName = sdr.IsDBNull(sdr.GetOrdinal("Pat Name")) ? null : sdr["Pat Name"].ToString();
            LateCharges = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("Late Charges")) ? null : sdr["Late Charges"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            PATotalCharges = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("PA Total Charges")) ? null : sdr["PA Total Charges"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            Ins1Pymt = Convert.ToDecimal(sdr.IsDBNull(sdr.GetOrdinal("Ins 1 Pymt")) ? null : sdr["Ins 1 Pymt"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

            sqlData dataInstance = new sqlData(Cpaj02EffectiveDate,
                                                UnitNumber,
                                                PatientNumber,
                                                FieldCode,
                                                NewData,
                                                SnComment,
                                                SendToCollections,
                                                CurrentCalcExpectedPay,
                                                PayerPayment,
                                                CalcAnalysisExpectedPay,
                                                PercentChangeInReimbursement,
                                                ShouldBeAutomated,
                                                PreAutomationComment,
                                                SystemComment,
                                                IPlan,
                                                PatType,
                                                FC,
                                                AdmitDate,
                                                DischDate,
                                                FbillDate,
                                                EntDate,
                                                DOS,
                                                Amount,
                                                Status,
                                                ProcCode,
                                                RevCode,
                                                ChargeDescription,
                                                Quantity,
                                                RunDate,
                                                Q1,
                                                Q2,
                                                Q3,
                                                Q4,
                                                APC,
                                                B,
                                                Batch,
                                                Department,
                                                HCPCS,
                                                RCode,
                                                Proc,
                                                PatName,
                                                LateCharges,
                                                PATotalCharges,
                                                Ins1Pymt);

            return dataInstance;
        }
    }
}