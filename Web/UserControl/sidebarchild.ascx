﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sidebarchild.ascx.cs" Inherits="UserControl_sidebarchild" %>
<DIV class="sidebar_container sidebar_theme1">
<DIV class=sidebar_container_content_wrapper>
<DIV>
<SCRIPT>
    function sendemail(email) {
        window.location.href = "mailto:" + escape(email);
    }
		</SCRIPT>

<DIV class=sidebar_header><IMG alt="sidebar contact us icon" src="Images/icon_sidebar_contact_us.png" /> 
<P><asp:Label ID="Label1" runat="server" Text="联系我们" 
        meta:resourcekey="Label1Resource1"></asp:Label></P></DIV>
<DIV class=clearboth>&nbsp;</DIV>
<DIV class=sidebar_content_body>
<P>
    <asp:Label ID="Label2" runat="server" Text="热线电话" 
        meta:resourcekey="Label2Resource1"></asp:Label>：<STRONG>+86&nbsp;88888888 </STRONG></P>
<P>
    <asp:Label ID="Label3" runat="server" Text="服务时间" 
        meta:resourcekey="Label3Resource1"></asp:Label>：9:00-18:00<br />
    <asp:Label ID="Label5" runat="server" Text="周一到周五（节假日除外）" 
        meta:resourcekey="Label5Resource1"></asp:Label> </P>
<DIV class=fields>
<P class=formlabel>
    <asp:Label ID="Label4" runat="server" Text="邮箱地址" 
        meta:resourcekey="Label4Resource1"></asp:Label>:</P>
<P><A href="javascript:sendemail('service@eshinelee.com');">service@eshinelee.com</A></P></DIV></DIV></DIV></DIV></DIV>
