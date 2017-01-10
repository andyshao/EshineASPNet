﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_discriptionAdmin_healthshopinfo : System.Web.UI.Page
{
    Bll.newsBll nb = new Bll.newsBll();
    Model.tab_news modelNb = new Model.tab_news();
    string gs = "健康商城"; //global string
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            content1.Value = nb.getfirst(gs,"msg");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.Button2.Text == "取消")//代表现在为新增状态
        {
            if (this.TextBox1.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('标题不能为空');</script>");
            }
            else
            {
                try
                {
                    modelNb.discription = gs;
                    modelNb.title = this.TextBox1.Text;
                    modelNb.msg = content1.Value.Replace("'", "''");
                    nb.NewsAdd(modelNb);
                    this.TextBox1.Text = "";
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
                modelNb.discription = gs;
                modelNb.title = DropDownList1.SelectedValue;
                modelNb = nb.getNews(modelNb);
                modelNb.msg = content1.Value.Replace("'", "''");
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
            content1.Value = "";
        }
        else
        {
            //this.DropDownList1.Visible = true;
            //this.TextBox1.Visible = false;
            //this.Button2.Text = "新增";
            Response.Redirect("healthshopinfo.aspx",true);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        modelNb.discription = gs;
        modelNb.title = DropDownList1.SelectedValue;
        modelNb = nb.getNews(modelNb);
        content1.Value = modelNb.msg;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        nb.Delete(gs, this.DropDownList1.SelectedValue);
        content1.Value = "";
        this.DropDownList1.DataBind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");
        //Response.Redirect("healthshopinfo.aspx", true);
    }
}