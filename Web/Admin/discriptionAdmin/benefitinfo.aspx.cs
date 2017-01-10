﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
public partial class Admin_discriptionAdmin_benefitinfo : System.Web.UI.Page
{
    Bll.newsBll nb = new Bll.newsBll();
    Model.tab_news modelNb = new Model.tab_news();
    Bll.companyBll cb = new Bll.companyBll();
    string gs = "福利计划"; //global string
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            init();
        }
    }

    void init()
    {
        DataTable dt = nb.NewsSelect("SELECT title,title_eng,msg,msg_eng,link,link_eng FROM [tab_news] WHERE left(discription,4) =  '福利计划'");
        this.DropDownList1.Items.Clear();
        foreach (DataRow dr in dt.Rows)
        {
            if (Session["language"] != null && Session["language"].ToString() == "en-us")
            {
                this.DropDownList1.Items.Add(dr["title_eng"].ToString());
            }
            else
            {
                this.DropDownList1.Items.Add(dr["title"].ToString());
            }
        }
        if (dt.Rows.Count > 0)
        {
            if (Session["language"] != null && Session["language"].ToString() == "en-us")
            {
                content1.Value = dt.Rows[0]["msg_eng"].ToString();
                this.TextBox2.Text = dt.Rows[0]["link_eng"].ToString();
            }
            else
            {
                content1.Value = dt.Rows[0]["msg"].ToString();
                this.TextBox2.Text = dt.Rows[0]["link"].ToString();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox2.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请复制文件链接到[编辑链接]文本框！');</script>");
            return;
        }
        else if (!this.TextBox2.Text.ToLower().Contains(".pdf") || !System.IO.File.Exists(Server.MapPath("~/" + this.TextBox2.Text)))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('找不到文件链接！');</script>");
            return;
        }

        if (this.Button2.Text == "取消")//代表现在为新增状态
        {
            if (this.TextBox1.Text == "" || this.TextBox3.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('标题不能为空');</script>");
            }
            else
            {
                try
                {
                    modelNb.discription = gs +cb.getcompanyname( this.TextBox3.Text);
                    modelNb.title = this.TextBox1.Text;
                    modelNb.msg = content1.Value.Replace("'", "''");
                    modelNb.link = this.TextBox2.Text;
                    modelNb.time = DateTime.Now;
                    nb.NewsAdd(modelNb);
                    this.TextBox1.Text = "";
                    this.TextBox3.Text = "";
                    this.TextBox2.Text = "";
                    this.content1.Value = "";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('新增成功！');</script>");
                    //Response.Redirect("healthshopinfo.aspx", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('新增失败！" + ex.Message + "');</script>");
                }
            }
        }
        else
        {
            try
            {
                if (Session["language"] != null && Session["language"].ToString() == "en-us")
                {
                    modelNb.title_eng = DropDownList1.SelectedValue;
                    modelNb = nb.getNews(modelNb);
                    modelNb.link_eng = this.TextBox2.Text;
                    modelNb.msg_eng = content1.Value.Replace("'", "''");
                    modelNb.msg=modelNb.msg.Replace("'", "''");
                }
                else
                {
                    modelNb.title = DropDownList1.SelectedValue;
                    modelNb = nb.getNews(modelNb);
                    modelNb.link = this.TextBox2.Text;
                    modelNb.msg = content1.Value.Replace("'", "''");
                    modelNb.msg_eng = modelNb.msg_eng.Replace("'", "''");
                }
                

                nb.update(modelNb);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('更新成功！');</script>");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存失败！" + ex.Message + "');</script>");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.Button2.Text == "新增")
        {
            this.Button3.Visible = false;
            this.DropDownList1.Visible = false;
            this.Button2.Text = "取消";
            this.TextBox1.Visible = true;
            this.TextBox3.Visible = true;
            content1.Value = "";
            this.TextBox2.Text = "";
        }
        else
        {
            Response.Redirect("benefitinfo.aspx", true);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        modelNb = new Model.tab_news();
        if (Session["language"] != null && Session["language"].ToString() == "en-us")
        {
            modelNb.title_eng = DropDownList1.SelectedValue;
            modelNb = nb.getNews(modelNb);
            content1.Value = modelNb.msg_eng;
            this.TextBox2.Text = modelNb.link_eng;
        }
        else
        {
            modelNb.title = DropDownList1.SelectedValue;
            modelNb = nb.getNews(modelNb);
            content1.Value = modelNb.msg;
            this.TextBox2.Text = modelNb.link;
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        nb.Delete(gs, this.DropDownList1.SelectedValue);
        content1.Value = "";
        this.TextBox2.Text = "";
        this.DropDownList1.DataBind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {

                string filepath = FileUpload1.PostedFile.FileName;
                string ext = System.IO.Path.GetExtension(filepath).ToLower();
                if (ext == ".pdf")
                {
                    //string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    //上传该公司福利计划，首先要登陆该公司的测试号，否则Session["Company"]为null，报错
                    string filename ;

                    if (this.Button2.Text == "新增")
                    {
                        filename = this.DropDownList1.SelectedItem.Text + ".pdf";
                    }
                    else
                    {
                        filename = this.TextBox1.Text + ".pdf";
                    }

                    string serverpath = Server.MapPath("~/Images/files/") + filename;
                    FileUpload1.PostedFile.SaveAs(serverpath);
                    //this.lb_info.Text = "上传成功！";
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('上传成功');</script>");
                    this.TextBox2.Text = "Images/files/" + filename;
                }
                else
                {
                    //this.lb_info.Text = "请选择jpg文件";
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "message", " <script>alert('请选择pdf文件');</script>");
                }
            }
        }
        catch (Exception error)
        {
            this.lb_info.Text = "上传发生错误！原因：" + error.ToString();
        }
    }
}