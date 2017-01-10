﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs" Inherits="forgotpassword" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register TagPrefix="MPuc" TagName="headcontent" Src="UserControl/headcontent.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="mobilenav" Src="UserControl/mobilenav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="desktopnav" Src="UserControl/desktopnav.ascx"%>
<%@ Register TagPrefix="MPuc" TagName="footer" Src="UserControl/footer1.ascx"%>
<!DOCTYPE html>
<html>
<head>
<title>EshineAspNet - <asp:Localize ID="Localize1" runat="server" Text='<%$ Resources:GResource,titletext %>'></asp:Localize></title>
<MPuc:headcontent runat="server" ID="Unnamed1"/>
<SCRIPT src="JS/mp.js" type="text/javascript"></SCRIPT>
</head>
<body class='signups'>
<MPuc:mobilenav runat="server" ID="Unnamed2"/>
<form runat="server">
<div class='wrapper' data-behavior='Navigation'>
<MPuc:desktopnav runat="server" ID="Unnamed3"/>

<div class='container signup'>
<div class="simple_form new_signup_context">
    <asp:Panel ID="Panel1" runat="server" class='choose_level tile'>
<div class='row'>
<div class='twelvecol'>
<h2><asp:Label ID="Label4" runat="server" Text="忘记密码" meta:resourcekey="Label4Resource1"></asp:Label></h2>
<h4 class='mobile_hidden'></h4>
</div>
</div>
<div class='row levels'>
<div class='onecol'></div>
<div class='level fourcol'>
 <asp:HyperLink ID="HyperLink3" class='button blue_button select' runat="server" NavigateUrl="~/fetchpassword.aspx" Text='<%$ Resources:GResource,throughworkemail %>'></asp:HyperLink>
</div>
<div class='level twocol'>
<asp:Button ID="Button12" runat="server" class='button blue_button select'  Text='<%$ Resources:GResource,throughsafequestion %>' onclick="Button12_Click" />
</div>
<div class='level fourcol '>
    <asp:HyperLink ID="HyperLink2" runat="server" class='button blue_button select' NavigateUrl="~/fetchpassword2.aspx" Text='<%$ Resources:GResource,throughphoneandid %>'></asp:HyperLink>
</div>
<div class='onecol last'></div>
</div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" class='signup_form tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h1><asp:Localize ID="Localize2" runat="server" Text='<%$ Resources:GResource,verifyok %>'></asp:Localize></h1>
<h4><asp:Label ID="Label14" runat="server" Text='<%$ Resources:GResource,sentpwtomobilemsg %>' ></asp:Label></h4>
</div>
</div>
<div class='row sizes'>
<div class='threecol'></div>
<div class='fivecol'>

<div class="input string required">
    <asp:HyperLink class="button blue_button" ID="HyperLink1" runat="server" NavigateUrl="~/login2.aspx" Text='<%$ Resources:GResource,back %>'></asp:HyperLink>
</div>

</div>
</div>
    </asp:Panel>

<asp:Panel ID="Panel3" runat="server" class='signup_form tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h1><asp:Label ID="Label2" runat="server" Text="确认私人邮箱" meta:resourcekey="Label5Resource1"></asp:Label></h1>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='threecol'></div>
<div class='fivecol'>

<div class="input string required">
    <asp:Label class="string required" ID="Label6" runat="server" Text="私人邮箱：" meta:resourcekey="Label6Resource1"></asp:Label>
    <asp:TextBox class="string email required" ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource1" type="email"></asp:TextBox>
</div>
<div class="input string required">
<asp:Button ID="Button5" runat="server" Text='<%$ Resources:GResource,cancel %>' class="button gray_button" onclick="Button4_Click" />
<asp:Button ID="Button2" runat="server" Text='<%$ Resources:GResource,confirm %>' class="button blue_button" onclick="Button2_Click" />
</div>

</div>
<div class='fourcol last'>
<ul class='selling_points mobile_hidden'>
<li>

</li>
</ul>
</div>
</div>

    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" class='signup_form tile' Visible="False">
<div class='row'>
<div class='twelvecol'>
<h1><asp:Label ID="Label13" runat="server" Text="验证安全提问" meta:resourcekey="Label7Resource1"></asp:Label></h1>
<h4></h4>
</div>
</div>
<div class='row sizes'>
<div class='threecol'></div>
<div class='fivecol'>

<div class="input string required">
    <asp:Label class="string required" ID="Label9" runat="server" Text="问题一：" meta:resourcekey="Label9Resource1"></asp:Label>
    <asp:Label class="string required" ID="Label1" runat="server" Text="Label" meta:resourcekey="Label1Resource1"></asp:Label>
</div>
<div class="input string required">
    <asp:Label class="string required" ID="Label8" runat="server" Text="　答案：" meta:resourcekey="Label8Resource1"></asp:Label>
    <asp:TextBox class="string required" ID="TextBox4" runat="server"  meta:resourcekey="TextBox4Resource1"></asp:TextBox>
</div>
<div class="input string required">
    <asp:Button ID="Button1" runat="server" Text='<%$ Resources:GResource,cancel %>' class="button gray_button" onclick="Button4_Click" />
    <asp:Button ID="Button3" runat="server" Text='<%$ Resources:GResource,confirm %>'   class="button blue_button" onclick="Button3_Click" 
        OnClientClick="return check2();" />
</div>

</div>
<div class='fourcol last'>
<ul class='selling_points mobile_hidden'>
<li>

</li>
</ul>
</div>
</div>

    </asp:Panel>

</div>
</div>

</div>
</form>
<MPuc:footer ID="ucfooter" runat="server"/>


<script>
 
    function check2() {
        var t1 = document.getElementById("<%=TextBox4.ClientID%>").value;
        if (t1 == "") {
            alert('<asp:Literal runat="server" Text="<%$ Resources:GResource,alertneedanswer%>" />');
            return false;
        }
        else
            return true;
    }

</script>
</body>
</html>
