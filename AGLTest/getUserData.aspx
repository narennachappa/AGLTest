<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getUserData.aspx.cs" Inherits="AGLTest.getUserData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptMalePets" runat="server">
                <HeaderTemplate>
                    <ol class="Male" ><h3>Male</h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                       <%# Eval("name") %>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <ol />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Repeater ID="rptFemalePets" runat="server">
                <HeaderTemplate>
                    <ol class="Male" > <h3>Female</h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                       <%# Eval("name") %>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <ol />
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
