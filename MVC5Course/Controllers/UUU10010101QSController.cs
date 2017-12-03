﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class UUU10010101QSController : Controller
    {
        private WANPIEEntities db = new WANPIEEntities();

        // GET: UUU10010101QS
        public ActionResult Index()
        {
            return View(db.UUU10010101.ToList());
        }

        // GET: UUU10010101QS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UUU10010101 uUU10010101 = db.UUU10010101.Find(id);
            if (uUU10010101 == null)
            {
                return HttpNotFound();
            }
            return View(uUU10010101);
        }

        // GET: UUU10010101QS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UUU10010101QS/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UNIQ_KEY,CORP_NO,BUSINESS_CORP_NO,BUSINESS_CORP_NAME_CHI,BUSINESS_CORP_ABBR_CHI,COMPANY_PERSON_TYPE_CODE,FACTORY_YN,CUSTOMER_YN,BUSINESS_CORP_NAME_ENG,BUSINESS_CORP_ABBR_ENG,INTER_EXT_TYPE_CODE,BUSINESS_UNIF_NO,EDI_NO,BUSINESS_TAX_NO,BUSINESS_SET_UP_DATE,BUSINESS_CORP_TYPE_CODE,BUSINESS_ITEM_TYPE_CODE,BUSINESS_ITEM_CODE,BUINESS_CAPITAL,BUSINESS_CHIEF_NAME,EMP_NUM,AREA_CODE,PARTY_YN,GROUP_NO_CORP_NO_YN,GROUP_NO_CORP_NO,ORG_TYPE_CODE,TRANSNATIONAL_YN,SHARES_CODE,CORPMODEL_TYPE_CODE,CORP_PUB_YYYYMM,CORP_TSE_YYYYMM,CORP_OTC_YYYYMM,GROUP_YN,VOUCHER_REMARK,CUS_TAX_INNER_TYPE_CODE,CUS_TAX_PERCENT,CUS_TRADE_COND_CODE,CUS_PAY_WAY_CODE,CUS_CURR_CODE,CUS_INVOICE_OR_ACCORD_TYPE_CODE,SA_FORMAT_TYPE_CODE,INVO_XTYPE_CODE,TRAN_CODE,MAKE_COLL_BUSINESS,INVOICE_FOR_BUSINESS,INVO_NAME_CHI,INVO_ADDR_CHI,SALE_GRADE_CODE,ROUTE_CODE,BELONG_TO_CODE,JOIN_SELF_TYPE_CODE,ORDER_MUST_YN,ORDER_YN,ATTACH_PAPER,SALE_CUST_PROD_NO_YN,CHECK_SHEET_SEND_CODE,CUS_INVOICE_BASS_CODE,CUS_INVOICE_DATE_BY_DATE,CUS_INVOICE_DATE_BY_WEEK,CUS_AR_BASS_CODE,CUS_AR_DATE_BY_DATE,CUS_AR_DATE_BY_WEEK,CUS_MAKE_COLL_BASS_CODE,CUS_MAKE_COLL_DATE_BY_DATE,CUS_MAKE_COLL_DATE_BY_WEEK,CUS_CASH_BASS_CODE,CUS_CASH_DATE_BY_DATE,CUS_CASH_DATE_BY_WEEK,CHEQ_PAY_DATE,CUS_BILL_PAY_DAYS,MAKE_COLL_CASE_CODE,MAKE_COLL_UNUSAL_REASON,BUSINESS_DISC_RATE,BUSINESS_START_DATE,BUSINESS_END_DATE,CRED_CONTAIN_GROUP,CRED_CHECK_POINT,CRED_CHECK_POINT_END,OVER_CRED_YN,CRED_AMT,CUS_BEGIN_BUSINESS_DATE,CUS_BUSINESS_STOP_DATE,CUS_BUSINESS_DISCOUNT_CODE,FAC_TAX_INNER_TYPE_CODE,FAC_TAX_PERCENT,FAC_TRADE_COND_CODE,FAC_PAY_WAY_CODE,FAC_CURR_CODE,FAC_INVOICE_OR_ACCORD_TYPE_CODE,IN_FORMAT_TYPE_CODE,PAY_COLL_BUSINESS,PUR_GRADE_CODE,PUR_CRED_CHECK_POINT_CODE,PUR_CRED_CHECK_POINT_END_CODE,OVER_PUR_CRED_YN,PUR_CRED_AMT,FAC_INVOICE_BASS_CODE,FAC_INVOICE_DATE_BY_DATE,FAC_INVOICE_DATE_BY_WEEK,FAC_AP_BASS_CODE,FAC_AP_DATE_BY_DATE,FAC_AP_DATE_BY_WEEK,FAC_MAKE_COLL_BASS_CODE,FAC_MAKE_COLL_DATE_BY_DATE,FAC_MAKE_COLL_DATE_BY_WEEK,FAC_CASH_BASS_CODE,FAC_CASH_DATE_BY_DATE,FAC_CASH_DATE_BY_WEEK,REMIT_MONEY_YN,REMIT_MONEY_BANK_ACCT_NO,REMIT_MONEY_BANK_NO,REMIT_MONEY_NAME,CUS_MONEY_YN,CUS_MONEY_BANK_ACCT_NO,CUS_MONEY_BANK_NO,CUS_MONEY_NAME,BILL_TITLE,PAY_CHEQ_PAY_DATE,PROC_COST_BURDEN_TYPE_CODE,FAC_BEGIN_BUSINESS_DATE,FAC_BUSINESS_STOP_DATE,FAC_BUSINESS_DISCOUNT_CODE,BUSINESS_TEL_NO,BUSINESS_FAX_NO,BUSINESS_WEB_NO,BUSINESS_EMAIL,BUSINESS_ZIP_ADDR_CODE,BUSINESS_ADDR_CHI,BUSINESS_ADDR_ENG,LIAISON_ZIP_ADDR_CODE,LIAISON_ADDR_CHI,LIAISON_NAME,LIAISON_ADDR_ENG,ACCOUNT_ZIP_ADDR_CODE,ACCOUNT_ADDR,BUSINESS_ACCT_NAME,BUSINESS_ACCT_TEL,BUSINESS_CASH_NAME,BUSINESS_CASH_TEL,DELI_ZIP_ADDR_CODE,DELI_ADDR,DELI_NAME,DELI_TEL,APPOINT_INVOICE_CORP_NO,CLIENT_PRICE_TACTIC,REPLY_STAMPS_YN,PROD_EXPECT_STORE_NO,CLOSE_YN,STOP_USE_DATE,DEL_YN,LIMITS_OF_AUTHORITY_CODE,DEPT_BOSS_ALLOW_YN,DEPT_BOSS_ALLOW_ID,DEPT_BOSS_ALLOW_DATE,ENTRY_ID,ENTRY_TIME,MODIFY_ID,MODIFY_TIME,ENTRY_TYPE,USC_FIELD_CHA_1,USC_FIELD_CHA_2,USC_FIELD_CHA_3,USC_FIELD_CHA_4,USC_FIELD_CHA_5,USC_FIELD_CHA_6,USC_FIELD_CHA_7,USC_FIELD_CHA_8,USC_FIELD_CHA_9,USC_FIELD_CHA_10,USC_FIELD_NUM_1,USC_FIELD_NUM_2,USC_FIELD_DATE_1,USC_FIELD_DATE_2,FIELD_CHA_1,FIELD_CHA_2,FIELD_CHA_3,FIELD_CHA_4,FIELD_CHA_5,FIELD_CHA_6,FIELD_CHA_7,FIELD_CHA_8,FIELD_CHA_9,FIELD_CHA_10,VOUCHXX_FIELD_CHA_1,VOUCHXX_FIELD_CHA_2,VOUCHXX_FIELD_CHA_3,VOUCHXX_FIELD_CHA_4,VOUCHXX_FIELD_CHA_5,VOUCHXX_FIELD_CHA_6,VOUCHXX_FIELD_CHA_7,VOUCHXX_FIELD_CHA_8,VOUCHXX_FIELD_CHA_9,VOUCHXX_FIELD_CHA_10,VOUCHXX_FIELD_CHA_11,VOUCHXX_FIELD_CHA_12,VOUCHXX_FIELD_CHA_13,VOUCHXX_FIELD_CHA_14,VOUCHXX_FIELD_CHA_15,VOUCHXX_FIELD_CHA_16,VOUCHXX_FIELD_NUM_1,VOUCHXX_FIELD_NUM_2,VOUCHXX_FIELD_NUM_3,VOUCHXX_FIELD_NUM_4,VOUCHXX_FIELD_NUM_5,VOUCHXX_FIELD_NUM_6,VOUCHXX_FIELD_NUM_7,VOUCHXX_FIELD_NUM_8,VOUCHXX_FIELD_DATE_1,VOUCHXX_FIELD_DATE_2,VOUCHXX_FIELD_DATE_3,VOUCHXX_FIELD_DATE_4,VOUCHXX_FIELD_DATE_5,VOUCHXX_FIELD_DATE_6,VOUCHXX_FIELD_DATE_7,VOUCHXX_FIELD_DATE_8,LIAISON_BUSINESS_TEL_NO,LIAISON_BUSINESS_FAX_NO,LABOR_IDENTITY_YN,LABOR_ID,EMP_ID,ZIP_PERM_ADDR_CODE,PERM_ADDR,BANK_NAME_ENG,SWIFT_CODE,NATION_TAIWAN_TAX_CODE,BANK_ADDR_ENG,SUB_FORMAT_TYPE,INVO35_TRANS_TYPE,BUSINESS_CORP_NO_KIND_1,BUSINESS_CORP_NO_KIND_2,BUSINESS_CORP_NO_KIND_3,BUSINESS_CORP_NO_KIND_4,BUSINESS_CORP_NO_KIND_5,BUSINESS_CORP_NO_KIND_6,BUSINESS_CORP_NO_KIND_7,BUSINESS_CORP_NO_KIND_8,BUSINESS_CORP_NO_KIND_9,BUSINESS_CORP_NO_KIND_10,CUST_GRADE,MAIL_THE_WAY,VIRTUAL_MASK_BANK_ACCT_NO,ISR_MIG_EMAIL,INVO_ZIP_ADDR_CODE")] UUU10010101 uUU10010101)
        {
            if (ModelState.IsValid)
            {
                db.UUU10010101.Add(uUU10010101);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uUU10010101);
        }

        // GET: UUU10010101QS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UUU10010101 uUU10010101 = db.UUU10010101.Find(id);
            if (uUU10010101 == null)
            {
                return HttpNotFound();
            }
            return View(uUU10010101);
        }

        // POST: UUU10010101QS/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UNIQ_KEY,CORP_NO,BUSINESS_CORP_NO,BUSINESS_CORP_NAME_CHI,BUSINESS_CORP_ABBR_CHI,COMPANY_PERSON_TYPE_CODE,FACTORY_YN,CUSTOMER_YN,BUSINESS_CORP_NAME_ENG,BUSINESS_CORP_ABBR_ENG,INTER_EXT_TYPE_CODE,BUSINESS_UNIF_NO,EDI_NO,BUSINESS_TAX_NO,BUSINESS_SET_UP_DATE,BUSINESS_CORP_TYPE_CODE,BUSINESS_ITEM_TYPE_CODE,BUSINESS_ITEM_CODE,BUINESS_CAPITAL,BUSINESS_CHIEF_NAME,EMP_NUM,AREA_CODE,PARTY_YN,GROUP_NO_CORP_NO_YN,GROUP_NO_CORP_NO,ORG_TYPE_CODE,TRANSNATIONAL_YN,SHARES_CODE,CORPMODEL_TYPE_CODE,CORP_PUB_YYYYMM,CORP_TSE_YYYYMM,CORP_OTC_YYYYMM,GROUP_YN,VOUCHER_REMARK,CUS_TAX_INNER_TYPE_CODE,CUS_TAX_PERCENT,CUS_TRADE_COND_CODE,CUS_PAY_WAY_CODE,CUS_CURR_CODE,CUS_INVOICE_OR_ACCORD_TYPE_CODE,SA_FORMAT_TYPE_CODE,INVO_XTYPE_CODE,TRAN_CODE,MAKE_COLL_BUSINESS,INVOICE_FOR_BUSINESS,INVO_NAME_CHI,INVO_ADDR_CHI,SALE_GRADE_CODE,ROUTE_CODE,BELONG_TO_CODE,JOIN_SELF_TYPE_CODE,ORDER_MUST_YN,ORDER_YN,ATTACH_PAPER,SALE_CUST_PROD_NO_YN,CHECK_SHEET_SEND_CODE,CUS_INVOICE_BASS_CODE,CUS_INVOICE_DATE_BY_DATE,CUS_INVOICE_DATE_BY_WEEK,CUS_AR_BASS_CODE,CUS_AR_DATE_BY_DATE,CUS_AR_DATE_BY_WEEK,CUS_MAKE_COLL_BASS_CODE,CUS_MAKE_COLL_DATE_BY_DATE,CUS_MAKE_COLL_DATE_BY_WEEK,CUS_CASH_BASS_CODE,CUS_CASH_DATE_BY_DATE,CUS_CASH_DATE_BY_WEEK,CHEQ_PAY_DATE,CUS_BILL_PAY_DAYS,MAKE_COLL_CASE_CODE,MAKE_COLL_UNUSAL_REASON,BUSINESS_DISC_RATE,BUSINESS_START_DATE,BUSINESS_END_DATE,CRED_CONTAIN_GROUP,CRED_CHECK_POINT,CRED_CHECK_POINT_END,OVER_CRED_YN,CRED_AMT,CUS_BEGIN_BUSINESS_DATE,CUS_BUSINESS_STOP_DATE,CUS_BUSINESS_DISCOUNT_CODE,FAC_TAX_INNER_TYPE_CODE,FAC_TAX_PERCENT,FAC_TRADE_COND_CODE,FAC_PAY_WAY_CODE,FAC_CURR_CODE,FAC_INVOICE_OR_ACCORD_TYPE_CODE,IN_FORMAT_TYPE_CODE,PAY_COLL_BUSINESS,PUR_GRADE_CODE,PUR_CRED_CHECK_POINT_CODE,PUR_CRED_CHECK_POINT_END_CODE,OVER_PUR_CRED_YN,PUR_CRED_AMT,FAC_INVOICE_BASS_CODE,FAC_INVOICE_DATE_BY_DATE,FAC_INVOICE_DATE_BY_WEEK,FAC_AP_BASS_CODE,FAC_AP_DATE_BY_DATE,FAC_AP_DATE_BY_WEEK,FAC_MAKE_COLL_BASS_CODE,FAC_MAKE_COLL_DATE_BY_DATE,FAC_MAKE_COLL_DATE_BY_WEEK,FAC_CASH_BASS_CODE,FAC_CASH_DATE_BY_DATE,FAC_CASH_DATE_BY_WEEK,REMIT_MONEY_YN,REMIT_MONEY_BANK_ACCT_NO,REMIT_MONEY_BANK_NO,REMIT_MONEY_NAME,CUS_MONEY_YN,CUS_MONEY_BANK_ACCT_NO,CUS_MONEY_BANK_NO,CUS_MONEY_NAME,BILL_TITLE,PAY_CHEQ_PAY_DATE,PROC_COST_BURDEN_TYPE_CODE,FAC_BEGIN_BUSINESS_DATE,FAC_BUSINESS_STOP_DATE,FAC_BUSINESS_DISCOUNT_CODE,BUSINESS_TEL_NO,BUSINESS_FAX_NO,BUSINESS_WEB_NO,BUSINESS_EMAIL,BUSINESS_ZIP_ADDR_CODE,BUSINESS_ADDR_CHI,BUSINESS_ADDR_ENG,LIAISON_ZIP_ADDR_CODE,LIAISON_ADDR_CHI,LIAISON_NAME,LIAISON_ADDR_ENG,ACCOUNT_ZIP_ADDR_CODE,ACCOUNT_ADDR,BUSINESS_ACCT_NAME,BUSINESS_ACCT_TEL,BUSINESS_CASH_NAME,BUSINESS_CASH_TEL,DELI_ZIP_ADDR_CODE,DELI_ADDR,DELI_NAME,DELI_TEL,APPOINT_INVOICE_CORP_NO,CLIENT_PRICE_TACTIC,REPLY_STAMPS_YN,PROD_EXPECT_STORE_NO,CLOSE_YN,STOP_USE_DATE,DEL_YN,LIMITS_OF_AUTHORITY_CODE,DEPT_BOSS_ALLOW_YN,DEPT_BOSS_ALLOW_ID,DEPT_BOSS_ALLOW_DATE,ENTRY_ID,ENTRY_TIME,MODIFY_ID,MODIFY_TIME,ENTRY_TYPE,USC_FIELD_CHA_1,USC_FIELD_CHA_2,USC_FIELD_CHA_3,USC_FIELD_CHA_4,USC_FIELD_CHA_5,USC_FIELD_CHA_6,USC_FIELD_CHA_7,USC_FIELD_CHA_8,USC_FIELD_CHA_9,USC_FIELD_CHA_10,USC_FIELD_NUM_1,USC_FIELD_NUM_2,USC_FIELD_DATE_1,USC_FIELD_DATE_2,FIELD_CHA_1,FIELD_CHA_2,FIELD_CHA_3,FIELD_CHA_4,FIELD_CHA_5,FIELD_CHA_6,FIELD_CHA_7,FIELD_CHA_8,FIELD_CHA_9,FIELD_CHA_10,VOUCHXX_FIELD_CHA_1,VOUCHXX_FIELD_CHA_2,VOUCHXX_FIELD_CHA_3,VOUCHXX_FIELD_CHA_4,VOUCHXX_FIELD_CHA_5,VOUCHXX_FIELD_CHA_6,VOUCHXX_FIELD_CHA_7,VOUCHXX_FIELD_CHA_8,VOUCHXX_FIELD_CHA_9,VOUCHXX_FIELD_CHA_10,VOUCHXX_FIELD_CHA_11,VOUCHXX_FIELD_CHA_12,VOUCHXX_FIELD_CHA_13,VOUCHXX_FIELD_CHA_14,VOUCHXX_FIELD_CHA_15,VOUCHXX_FIELD_CHA_16,VOUCHXX_FIELD_NUM_1,VOUCHXX_FIELD_NUM_2,VOUCHXX_FIELD_NUM_3,VOUCHXX_FIELD_NUM_4,VOUCHXX_FIELD_NUM_5,VOUCHXX_FIELD_NUM_6,VOUCHXX_FIELD_NUM_7,VOUCHXX_FIELD_NUM_8,VOUCHXX_FIELD_DATE_1,VOUCHXX_FIELD_DATE_2,VOUCHXX_FIELD_DATE_3,VOUCHXX_FIELD_DATE_4,VOUCHXX_FIELD_DATE_5,VOUCHXX_FIELD_DATE_6,VOUCHXX_FIELD_DATE_7,VOUCHXX_FIELD_DATE_8,LIAISON_BUSINESS_TEL_NO,LIAISON_BUSINESS_FAX_NO,LABOR_IDENTITY_YN,LABOR_ID,EMP_ID,ZIP_PERM_ADDR_CODE,PERM_ADDR,BANK_NAME_ENG,SWIFT_CODE,NATION_TAIWAN_TAX_CODE,BANK_ADDR_ENG,SUB_FORMAT_TYPE,INVO35_TRANS_TYPE,BUSINESS_CORP_NO_KIND_1,BUSINESS_CORP_NO_KIND_2,BUSINESS_CORP_NO_KIND_3,BUSINESS_CORP_NO_KIND_4,BUSINESS_CORP_NO_KIND_5,BUSINESS_CORP_NO_KIND_6,BUSINESS_CORP_NO_KIND_7,BUSINESS_CORP_NO_KIND_8,BUSINESS_CORP_NO_KIND_9,BUSINESS_CORP_NO_KIND_10,CUST_GRADE,MAIL_THE_WAY,VIRTUAL_MASK_BANK_ACCT_NO,ISR_MIG_EMAIL,INVO_ZIP_ADDR_CODE")] UUU10010101 uUU10010101)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uUU10010101).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uUU10010101);
        }

        // GET: UUU10010101QS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UUU10010101 uUU10010101 = db.UUU10010101.Find(id);
            if (uUU10010101 == null)
            {
                return HttpNotFound();
            }
            return View(uUU10010101);
        }

        // POST: UUU10010101QS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UUU10010101 uUU10010101 = db.UUU10010101.Find(id);
            db.UUU10010101.Remove(uUU10010101);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
