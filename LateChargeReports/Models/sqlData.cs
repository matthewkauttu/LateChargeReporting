using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LateChargeReports.Models
{
    public class sqlData
    {
        public sqlData(string Cpaj02EffectiveDate,
                            string UnitNumber,
                            string PatientNumber,
                            string FieldCode,
                            string NewData,
                            string SnComment,
                            string SendToCollections,
                            decimal CurrentCalcExpectedPay,
                            decimal PayerPayment,
                            decimal CalcAnalysisExpectedPay,
                            double PercentChangeInReimbursement,
                            string ShouldBeAutomated,
                            string PreAutomationComment,
                            string SystemComment,
                            string IPlan,
                            string PatType,
                            string FC,
                            string AdmitDate,
                            string DischDate,
                            string FbillDate,
                            string EntDate,
                            string DOS,
                            decimal Amount,
                            string Status,
                            string ProcCode,
                            string RevCode,
                            string ChargeDescription,
                            string Quantity,
                            string RunDate,
                            string Q1,
                            string Q2,
                            string Q3,
                            string Q4,
                            string APC,
                            string B,
                            string Batch,
                            string Department,
                            string HCPCS,
                            string RCode,
                            string Proc,
                            string PatName,
                            decimal LateCharges,
                            decimal PATotalCharges,
                            decimal Ins1Pymt
                            )
        {
            this.Cpaj02EffectiveDate = Cpaj02EffectiveDate.Split(' ')[0];
            this.UnitNumber = UnitNumber;
            this.PatientNumber = PatientNumber;
            this.FieldCode = FieldCode;
            this.NewData = NewData;
            this.SnComment = SnComment;
            this.SendToCollections = SendToCollections;
            this.CurrentCalcExpectedPay = 
            this.CurrentCalcExpectedPay = CurrentCalcExpectedPay;
            this.PayerPayment = PayerPayment;
            this.CalcAnalysisExpectedPay = CalcAnalysisExpectedPay;
            this.PercentChangeInReimbursement = PercentChangeInReimbursement;
            //this.PrcChaInReim_double = ParseDoubleOrReturnNull(PercentChangeInReimbursement);
            //this.FormattedPercent = FormatDoublePercent(PrcChaInReim_double);
            this.ShouldBeAutomated = ShouldBeAutomated;
            this.PreAutomationComment = PreAutomationComment;
            this.SystemComment = SystemComment;
            this.IPlan = IPlan;
            this.PatType = PatType;
            this.FC = FC;
            this.AdmitDate = AdmitDate.Split(' ')[0];
            this.DischDate = DischDate.Split(' ')[0];
            this.FbillDate = FbillDate.Split(' ')[0];
            this.EntDate = EntDate.Split(' ')[0];
            this.DOS = DOS.Split(' ')[0];
            this.Amount = Amount;
            this.Status = Status;
            this.ProcCode = ProcCode;
            this.RevCode = RevCode;
            this.ChargeDescription = ChargeDescription;
            this.Quantity = Quantity;
            this.RunDate = RunDate.Split(' ')[0];
            this.Q1 = Q1;
            this.Q2 = Q2;
            this.Q3 = Q3;
            this.Q4 = Q4;
            this.APC = APC;
            this.B = B;
            this.Batch = Batch;
            this.Department = Department;
            this.HCPCS = HCPCS;
            this.RCode = RCode;
            this.Proc = Proc;
            this.PatName = PatName;
            //this.PatName = FormatName(PatName);
            this.LateCharges = LateCharges;
            this.PATotalCharges = PATotalCharges;
            this.Ins1Pymt = Ins1Pymt;
        }

        public string Cpaj02EffectiveDate { get; set; }
        public string UnitNumber { get; set; }
        public string PatientNumber { get; set; }
        public string FieldCode { get; set; }
        public string NewData { get; set; }
        public string SnComment { get; set; }
        public string SendToCollections { get; set; }
        public decimal CurrentCalcExpectedPay { get; set; }
        public decimal PayerPayment { get; set; }
        public decimal CalcAnalysisExpectedPay { get; set; }
        public double PercentChangeInReimbursement { get; set; }
        public double PrcChaInReim_double { get; set; }
        public string FormattedPercent { get; set;  }
        public string ShouldBeAutomated { get; set; }
        public string PreAutomationComment { get; set; }
        public string SystemComment { get; set; }
        public string IPlan { get; set; }
        public string PatType { get; set; }
        public string FC { get; set; }
        public string AdmitDate { get; set; }
        public string DischDate { get; set; }
        public string FbillDate { get; set; }
        public string EntDate { get; set; }
        public string DOS { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string ProcCode { get; set; }
        public string RevCode { get; set; }
        public string ChargeDescription { get; set; }
        public string Quantity { get; set; }
        public string RunDate { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string APC { get; set; }
        public string B { get; set; }
        public string Batch { get; set; }
        public string Department { get; set; }
        public string HCPCS { get; set; }
        public string RCode { get; set; }
        public string Proc { get; set; }
        public string PatName { get; set; }
        public decimal LateCharges { get; set; }
        public decimal PATotalCharges { get; set; }
        public decimal Ins1Pymt { get; set; }

        private string FormatCurrency(string quantity)
        {
            if (quantity == null)
            {
                return null;
            }
            else
            {
                return "$" + quantity;
            }
        }

        private double ParseDoubleOrReturnNull(string percentString)
        {
            if (percentString == null)
            {
                return -1.0;
            }
            else
            {
                return double.Parse(percentString, CultureInfo.InvariantCulture);
            }
        }

        private string FormatDoublePercent(double changeInReimbursement)
        {
            if (changeInReimbursement == -1.0)
            {
                return null;
            }
            else
            {
                return changeInReimbursement.ToString("P", CultureInfo.InvariantCulture);
            }
            
        }

        private string FormatName(string patName)
        {
            string formattedName;

            formattedName = patName.Replace("\n", "").Replace("\r", "");
            formattedName = formattedName.Split(' ').ToString();

            return formattedName;
        }
    }
}