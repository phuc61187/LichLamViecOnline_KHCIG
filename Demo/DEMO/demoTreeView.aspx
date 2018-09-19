<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoTreeView.aspx.cs" Inherits="Demo.demoTreeView" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>TreeList</td>
                <td>
                    <dx:ASPxTreeList ID="ASPxTreeList1" runat="server" DataSourceID="SqlDataSource1" EnableTheming="True" Theme="Default" AutoGenerateColumns="False" KeyFieldName="ID" ParentFieldName="ParentID" PreviewFieldName="Preview">
                        <Columns>
                            <dx:TreeListTextColumn FieldName="Name" VisibleIndex="0">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="Preview" VisibleIndex="1">
                            </dx:TreeListTextColumn>
                            <dx:TreeListCommandColumn VisibleIndex="2">
                            </dx:TreeListCommandColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedNode="True" AutoExpandAllNodes="True" />
                        <SettingsPager Mode="ShowPager">
                        </SettingsPager>
                        <SettingsSelection Enabled="True" />
                    </dx:ASPxTreeList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LichLamViecOnline_v1ConnectionString %>" SelectCommand="SELECT * FROM [BOPHAN]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>TreeView</td>
                <td>
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" KeyFieldName="ID">
                        <Settings ShowGroupPanel="True" />
                        <Columns>
                            <dx:GridViewDataDateColumn FieldName="Date" ShowInCustomizationForm="True" VisibleIndex="3">
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="Name" ShowInCustomizationForm="True" VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="DateTime" ShowInCustomizationForm="True" VisibleIndex="2">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="NguoiChuTri" ShowInCustomizationForm="True" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DiaDiem" ShowInCustomizationForm="True" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="PhongHop" ShowInCustomizationForm="True" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:GridViewDataDateColumn>
                        </Columns>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LichLamViecOnline_v1ConnectionString %>" SelectCommand="SELECT * FROM [SuKien]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
