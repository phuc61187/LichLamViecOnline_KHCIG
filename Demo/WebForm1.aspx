<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Demo.WebForm1" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 189px;
        }
        .auto-style7 {
            width: 189px;
            height: 23px;
        }
        .auto-style8 {
            width: 189px;
            height: 43px;
        }
        .auto-style9 {
            height: 43px;
        }
        .auto-style11 {
            width: 189px;
            height: 25px;
        }
        .auto-style12 {
            height: 25px;
        }
        .auto-style17 {
            height: 43px;
            width: 153px;
        }
        .auto-style18 {
            height: 43px;
            width: 203px;
        }
        .auto-style19 {
            height: 43px;
            width: 112px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td colspan="3">
            <asp:Label ID="Label1" runat="server" Text="ĐĂNG KÝ LỊCH HỌP/LÀM VIỆC"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Label ID="Label2" runat="server" Text="Ngày đăng ký:"></asp:Label>
        </td>
        <td class="auto-style17">
            <dx:ASPxDateEdit ID="ASPxDateEditNgaySuKien" runat="server" EditFormat="Custom" NullText="Chọn ngày" AllowUserInput="False" DisplayFormatString="dd/M/yyyy dddd" EditFormatString="dd/M/yyyy">
                <ClearButton DisplayMode="OnHover">
                </ClearButton>
                <ValidationSettings>
                    <RequiredField ErrorText="Bạn chưa chọn ngày." IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxDateEdit>
        </td>
        <td class="auto-style19">
            <asp:Label ID="Label6" runat="server" Text="Bắt đầu lúc:"></asp:Label>
            <dx:ASPxTimeEdit ID="ASPxTimeEditStartTime" runat="server" DisplayFormatString="HH:mm" EditFormatString="HH:mm" NullText="Gõ giờ BĐ" Width="100px">
                <ClearButton DisplayMode="OnHover">
                </ClearButton>
                <ValidationSettings>
                    <RequiredField IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxTimeEdit>
        </td>
        <td class="auto-style18">
            <asp:Label ID="Label8" runat="server" Text="Ước lượng thời gian:"></asp:Label>
            <dx:ASPxTimeEdit ID="ASPxTimeEditDuration" runat="server" DisplayFormatString="HH 'giờ' mm 'phút'" EditFormat="Custom" EditFormatString="HH:mm" NullText="Gõ khoảng TG" Width="100px">
                <ClearButton DisplayMode="OnHover">
                </ClearButton>
            </dx:ASPxTimeEdit>
        </td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Label ID="Label3" runat="server" Text="Nội dung chính:"></asp:Label>
        </td>
        <td colspan="3">
            <dx:ASPxTextBox ID="tbNoiDungSK" runat="server" Height="47px" HorizontalAlign="Left" NullText="Nhập nội dung họp/làm việc" Width="520px">
            </dx:ASPxTextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Label ID="Label4" runat="server" Text="Người chủ trì:"></asp:Label>
        </td>
        <td class="auto-style12" colspan="3">
            <dx:ASPxGridLookup ID="ASPxGridNguoiChuTri" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DisplayFormatString="{1} ({4} {5})" KeyFieldName="ID" Width="500px">
<GridViewProperties>
<SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" AllowSelectByRowClick="True"></SettingsBehavior>
    <Settings ShowFilterBar="Visible" ShowFilterRow="True" />
</GridViewProperties>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LastName" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="MiddleName" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="FirstName" ShowInCustomizationForm="True" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="BPShortName" ShowInCustomizationForm="True" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CVName" ShowInCustomizationForm="True" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridLookup>
        </td>
        <td class="auto-style12">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Label ID="Label9" runat="server" Text="Thành phần dự:"></asp:Label>
        </td>
        <td class="auto-style12" colspan="3">
            <dx:ASPxGridLookup ID="ASPxGridThanhPhanDu" runat="server" Width="500px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
<GridViewProperties DataSourceForceStandardPaging="True">
<SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    <SettingsPager AlwaysShowPager="True" PageSize="2" Position="TopAndBottom">
    </SettingsPager>
    <SettingsResizing ColumnResizeMode="NextColumn" />
</GridViewProperties>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" Visible="False" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="MiddleName" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BPID" ReadOnly="True" Visible="False" VisibleIndex="5">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BPShortName" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CVID" ReadOnly="True" Visible="False" VisibleIndex="7">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CVName" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                </Columns>
                <ClearButton DisplayMode="Always">
                </ClearButton>
            </dx:ASPxGridLookup>
        </td>
        <td class="auto-style12">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            Địa điểm: </td>
        <td colspan="3">
            <dx:ASPxRadioButton ID="rdPhongHop1" runat="server" GroupName="LuaChonTaiNhaMay" Text="Phòng họp 1 NM" Checked="True" OnCheckedChanged="rdPhongHop1_CheckedChanged">
            </dx:ASPxRadioButton>
            <dx:ASPxRadioButton ID="rdPhongHop2" runat="server" GroupName="LuaChonTaiNhaMay" Text="Phòng họp 2 NM">
            </dx:ASPxRadioButton>
            <dx:ASPxRadioButton ID="rdHoiTruong" runat="server" GroupName="LuaChonTaiNhaMay" Text="Hội trường NM">
            </dx:ASPxRadioButton>
            <dx:ASPxRadioButton ID="rdPhongKhacNM" runat="server" GroupName="LuaChonTaiNhaMay" Text="Phòng khác tại Nhà máy:">
            </dx:ASPxRadioButton>
            <dx:ASPxTextBox ID="tbPhongKhacNM" runat="server" NullText="Tại:" Width="170px">
            </dx:ASPxTextBox>
            <dx:ASPxRadioButton ID="rdVanPhongTCT" runat="server" GroupName="LuaChonNgoaiNhaMay" Text="Văn phòng Tổng Cty CNSG">
            </dx:ASPxRadioButton>
            <dx:ASPxTextBox ID="tbPhongHopTCT" runat="server" NullText="Tại:" Width="170px">
            </dx:ASPxTextBox>
            <dx:ASPxRadioButton ID="rdNMConMeo" runat="server" GroupName="LuaChonNgoaiNhaMay" Text="NMTL Bến Thành Craven A">
            </dx:ASPxRadioButton>
            <dx:ASPxTextBox ID="tbPhongHopConMeo" runat="server" NullText="Tại:" Width="170px">
            </dx:ASPxTextBox>
            <dx:ASPxRadioButton ID="rdNoiKhac" runat="server" GroupName="LuaChonNgoaiNhaMay" Text="Nơi khác:">
            </dx:ASPxRadioButton>
            <dx:ASPxTextBox ID="tbDiaDiemNoiKhac" runat="server" NullText="Tại: " Width="170px">
            </dx:ASPxTextBox>
            Địa chỉ:<dx:ASPxTextBox ID="tbDiaChiNoiKhac" runat="server" NullText="Tại: " Width="170px">
            </dx:ASPxTextBox>
            Phòng họp:<dx:ASPxTextBox ID="tbPhongHopNoiKhac" runat="server" NullText="Tại:" Width="170px">
            </dx:ASPxTextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Label ID="Label10" runat="server" Text="Ghi chú:"></asp:Label>
        </td>
        <td colspan="3" class="auto-style12">
            <dx:ASPxTextBox ID="tbNoiDungSK0" runat="server" Height="47px" HorizontalAlign="Left" NullText="Nhập nội dung họp/làm việc" Width="520px">
            </dx:ASPxTextBox>
        </td>
        <td class="auto-style12">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11">
        </td>
        <td colspan="3" class="auto-style12">
            <dx:ASPxButton ID="btnDangKy" runat="server" Text="Đăng ký" OnClick="btnDangKy_Click">
            </dx:ASPxButton>
            <dx:ASPxButton ID="btnDong" runat="server" Text="Đóng">
            </dx:ASPxButton>
            <dx:ASPxButton ID="btnDangKyAndContinue" runat="server" Text="Đăng ký sự kiện này, sau đó đăng ký tiếp sự kiện khác">
            </dx:ASPxButton>
        </td>
        <td class="auto-style12"></td>
    </tr>
    <tr>
        <td class="auto-style6">
            &nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">
            &nbsp;</td>
        <td class="auto-style3" colspan="3">
            &nbsp;</td>
        <td class="auto-style3"></td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td colspan="3">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LichLamViecOnline_v1ConnectionString %>" SelectCommand="SELECT DSDoiTuong.ID, DSDoiTuong.LastName, DSDoiTuong.MiddleName, DSDoiTuong.FirstName, DMBoPhan.ID AS BPID, DMBoPhan.ShortName as BPShortName, DMChucVu.ID AS CVID, DMChucVu.Name as CVName FROM DSDoiTuong INNER JOIN DSDoiTuongBoPhan ON DSDoiTuong.ID = DSDoiTuongBoPhan.IDDoiTuong INNER JOIN DSDoiTuongChucVu ON DSDoiTuong.ID = DSDoiTuongChucVu.IDDoiTuong INNER JOIN DMBoPhan ON DSDoiTuongBoPhan.IDBoPhan = DMBoPhan.ID INNER JOIN DMChucVu ON DSDoiTuongChucVu.IDChucVu = DMChucVu.ID WHERE (DMBoPhan.Enable = 1) AND (DMChucVu.Enable = 1) AND (DSDoiTuong.Enable = 1)"></asp:SqlDataSource>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
