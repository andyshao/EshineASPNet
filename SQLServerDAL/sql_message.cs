﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SQLServerDAL
{
    class sql_message:IDAL.messageDal
    {
        DBunit.SQLAccess sql = new DBunit.SQLAccess();
        DateTime baddate = DateTime.Parse("1900-01-01");
        sql_news nb = new sql_news();
        public int Add(Model.tab_message message)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_message values (");
            strsql.AppendFormat("N'{0}',", message.Sender);
            strsql.AppendFormat("N'{0}',", message.Receiver);
            strsql.AppendFormat("N'{0}',", message.Title);
            strsql.AppendFormat("N'{0}',", message.Msg);
            strsql.AppendFormat("N'{0}',", message.Status);
            strsql.AppendFormat("{0},", message.MessageDate == baddate ? "null" : "'" + message.MessageDate.ToString() + "'");
            strsql.AppendFormat("{0}", message.MCommonid);
            strsql.Append(")");
            return sql.ExecuteNonQuery(strsql.ToString());
        }


        public Model.tab_message getmessage(Model.tab_message message1)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from tab_message where ");
            strsql.AppendFormat("Messageid='{0}'", message1.Messageid);
            DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];
            if (dt.Rows.Count < 1) return null;

            Model.tab_message message = new Model.tab_message();
            message.Sender = dt.Rows[0]["Sender"].ToString();
            message.Receiver = dt.Rows[0]["Receiver"].ToString();
            message.Title = dt.Rows[0]["Title"].ToString();
            message.Msg = dt.Rows[0]["Msg"].ToString();
            message.Status = dt.Rows[0]["Status"].ToString();
            message.MessageDate = dt.Rows[0]["MessageDate"].ToString() == "" ? baddate : DateTime.Parse(dt.Rows[0]["MessageDate"].ToString());
            message.MCommonid = int.Parse(dt.Rows[0]["MCommonid"].ToString());
            return message;
        }


        public int update(Model.tab_message message)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_message set ");
            strsql.AppendFormat(" Sender =N'{0}',", message.Sender);
            strsql.AppendFormat(" Receiver =N'{0}',", message.Receiver);
            strsql.AppendFormat(" Title =N'{0}',", message.Title);
            strsql.AppendFormat(" Msg =N'{0}',", message.Msg);
            strsql.AppendFormat(" Status =N'{0}',", message.Status);
            strsql.AppendFormat(" MessageDate ={0},", message.MessageDate == baddate ? "null" : "'" + message.MessageDate.ToString() + "'");
            strsql.AppendFormat(" MCommonid ='{0}'", message.MCommonid);
            strsql.AppendFormat(" where Messageid={0}", message.Messageid);
            return sql.ExecuteNonQuery(strsql.ToString());
        }

        public int markasread(string Messageid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update tab_message set ");
            strsql.AppendFormat(" Status =N'{0}'", "已读");
            strsql.AppendFormat(" where Messageid={0}", Messageid);
            return sql.ExecuteNonQuery(strsql.ToString());
        }

        public int Delete(int Messageid)
        {
            return sql.ExecuteNonQuery("delete from tab_message where Messageid=" + Messageid);
        }
        public DataTable Select(string ss)
        {
            return sql.ExecuteDataSet(ss).Tables[0];
        }



        public int systemMsg(int Receiver,string Title, string Msg)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into tab_message values (");
            strsql.AppendFormat("N'{0}',", "Medi-Plus");
            strsql.AppendFormat("N'{0}',", Receiver);
            strsql.AppendFormat("N'{0}',", Title);
            strsql.AppendFormat("N'{0}',", Msg);
            strsql.AppendFormat("N'{0}',", "");
            strsql.AppendFormat("'{0}',", DateTime.Now);
            strsql.AppendFormat("{0}", 0);
            strsql.Append(")");
            return sql.ExecuteNonQuery(strsql.ToString());
        }
        public int getmsgnum(int id, string additionalwhere)
        {
            return Convert.ToInt32(sql.ExecuteSc("select count(Receiver) from tab_message where Receiver="+id+additionalwhere));
        }
        public int getunread(int id)
        {
            return Convert.ToInt32(sql.ExecuteSc("select count(Receiver) from tab_message where (Status is null or Status!=N'已读') and Receiver=" + id));
        }
        public string  getmessage(int id)
        {
            return sql.ExecuteSc("select Msg from tab_message where Messageid=" + id).ToString();
        }
        public void sendmsg(int newsid, Model.tab_customers modelCu)
        {
            DataTable dtnews = nb.NewsSelect(newsid);
            string modmsg = dtnews.Rows[0]["msg"].ToString();
            modmsg = modmsg.Replace("<%客户姓名%>", modelCu.customerName);
            modmsg = modmsg.Replace("&lt;%客户姓名%&gt;", modelCu.customerName);
            systemMsg(modelCu.customerID, dtnews.Rows[0]["title"].ToString(), modmsg);
        }
    }
}
