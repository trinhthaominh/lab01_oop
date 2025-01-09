/* 
 **Lab 01 **
Trong quản lý sách ở thư viện, cản có các lớp đối tượng:
- Sách: mã sách, tên sách, tác giả, năm xuất bản, số lượng
- Dộc giả: mã độc giả, tên độc giả, địa chỉ, số điện thoại
- Phiều mượn: mã phiều nượn, mã độc giả, mã sách, ngày mượn,
 Hãy xây dựng chương trình quản lý với các chức năng:
 - Thêm sách, độc giả
 - Tim kiêm sách
 - Mượn và Trà sách

Xây dựng dưới dạng hướng thủ tục (các lớp đơn giản chỉ
chứa các thuộc tính, không chứa phương thức). Ngoài ra,
các biển lưu danh sách sách, độc giả, phiều nượn được
tổ chức dưới dạng biển toàn cục (hoặc ngang hàng với
class Progran, hoặc trực tiêp trong class Program).
 */





using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class Sach
    {
        public string maSach;
        public string tenSach;
        public string tacGia;
        public uint namXB;
        public uint sl;

    }
    
    public class DocGia
    {
        public string maDocGia;
        public string tenDocGia;
        public string diaChi;
        public string soDienThoai;
    }

    public class PhieuMuon
    {
        public Random maPhieuMuon;
        public string maDocGia;
        public string maSach;
        public DateTime ngayMuon;
    }


    internal class Program
    {
        
        public static List<Sach> dsSach = new List<Sach>();
        public static Sach NhapSach(string ms, string ts, string tg, uint nxb, uint sl)
        {
            var sachMoi = new Sach();
            sachMoi.maSach = ms;
            sachMoi.tenSach = ts;
            sachMoi.tacGia = tg;
            sachMoi.namXB = nxb;
            sachMoi.sl = sl;
            return sachMoi;
        }

        
        public static List<DocGia> dsDocGia = new List<DocGia>();
        public static DocGia NhapDocGia(string mdg, string tdg, string dc, string sdt)
        {
            var docGiaMoi = new DocGia();
            docGiaMoi.maDocGia = mdg;
            docGiaMoi.tenDocGia = tdg;
            docGiaMoi.diaChi = dc;
            docGiaMoi.soDienThoai = sdt;

            return docGiaMoi;
        }
        
        public static PhieuMuon MuonSach(string mdg, string ms)
        {
            var phieuMuon = new PhieuMuon();
            phieuMuon.maPhieuMuon = new Random();
            phieuMuon.ngayMuon = new DateTime();
            phieuMuon.maSach = ms.ToLower();
            phieuMuon.maDocGia = mdg.ToLower();

            return phieuMuon;
        }

        public static void InPhieuMuon(DocGia dg, PhieuMuon pms)
        {
            Console.WriteLine("=====Hóa đơn=====");
            Console.WriteLine($"DG: {dg.tenDocGia} - {dg.soDienThoai}");
         
                               
            Console.WriteLine("---");
        }

        public static PhieuMuon HandleMuonSach(DocGia mdg, List<Sach> dsS)
        {
            foreach (var sach in dsS)
            {
                var pm = MuonSach(mdg.maDocGia, sach.maSach);
                capNhatSLSach(sach.maSach, true);
                return pm;

            }

            return null;
        }

        // isMuon, muon la true, tra la false
        public static void capNhatSLSach(string ms, bool isMuon)
        {

            foreach (var sach in dsSach) 
            {
                if (ms == sach.maSach)
                {
                    if (isMuon)
                    {
                        sach.sl--;
                    } else
                    {
                        sach.sl++;
                    }
                }
                break;
            }
        }

        public static void TraSach(DocGia mdg, List<Sach> dsS)
        {
            foreach (var sach in dsS)
            {
                capNhatSLSach(sach.maSach, false);

            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Sach sach1 = NhapSach("01", "CSLT", "NQH", 2020, 100);
            dsSach.Add(sach1);
            Sach sach2 = NhapSach("02", "CSDL", "VTN", 2019, 100);
            dsSach.Add(sach2);
            Sach sach3 = NhapSach("03", "SWE", "NTH", 2015, 100);
            dsSach.Add(sach3);

            DocGia dg1 = NhapDocGia("AB01", "NVA", "BT", "0901234567");
            dsDocGia.Add(dg1);
            DocGia dg2 = NhapDocGia("AB02", "NVB", "TB", "0901234765");
            dsDocGia.Add(dg2);
            DocGia dg3 = NhapDocGia("AB03", "NVC", "PN", "0901432567");
            dsDocGia.Add(dg3);


            List<Sach> sachMuon = new List<Sach> { sach1 };
            var pm = HandleMuonSach(dg1 , sachMuon);

            foreach (var item in dsSach)
            {
                Console.WriteLine(item.tenSach);
                Console.WriteLine(item.sl);
            }

            Console.ReadLine();



        }
    }
}