using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Buoi02

{
    public partial class Form1 : Form
    {
        //Định nghĩa class đối tưởng chứa các tham số cần truyền cho thread con
        class Params
        {
            //Đối tượng quản lý thread tương ứng
            public Thread t;
            //Hàng bắt đầu tính
            public int sr;
            //Hàng kết thúc tính + 1
            public int er;
            //Chỉ số thread trong danh sách quản lý
            public int id;
            public Params(Thread t, int s, int e, int i)
            {
                this.t = t;
                sr = s;
                er = e;
                id = i;
            }
        };
        //Định nghĩa 3 biến ma trận
        double[,] A;
        double[,] B;
        double[,] C;
        //Định nghĩa biến chứa số hàng/cột của ma trận
        int N;
        //Định nghĩa danh sách trạng thái thi hành của các thread con
        int[] stateLst = new int[20];
        //Định nghĩa danh sách thời gian thi hành của các thread con
        System.TimeSpan[] dateLst = new System.TimeSpan[20];
        //Định nghĩa biến miêu tả quyền ưu tên của chương trình
        ProcessPriorityClass myPrio = ProcessPriorityClass.Normal;
        Process MyProc;
        //Định nghĩa danh sách các quyền ưu tiên cho các thread
        ThreadPriority[] tPrio =
        {
            ThreadPriority.Lowest, ThreadPriority.BelowNormal, ThreadPriority.Normal,
            ThreadPriority.AboveNormal, ThreadPriority.Highest
        };
        //Định nghĩa hàm các hàng ma trận tích theo yêu cầu trong tham số
        void TinhTich(object obj)
        {
            DateTime t1 = DateTime.Now;
            Params p = (Params)obj;
            int h, c, k;
            for (h = p.sr; h < p.er; h++)
                for (c = 0; c < N; c++)
                {
                    double s = 0;
                    for (k = 0; k < N; k++)
                        s = s + A[h, k] * B[k, c];
                    C[h, c] = s;
                }
            //Ghi nhận đã hoàn thành nhiệm vụ
            stateLst[p.id] = 1;
            //Ghi nhận thời gian tính
            dateLst[p.id] = DateTime.Now.Subtract(t1);
        }

        public Form1()
        {

            InitializeComponent();
            //Thêm vào các lệnh khởi tạo sau đây
            lbKetqua.Items.Clear();
            //Khởi tạo các ma trận A, B, C
            N = 1000;
            A = new double[N, N];
            B = new double[N, N];
            C = new double[N, N];
            int h, c;
            for (h = 0; h < N; h++)
                for (c = 0; c < N; c++)
                    A[h, c] = B[h, c] = c;
        }


        private void btnCham_Click(object sender, EventArgs e)
        {
            //Thiết lập chế độ quyền ưu tiên realtime cho chương trình
            myPrio = ProcessPriorityClass.BelowNormal;
        }

        private void btnNhanh_Click(object sender, EventArgs e)
        {
            //Thiết lập chế độ quyền ưu tiên realtime cho chương trình
            myPrio = ProcessPriorityClass.RealTime;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Xác định đối tượng quản lý process hiện hành
            MyProc = Process.GetCurrentProcess();
            //Thay đổi quyền ưu tiên theo yêu cầu người dùng
            MyProc.PriorityClass = myPrio;
            //Xác định số thread tham gia tính tích 2 ma trận
            int cnt = Int32.Parse(txtThreads.Text);
            int i;
            //Ghi nhận thời điểm bắt đầu tính tích
            DateTime t1 = DateTime.Now;
            if (cnt == 1)
                //Dùng thuật ngữ giải tuần tự
                TinhTich(new Params(null, 0, N, 0));
            else
            {
                //Dùng thuật giải song song gồm cnt-1 thread con và 1 thread chính có sẵn
                Thread t;
                //Lập tạo và chạy từng thread con
                for (i = 0; i < cnt - 1; i++)
                {
                    //Ghi nhận thread i chưa chạy xong
                    stateLst[i] = 0;
                    //Tạo thread mới để chạy hàm TinhTich
                    t = new Thread(new ParameterizedThreadStart(TinhTich));
                    //Thiết lập quyền ưu tiên cho thread i
                    t.Priority = tPrio[i % 5];
                    //Hiển thị độ ưu tiên của thread i
                    lbKetqua.Items.Add(String.Format("Thread {0:d} co do uu tien = {1:d}", i, t.Priority.ToString()));
                    //Kích hoạt thread i chạy và truyền các tham số cần thiết cho nó
                    t.Start(new Params(t, i * N / cnt, (i + 1) * N / cnt, i));
                }
                //Bản thân thread cha cũng tính N/cnt hàng cuối của ma trận tích
                TinhTich(new Params(null, (cnt - 1) * N / cnt, N, cnt - 1));
                //Chờ đợi các thread con hoàn thành
                for (i = 0; i < cnt - 1; i++)
                    //Cho
                    while (stateLst[i] == 0) ;

            }
            //Ghi nhận thời điểm kết thúc tính tích
            DateTime t2 = DateTime.Now;
            System.TimeSpan diff;
            //Hiển thị độ ưu tiên hiện hành của chương trình
            lbKetqua.Items.Add("Ung dung da chay voi quyen" + myPrio.ToString());
            //Hiển thị thời gian tính của từng thread con
            for (i = 0; i < cnt - 1; i++)
            {
                diff = dateLst[i]
;
                lbKetqua.Items.Add(String.Format("Thread {0:d} chay ton {1:d2} phut {2:d2} giay {3:d3} ms", i, diff.Minutes, diff.Seconds, diff.Milliseconds));
            }
            diff = t2.Subtract(t1);
            //Hiển thị thời gian tổng cộng để tính tích
            lbKetqua.Items.Add(String.Format("{0:d} threads ==> Thoi gian chay la {1:d2} phut {2:d2} giay {3:d3} ms", cnt, diff.Minutes, diff.Seconds, diff.Milliseconds));
        }
    }
}
