using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

            }
            else {

            }
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            //1. get info
            DateTime dtNgay = ASPxDateEditNgaySuKien.Date;
            string strNoiDung = tbNoiDungSK.Text;
            DateTime dtTempGioBD = (DateTime)ASPxTimeEditStartTime.Value;
            TimeSpan timespanGioBatDau = new TimeSpan(dtNgay.Hour, dtNgay.Minute, 0);
            DateTime? dtDuration = (DateTime?)ASPxTimeEditDuration.Value;
            TimeSpan? timespanDuration = null;
            if (dtDuration != null) timespanDuration = new TimeSpan(dtDuration.Value.Hour, dtDuration.Value.Minute, 0);
            else timespanDuration = null;
            int idNguoiChuTri = 0;
            List<int> lstIDThanhPhanDu = new List<int>();
            string strDiaDiem, strDiaChi, strPhongHop;
            GetDiaDiemVaPhongHop(out strDiaDiem, out strDiaChi, out strPhongHop);

            //2. check condition

            //3. process

            //4. if fail

            //5. if success
        }

        private void GetDiaDiemVaPhongHop(out string strDiaDiem, out string strDiaChi, out string strPhongHop)
        {
            strDiaDiem = string.Empty;
            strDiaChi = string.Empty;
            strPhongHop = string.Empty;
            if (rdPhongHop1.Checked || rdPhongHop2.Checked) {
                strDiaDiem = @"Tại Nhà máy";
                strPhongHop = string.Format(@"Phòng họp {0}", (rdPhongHop1.Checked) ? "1" : "2");
            }
            else if (rdHoiTruong.Checked) {
                strDiaDiem = @"Tại Nhà máy";
                strPhongHop = @"Hội trường";
            }
            else if (rdVanPhongTCT.Checked) {
                strDiaDiem = @"Văn phòng Tổng Cty CNSG";
                strDiaChi = @"58-60 Nguyễn Tất Thành, P.12, Q.4";
                strPhongHop = tbPhongHopTCT.Text;
            }
            else if (rdNMConMeo.Checked) {
                strDiaDiem = @"NMTL Bến Thành CRAVEN A";
                strDiaChi = @"Lô D11-D18/II, Đường 5, KCN Vĩnh Lộc, P.Bình Hưng Hoà B, Q.Bình Tân";
                strPhongHop = tbPhongHopConMeo.Text;
            }
            else if (rdNoiKhac.Checked) {
                strDiaDiem = tbDiaDiemNoiKhac.Text;
                strDiaChi = tbDiaChiNoiKhac.Text;
                strPhongHop = tbPhongHopNoiKhac.Text;
            }
        }

        protected void rdPhongHop1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNoiKhac.Checked) {
                tbDiaDiemNoiKhac.Text = string.Empty;
                tbDiaChiNoiKhac.Text = string.Empty;
                tbPhongKhacNM.Text = string.Empty;
            }
            else if (rdPhongHop1.Checked){
                tbDiaDiemNoiKhac.Text = @"Tại NM";
                

            }
            
        }
    }
}