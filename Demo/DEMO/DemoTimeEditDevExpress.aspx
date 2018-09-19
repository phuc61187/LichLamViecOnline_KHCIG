<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoTimeEditDevExpress.aspx.cs" Inherits="Demo.DEMO.DemoTimeEditDevExpress" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 46px;
        }
        .auto-style3 {
            height: 46px;
            width: 183px;
        }
        .auto-style4 {
            width: 183px;
        }
        .auto-style6 {
            height: 46px;
            width: 369px;
        }
        .auto-style7 {
            width: 369px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">time
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit1" runat="server" DisplayFormatString="HH:mm" EditFormat="Custom" EditFormatString="HH:mm" OnDateChanged="ASPxTimeEdit1_DateChanged" OnValueChanged="ASPxTimeEdit1_ValueChanged" NullText="Nhập thời gian">
                    </dx:ASPxTimeEdit>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox1" runat="server" Height="125px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server" Height="125px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">duration<dx:ASPxTimeEdit ID="ASPxTimeEdit2" runat="server" DisplayFormatString="HH:mm" EditFormat="Custom" EditFormatString="HH:mm" OnDateChanged="ASPxTimeEdit2_DateChanged" OnValueChanged="ASPxTimeEdit2_ValueChanged">
                    </dx:ASPxTimeEdit>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox3" runat="server" Height="125px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox4" runat="server" Height="125px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
