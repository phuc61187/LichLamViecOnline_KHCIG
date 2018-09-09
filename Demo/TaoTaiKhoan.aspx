<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TaoTaiKhoan.aspx.cs" Inherits="Demo.TaoTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 181px;
        }
        .auto-style4 {
            width: 345px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">Tài khoản:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="tbUsername" ErrorMessage="Bạn chưa nhập thông tin."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Mật khẩu:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tbPass1" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ControlToValidate="tbPass1" ErrorMessage="Bạn chưa nhập thông tin."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Xác nhận mật khẩu:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tbPass2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidatorPass" runat="server" ControlToCompare="tbPass1" ControlToValidate="tbPass2" ErrorMessage="Mật khẩu chưa trùng khớp. Vui lòng nhập lại."></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="btTaoTK" runat="server" OnClick="btTaoTK_Click" Text="Lưu" />
                <asp:Button ID="btClearField" runat="server" OnClick="btClearField_Click" Text="Nhập lại thông tin" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
