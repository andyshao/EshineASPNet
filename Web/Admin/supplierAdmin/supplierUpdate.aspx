﻿<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="supplierUpdate.aspx.cs" Inherits="Admin_supplierAdmin_supplierUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td class="title" colspan="5">
                    供应商资料更新</td>
            </tr>
<tr>
                            <td align="center" style="width: 100px">
                               
                                        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="更　新" />
                                
                            </td>
          &nbsp;&nbsp;
                            <td colspan="2">
                                <input id="Button2" class="button" onclick="location='supplierinfo.aspx'" type="button" value="返　回" /></td>
          <br />
                            <td colspan="1">
                            </td>
                            <td colspan="1">
                            </td>
                        </tr>

        </table>
    </div><br>
      
            <table border="1" cellpadding="0" cellspacing="0" class="adminContent">
                <tr>
                    <td align="center" style="width: 100px; height: 26px;">
                        体检中心：</td>
                    <td style="width: 22px; height: 26px;">
                        <asp:TextBox ID="TextBox1" runat="server" Width="175px"></asp:TextBox></td>
                    <td align="center" style="width: 100px; height: 26px;" >
                       分店编码： </td>
                    <td style="width: 100px; height: 26px;" >
                        <asp:TextBox ID="TextBox9" runat="server" Width="175px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" style="width: 100px; height: 26px;">
                        省份：</td>
                    <td style="width: 22px">
                        <asp:TextBox ID="TextBox2" runat="server" Width="175px"></asp:TextBox></td>
                    <td align="center" style="width: 100px">
                        城市：</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox3" runat="server" Width="175px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" style="width: 100px; height: 26px;">
                        分店：</td>
                    <td style="width: 22px">
                        <asp:TextBox ID="TextBox7" runat="server" Width="175px"></asp:TextBox></td>
                    <td align="center" style="width: 100px">
                    联系电话：</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox6" runat="server" Width="175px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="width: 100px; height: 26px;">
                        地址：</td>
                    <td >
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Width="175px"></asp:TextBox></td>
                    <td align="center" valign="top">
                        类型：</td>
                    <td >
                        <asp:TextBox ID="TextBox10" runat="server" 
                            Width="175px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="width: 100px;">
                        备注：<br />这里填写的日期会被排除，例如填写星期一</td>
                    <td colspan="3" >
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Width="450px" TextMode="MultiLine" Height="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" valign="top" style="width: 100px; height: 26px;">
                        lat：</td>
                    <td >
                        <asp:TextBox ID="TextBox11" runat="server" 
                            Width="175px"></asp:TextBox></td>
                    <td align="center" valign="top">
                        lng：</td>
                    <td >
                        <asp:TextBox ID="TextBox12" runat="server" 
                            Width="175px"></asp:TextBox></td>
                </tr>
               <tr>
                    <td align="center" valign="top">
                        地图：</td>
                    <td colspan="3" >
                        <asp:TextBox ID="TextBox8" runat="server" 
                            Width="400px" Visible="false"></asp:TextBox>
                        <asp:HyperLink ID="HyperLink1" runat="server"  Target="_blank">预览</asp:HyperLink>
                        <asp:Button ID="Button3" runat="server" Text="预览" onclick="Button3_Click" Visible="false"/>
                        <asp:Panel ID="Panel1" runat="server" 
                            ScrollBars="Auto" Width="680px">
                        
                        </asp:Panel>
                            </td>
                </tr>
                
            </table>
       
    </form>
</body>
</html>
