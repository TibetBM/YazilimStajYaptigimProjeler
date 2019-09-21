using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KORDSA_UTP
{
    public partial class AnaForm : Form
    {
        Islem islem;
        string listeid;
        public AnaForm()
        {
            InitializeComponent();
            islem = new Islem();
            listeid = "";
            this.Validate(); // bu komut programın daha hızlı çizilmesini sağlar
        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
            dgw_liste.DataSource = islem.stokListe();
        }

        private void btncikis_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Çıkış Yapmak İstediğinizden Emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                Application.Exit();
        }
        
        private void btnstokekle_MouseHover(object sender, EventArgs e)
        {
            btnstokekle.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnstokekle_MouseLeave(object sender, EventArgs e)
        {
            btnstokekle.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btnstokguncelle_MouseHover(object sender, EventArgs e)
        {
            btnstokguncelle.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnstokguncelle_MouseLeave(object sender, EventArgs e)
        {
            btnstokguncelle.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btnstoksil_MouseHover(object sender, EventArgs e)
        {
            btnstokhurdayacikar.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnstoksil_MouseLeave(object sender, EventArgs e)
        {
            btnstokhurdayacikar.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btnstokara_MouseHover(object sender, EventArgs e)
        {
            btnstokara.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnstokara_MouseLeave(object sender, EventArgs e)
        {
            btnstokara.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btnresimekle_MouseHover(object sender, EventArgs e)
        {
            btnhakkinda.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnresimekle_MouseLeave(object sender, EventArgs e)
        {
            btnhakkinda.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btncikis_MouseHover(object sender, EventArgs e)
        {
            btncikis.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btncikis_MouseLeave(object sender, EventArgs e)
        {
            btncikis.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }
        
        private void btnhakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1-Programda * ile işaretlenmiş alanların doldurulması zorunludur.\n"+
                "2-Zorunlu alanlar doldurulduktan sonra Stok Ekle butonuna basılarak " +
                "stok eklenir.\n" +
                "3-Stok Güncelle butonundan stok güncellenir.\n" +
                "4-Stok Güncelle butonunun aktive olması için listeden ilgili kayda 2 kez tıklamak şarttır.\n" +
                "5-Stok Hurdaya Çıkar butonundan stok silinir ve hurda listesine eklenir.\n" +
                "6-Stok Listele butonundan stoklar listelenir.\n" +
                "7-Hurda Listele butonundan hurdalar listelenir.\n" +
                "8-Stok Ara butonunundan stok adına göre, modele göre veya raf numarasına göre arama yapılır.\n" +
                "9-Ada göre arama yapmak için stok adı kısmının doldurulması ve model ve raf no kısımlarının boş bırakılması gerekir.\n" +
                "10-Modele göre arama yapmak için model kısmının doldurulması ve ad ve raf no kısımlarının boş bırakılması gerekir. \n"+
                "11-Raf numarasına göre arama yapmak için raf no kısmının doldurulması ve ad ve model kısımlarının boş bırakılması gerekir. \n" +
                "12-Temizle butonundan form temizlenir.Aynı zamanda her veri girişin yanındaki çarpılardan veriler " +
                "temizlenir.Tarih bilgisi de hurda olduğu günü  gösterir.","Kılavuz",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnhurdaliste_MouseHover(object sender, EventArgs e)
        {
            btnhurdaliste.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnhurdaliste_MouseLeave(object sender, EventArgs e)
        {
            btnhurdaliste.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btnstokgetir_MouseHover(object sender, EventArgs e)
        {
            btnstokgetir.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btnstokgetir_MouseLeave(object sender, EventArgs e)
        {
            btnstokgetir.BackColor = Color.MediumBlue;
            this.Cursor = Cursors.Default;
        }

        private void btnresimsec_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnresimsec_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void btnsilstokadi_Click(object sender, EventArgs e)
        {
            txtad.Text = "";
        }

        private void btnsilstokadedi_Click(object sender, EventArgs e)
        {
            txtadet.Text = "";
        }

        private void btnsilstokrafno_Click(object sender, EventArgs e)
        {
            cmbstokrafno.Text = "";
        }

        private void btnsilstokmodel_Click(object sender, EventArgs e)
        {
            txtmodel.Text = "";
        }

        private void btnsilstokserino_Click(object sender, EventArgs e)
        {
            txtserino.Text = "";
        }

        private void btnsilelemanisim_Click(object sender, EventArgs e)
        {
            txtelemanisim.Text = "";
        }

        private void btnsilaciklama_Click(object sender, EventArgs e)
        {
            txtaciklama.Text = "";
        }

        private void btnsilstokadi_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilstokadedi_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilstokrafno_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilstokmodel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilstokserino_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilelemanisim_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilaciklama_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsilstokadi_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilstokadedi_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilstokrafno_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilstokmodel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilstokserino_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilelemanisim_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilfoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnsilaciklama_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        public void formuTemizle()
        {
            txtaciklama.Text = "";
            txtad.Text = "";
            txtadet.Text = "";
            txtelemanisim.Text = "";
            txtmodel.Text = "";
            txtserino.Text = "";
            txtserino.Text = "";
            cmbstokrafno.Text = "";
            dtpTarih.Value = DateTime.Now;
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            formuTemizle();
            btnstokguncelle.Enabled = false;
        }

        private void btntemizle_MouseHover(object sender, EventArgs e)
        {
            btntemizle.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
        }

        private void btntemizle_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btntemizle.BackColor = Color.MediumBlue;
        }

        private void btnsiltarih_Click(object sender, EventArgs e)
        {
            dtpTarih.Value = DateTime.Now;
        }

        private void btnsiltarih_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnsiltarih_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
 

        private void btnstokekle_Click(object sender, EventArgs e)
        {
            if (txtad.Text != "" && txtadet.Text != "" && cmbstokrafno.Text != "" && txtmodel.Text != "" && txtserino.Text != "" && dtpTarih.Value != null &&
                txtelemanisim.Text != "" &&islem.seriNoAynimi(txtserino.Text)&&islem.adetKontrol(txtadet.Text)&&islem.rafNoKontrol(cmbstokrafno.Text))  
            {
              
                islem.stokEkle(txtad.Text, txtadet.Text, cmbstokrafno.Text, txtmodel.Text, txtserino.Text, dtpTarih.Value, txtelemanisim.Text, txtaciklama.Text);
                formuTemizle();
                dgw_liste.DataSource = islem.stokListe();
                MessageBox.Show("Stok Ekleme İşlemi Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Stok Ekleme İşlemi Başarısız Olmuştur.Lütfen girdiğiniz verileri kontrol ediniz !",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnstokhurdayacikar_Click(object sender, EventArgs e)
        {
            if(txtserino.Text!=""&&islem.seriNoAynimi(txtserino.Text)!=true)
            {
                DialogResult r = MessageBox.Show("Bu veriyi hurdaya çıkarmak istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    islem.stokHurdayaCikar(txtserino.Text);
                    formuTemizle();
                    dgw_liste.DataSource = islem.stokListe();
                    MessageBox.Show("Stok Hurdaya Çıkarma İşlemi Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Stok Hurdaya Çıkarma İşlemi Başarısız Olmuştur.Lütfen girdiğiniz verileri kontrol ediniz !",
                  "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnstokguncelle_Click(object sender, EventArgs e)
        {
            if(txtad.Text != "" && txtadet.Text != "" && cmbstokrafno.Text != "" && txtmodel.Text != "" && txtserino.Text != "" && dtpTarih.Value != null 
                && txtelemanisim.Text != ""&&islem.adetKontrol(txtadet.Text) && islem.rafNoKontrol(cmbstokrafno.Text)
                && islem.guncellemeKontrol(Convert.ToInt32(listeid), txtserino.Text))
            {
                islem.stokGuncelle(Convert.ToInt32(listeid),txtad.Text,txtadet.Text,cmbstokrafno.Text,txtmodel.Text,txtserino.Text,dtpTarih.Value,txtelemanisim.Text
                 ,txtaciklama.Text);
                formuTemizle();
                dgw_liste.DataSource = islem.stokListe();
                MessageBox.Show("Stok Güncelleme İşlemi Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Stok Güncelleme İşlemi Başarısız Olmuştur.Lütfen girdiğiniz verileri kontrol ediniz !",
                 "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              btnstokguncelle.Enabled = false;
        }

        private void btnstokgetir_Click(object sender, EventArgs e)
        {
            dgw_liste.DataSource = islem.stokListe();
        }
       
        private void btnhurdaliste_Click(object sender, EventArgs e)
        {
            dgw_liste.DataSource = islem.hurdaListe();
        }
       
        private void dgw_liste_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                
                listeid = dgw_liste.CurrentRow.Cells[0].Value.ToString();
                txtad.Text = dgw_liste.CurrentRow.Cells[1].Value.ToString();
                txtadet.Text = dgw_liste.CurrentRow.Cells[2].Value.ToString();
                cmbstokrafno.Text = dgw_liste.CurrentRow.Cells[3].Value.ToString();
                txtmodel.Text = dgw_liste.CurrentRow.Cells[4].Value.ToString();
                txtserino.Text = dgw_liste.CurrentRow.Cells[5].Value.ToString();
                dtpTarih.Value = Convert.ToDateTime(dgw_liste.CurrentRow.Cells[6].Value.ToString());
                txtelemanisim.Text = dgw_liste.CurrentRow.Cells[7].Value.ToString();
                txtaciklama.Text = dgw_liste.CurrentRow.Cells[8].Value.ToString();
                btnstokguncelle.Enabled = true;
        }
        private void btnstokara_Click(object sender, EventArgs e)
        {
            if (txtad.Text != String.Empty && txtmodel.Text == "" && cmbstokrafno.Text == "")
                dgw_liste.DataSource = islem.stokAraIsim(txtad.Text);
            else if (txtmodel.Text != String.Empty && txtad.Text == "" && cmbstokrafno.Text == "")
                dgw_liste.DataSource = islem.stokAraModel(txtmodel.Text);
            else if (cmbstokrafno.Text != String.Empty && txtad.Text == "" && txtmodel.Text == "")
                dgw_liste.DataSource = islem.stokAraRafNo(cmbstokrafno.Text);
            else
            {
                MessageBox.Show("Lütfen ad olarak aramak için model ve raf no kısmını model olarak aramak için ad ve raf no kısmını " +
                    "raf no olarak aramak için ad ve model kısmını boş bırakınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtad.Text = "";
                txtmodel.Text = "";
                cmbstokrafno.Text = "";
            }
        }
    }
}
